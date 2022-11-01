using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffModel {

    public int id;
    public string name;
    public string des;
    public int priority;
    public int maxStack;
    public int durationRound; // 持续回合数
    public int triggerInterval; // 触发间隔
    public int triggerProbability;

    public BuffOnHit onHit;
}

public delegate void BuffOnHit(BuffObj theBuff, DamageInfo damageInfo);
