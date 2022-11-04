using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    public bool IsDead { get; private set; }
    public Action OnActionEnd;

    public CharacterProperty currentProperty; // 基础属性 + buff附带属性 + 装备附带属性
    private CharacterProperty baseProperty; // 基础属性

    public List<BuffObj> buffs = new List<BuffObj>();

    private CharacterRender characterRender;

    public Character() {
        
    }

    // 1.触发buff，播放完buff特效动画
    // 2.移动到目标位置
    // 3.攻击or释放技能
    // 4.待机

    public void ActionStart() {
        TickBuffBeforeAction();
    }

    // 角色行动前触发buff效果，如中毒扣血、回血等
    public void TickBuffBeforeAction() {
        for (int i = 0; i < buffs.Count; i++) {
            BuffObj buff = buffs[i];
            buff.model.buffOnTick?.Invoke(buff);
        }
    }

    private void MoveTo() {
        var moveToAction = new MoveToAction(characterRender.transform, Vector3.zero, 800);
        ActionManager.Instance.RunAction(moveToAction);
    }

    private void Attack() {
        characterRender.PlayAnim("Attack");
        LogicTimerManager.Instance.DelayCall(300, TakeDamage);
    }

    private void TakeDamage() {
        DamageManager.Instance.CreateDamageInfo(this, null, new Damage { physics = currentProperty.attack }, false, true);
    }

    public void ActionEnd() {
        OnActionEnd?.Invoke();
    }
}