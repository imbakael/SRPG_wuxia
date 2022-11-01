using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInfo {

    public Character attacker;
    public Character attackTarget;
    public Damage damage;
    public bool isCrit;
    public bool isNormalAttack;

    public DamageInfo(Character attacker, Character attackTarget, Damage damage, bool isCrit, bool isNormalAttack) {
        this.attacker = attacker;
        this.attackTarget = attackTarget;
        this.damage = damage;
        this.isCrit = isCrit;
        this.isNormalAttack = isNormalAttack;
    }
}
