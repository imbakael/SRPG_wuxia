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

    public string onHit;
    public string onTick;
    public BuffOnHit buffOnHit;
    public BuffOnTick buffOnTick;

    public BuffModel() {
        
    }

    public void InitCallback() {
        if (!string.IsNullOrEmpty(onHit)) {
            buffOnHit = BuffOnHitCallback.all[onHit];
        }
        if (!string.IsNullOrEmpty(onTick)) {
            buffOnTick = BuffOnTickCallback.all[onTick];
        }
    }
}

public delegate void BuffOnHit(BuffObj theBuff, DamageInfo damageInfo);
public delegate void BuffOnTick(BuffObj theBuff);
