using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffOnTickCallback {
    public static Dictionary<string, BuffOnTick> all = new Dictionary<string, BuffOnTick> {
        { "�ж�", Poisoning }
    };

    // �ж���ÿ���ж�ǰ-3hp
    private static void Poisoning(BuffObj theBuff) {
        Character target = theBuff.carrier;
        DamageManager.Instance.CreateDamageInfo(theBuff.caster, target, new Damage { physics = 3f }, false, false);
    }
}
