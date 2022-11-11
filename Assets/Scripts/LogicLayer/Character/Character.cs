using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    public event Action<int> OnShowDamage; // 通知显示伤害数字
    public event Action<float> OnHpSliderChange; // 通知刷新血条

    public bool IsDead { get; private set; }
    public bool IsWait { get; private set; }

    public event Action OnActionEnd;

    public CharacterProperty currentProperty; // 基础属性 + buff附带属性 + 装备附带属性
    private CharacterProperty baseProperty; // 基础属性
    private CharacterResource resource;

    public List<BuffObj> buffs = new List<BuffObj>();

    private CharacterRender characterRender;

    public Character() {
        // 根据数据创建buff、equip、item对象，然后刷新属性
        RefreshProperty();
    }

    private void RefreshProperty() {
        currentProperty.Zero();
        var buffProp = new CharacterProperty();
        for (int i = 0; i < buffs.Count; i++) {
            BuffObj buff = buffs[i];
            if (buff.model.prop != null) {
                buffProp += buff.model.prop;
            }
        }
        currentProperty = baseProperty + buffProp;
    }

    public void StartAction() {
        TickBuffBeforeAction();
    }

    public void EndAction() {
        OnActionEnd?.Invoke();
    }

    public void ModifyResource(CharacterResource deltaRes) {
        resource += deltaRes;
        resource.hp = Mathf.Clamp(resource.hp, 0, currentProperty.hp);
        if (resource.hp <= 0) {
            Die();
        } else {
            if (deltaRes.hp < 0) {
                characterRender.PlayAnim("Hit");
            }
        }
        OnShowDamage?.Invoke(deltaRes.hp);
        float hpRate = resource.hp * 1f / currentProperty.hp;
        OnHpSliderChange?.Invoke(hpRate);
    }

    public void Die() {
        characterRender.PlayAnim("Die");
    }

    // AI时每个角色的行动流程
    // 1.触发buff，播放完buff特效动画
    // 2.移动到目标位置
    // 3.攻击or释放技能
    // 4.待机

    // 角色行动前触发buff效果，如中毒扣血、回血等
    public void TickBuffBeforeAction() {
        for (int i = 0; i < buffs.Count; i++) {
            BuffObj buff = buffs[i];
            buff.model.buffOnTick?.Invoke(buff);
        }
    }

    // 回合结束前调用一次，适用于有持续时间的buff，到达持续时间后移除
    public void RunOneCycleBuff() {
        RemoveBuff((buff) => {
            if (!buff.permanent) {
                buff.existedTurns += 1;
                if (buff.existedTurns >= buff.model.durationRound) {
                    return true;
                }
            }
            return false;
        });
    }

    private void RemoveBuff(Func<BuffObj, bool> filter) {
        int index = 0;
        bool isBuffRemoved = false;
        while (index < buffs.Count) {
            BuffObj buff = buffs[index];
            if (filter(buff)) {
                buffs.RemoveAt(index);
                isBuffRemoved = true;
                // buff移除时的回调，比如buff消失时杀死目标
                continue;
            }
            index++;
        }
        if (isBuffRemoved) {
            RefreshProperty();
        }
    }

    private void MoveTo(Vector3 targetPos) {
        var moveToAction = new MoveToAction(characterRender.transform, targetPos, 800);
        ActionManager.Instance.RunAction(moveToAction);
    }

    private void Attack() {
        characterRender.PlayAnim("Attack");
    }
}