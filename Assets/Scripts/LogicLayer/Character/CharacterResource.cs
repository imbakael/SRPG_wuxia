using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterResource {
    public int hp;

    public CharacterResource(int hp) {
        this.hp = hp;
    }

    public static CharacterResource operator +(CharacterResource a, CharacterResource b) {
        return new CharacterResource(a.hp + b.hp);
    }
}
