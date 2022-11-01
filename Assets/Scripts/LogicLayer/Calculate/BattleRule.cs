using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRule {

    public static int CalculateDamage(DamageInfo damageInfo, CharacterProperty target) {
        Damage damage = damageInfo.damage;
        bool isCrit = damageInfo.isCrit;
        float value = damage.physics - target.defend;
        float critValue = GetCritValue(value, isCrit);
        return Mathf.RoundToInt(critValue);
    }

    public static float GetCritValue(float value, bool isCrit) {
        return isCrit ? value * 3f : value;
    }
}