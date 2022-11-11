using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperty {
    public int hp; // ×î´óhp
    public int attack;
    public int defend;
    public int agi;

    public CharacterProperty() {

    }

    public void Zero() {
        this.hp = 0;
        this.attack = 0;
        this.defend = 0;
        this.agi = 0;
    }

    public static CharacterProperty operator +(CharacterProperty a, CharacterProperty b) {
        return new CharacterProperty { 
            hp = a.hp + b.hp,
            attack = a.attack + b.attack,
            defend = a.defend + b.defend,
            agi = a.agi + b.agi
        };
    }
}
