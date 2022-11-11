using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    public event Action<int> OnShowDamage; // ֪ͨ��ʾ�˺�����
    public event Action<float> OnHpSliderChange; // ֪ͨˢ��Ѫ��

    public bool IsDead { get; private set; }
    public bool IsWait { get; private set; }

    public event Action OnActionEnd;

    public CharacterProperty currentProperty; // �������� + buff�������� + װ����������
    private CharacterProperty baseProperty; // ��������
    private CharacterResource resource;

    public List<BuffObj> buffs = new List<BuffObj>();

    private CharacterRender characterRender;

    public Character() {
        // �������ݴ���buff��equip��item����Ȼ��ˢ������
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

    // AIʱÿ����ɫ���ж�����
    // 1.����buff��������buff��Ч����
    // 2.�ƶ���Ŀ��λ��
    // 3.����or�ͷż���
    // 4.����

    // ��ɫ�ж�ǰ����buffЧ�������ж���Ѫ����Ѫ��
    public void TickBuffBeforeAction() {
        for (int i = 0; i < buffs.Count; i++) {
            BuffObj buff = buffs[i];
            buff.model.buffOnTick?.Invoke(buff);
        }
    }

    // �غϽ���ǰ����һ�Σ��������г���ʱ���buff���������ʱ����Ƴ�
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
                // buff�Ƴ�ʱ�Ļص�������buff��ʧʱɱ��Ŀ��
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