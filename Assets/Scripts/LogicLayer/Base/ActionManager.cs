using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : Singleton<ActionManager>, ILogic {

    private List<ActionBase> actions = new List<ActionBase>();
    public void OnCreate() {
        
    }

    public void OnDestroy() {
        
    }

    public void OnLogicFrameUpdate() {
        while (actions.Count > 0) {
            ActionBase action = actions[0];
            if (!action.actionComplete) {
                action.OnLogicFrameUpdate();
                break;
            }
            actions.RemoveAt(0);
        }
    }

    public void RunAction(ActionBase action) {
        actions.Add(action);
    }
}
