using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundControl : ILogic {

    private Queue<Character> activeCharacters;
    private CharacterControl characterControl;
    private int roundId;

    public void OnCreate() {
        
    }

    public void OnDestroy() {
        
    }

    public void OnLogicFrameUpdate() {
        
    }

    public void NextRoundStart() {
        roundId++;
        activeCharacters = characterControl.CalcuAttackSort();
        NextCharacterAction();
    }

    private void NextCharacterAction() {
        if (activeCharacters.Count == 0) {
            RoundEnd();
            NextRoundStart();
            return;
        }
        Character character = activeCharacters.Dequeue();
        character.ActionStart();
        character.OnActionEnd = NextCharacterAction;
    }

    // 某阵营回合结束
    private void RoundEnd() {
        
    }
}