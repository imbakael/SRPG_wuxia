using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicTimerManager : Singleton<LogicTimerManager>, ILogic {

    private List<LogicTimer> logicTimers = new List<LogicTimer>();

    public void DelayCall(int delayMs, Action OnTimerComplete, int loop = 1) {
        var logicTimer = new LogicTimer(delayMs, OnTimerComplete, loop);
        logicTimers.Add(logicTimer);
    }

    public void OnCreate() {
        
    }

    public void OnDestroy() {
        
    }

    public void OnLogicFrameUpdate() {
        for (int i = 0; i < logicTimers.Count; i++) {
            logicTimers[i].OnLogicFrameUpdate();
        }
        for (int i = logicTimers.Count - 1; i >= 0; i--) {
            if (logicTimers[i].finished) {
                logicTimers.RemoveAt(i);
            }
        }
    }
}
