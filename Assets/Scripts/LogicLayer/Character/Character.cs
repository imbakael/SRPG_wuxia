using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    public bool IsDead { get; private set; }
    public Action OnActionEnd;

    public CharacterProperty currentProperty; // �������� + buff�������� + װ����������
    private CharacterProperty baseProperty; // ��������

    public List<BuffObj> buffs = new List<BuffObj>();

    private CharacterRender characterRender;

    public Character() {
        
    }

    // 1.����buff��������buff��Ч����
    // 2.�ƶ���Ŀ��λ��
    // 3.����or�ͷż���
    // 4.����

    public void ActionStart() {
        TickBuffBeforeAction();
    }

    // ��ɫ�ж�ǰ����buffЧ�������ж���Ѫ����Ѫ��
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