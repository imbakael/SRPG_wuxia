using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : Singleton<DamageManager>, ILogic {

    private List<DamageInfo> damageInfos = new List<DamageInfo>();

    public void OnCreate() {
        
    }

    public void OnDestroy() {
        damageInfos.Clear();
    }

    public void OnLogicFrameUpdate() {
        while (damageInfos.Count > 0) {
            DealWithDamge(damageInfos[0]);
            damageInfos.RemoveAt(0);
        }
    }

    private void DealWithDamge(DamageInfo damageInfo) {
        Character attacker = damageInfo.attacker;
        Character attackTarget = damageInfo.attackTarget;
        if (attackTarget == null || attackTarget.IsDead) {
            return;
        }
        // 根据一系列buff的回调处理damageInfo
        if (attacker != null) {
            for (int i = 0; i < attacker.buffs.Count; i++) {
                BuffObj buff = attacker.buffs[i];
                buff.model.buffOnHit?.Invoke(buff, damageInfo);
            }
        }
        // 根据最终的damageInfo计算伤害
        int damageValue = BattleRule.CalculateDamage(damageInfo, attackTarget.currentProperty);
        attackTarget.ModifyResource(new CharacterResource(-damageValue));
    }

    public DamageInfo CreateDamageInfo(Character attacker, Character attackTarget, Damage damage, bool isCrit, bool isNormalAttack) {
        var damageInfo = new DamageInfo(attacker, attackTarget, damage, isCrit, isNormalAttack);
        damageInfos.Add(damageInfo);
        return damageInfo;
    }
}
