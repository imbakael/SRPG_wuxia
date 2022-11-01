using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    public bool IsDead { get; private set; }

    public CharacterProperty currentProperty; // 基础属性 + buff附带属性 + 装备附带属性
    private CharacterProperty baseProperty; // 基础属性

    public List<BuffObj> buffs = new List<BuffObj>();

    public Character() {
        
    }
}