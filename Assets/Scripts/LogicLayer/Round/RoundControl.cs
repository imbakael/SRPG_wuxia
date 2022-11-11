using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundControl : ILogic {

    private Queue<Character> activeCharacters;
    private CharacterControl characterControl;
    private int roundId; // 当前第几回合

    public void OnCreate() {
        
    }

    public void OnDestroy() {
        
    }

    public void OnLogicFrameUpdate() {
        
    }

    public void NextRound() {
        roundId++;
        activeCharacters = characterControl.GetSortByAgi();
        NextCharacter();
    }

    public void NextCharacter() {
        if (activeCharacters.Count == 0) {
            RoundEnd();
            NextRound();
            return;
        }
        Character currentCharacter = activeCharacters.Dequeue();
        currentCharacter.StartAction();
        currentCharacter.OnActionEnd -= NextCharacter;
        currentCharacter.OnActionEnd += NextCharacter;
    }

    public void RoundEnd() {
        characterControl.RunOneCycleBuff();
    }
}