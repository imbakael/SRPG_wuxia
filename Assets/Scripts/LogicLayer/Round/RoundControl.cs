using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundControl : ILogic {

    private Queue<Character> activeCharacters;
    private CharacterControl characterControl;

    public void OnCreate() {
        
    }

    public void OnDestroy() {
        
    }

    public void OnLogicFrameUpdate() {
        
    }

    public void NextRoundStart() {
        activeCharacters = characterControl.CalcuAttackSort();
        NextCharacterAttack();
    }

    private void NextCharacterAttack() {
        if (activeCharacters.Count == 0) {
            RoundEnd();
            NextRoundStart();
            return;
        }
        Character attacker = activeCharacters.Dequeue();
        
    }

    private void RoundEnd() {
        
    }
}