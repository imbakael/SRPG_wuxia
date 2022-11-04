using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffOnHitCallback {
    public static Dictionary<string, BuffOnHit> all = new Dictionary<string, BuffOnHit> {
        { "伤害加深", DamgeDeep }
    };

    // 伤害增加30%
    private static void DamgeDeep(BuffObj theBuff, DamageInfo damageInfo) {
        damageInfo.damage *= 1.3f;
    }
}
