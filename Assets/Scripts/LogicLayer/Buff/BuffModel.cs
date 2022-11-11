using Newtonsoft.Json;
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

    public string property;
    public CharacterProperty prop;

    public BuffModel() {
        
    }

    public void Init() {
        if (!string.IsNullOrEmpty(onHit)) {
            buffOnHit = BuffOnHitCallback.all[onHit];
        }
        if (!string.IsNullOrEmpty(onTick)) {
            buffOnTick = BuffOnTickCallback.all[onTick];
        }
        if (!string.IsNullOrEmpty(property)) {
            prop = JsonConvert.DeserializeObject<CharacterProperty>(property);
        }
    }
}

public delegate void BuffOnHit(BuffObj theBuff, DamageInfo damageInfo);
public delegate void BuffOnTick(BuffObj theBuff);
