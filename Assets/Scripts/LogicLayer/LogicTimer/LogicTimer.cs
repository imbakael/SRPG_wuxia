using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicTimer : ILogic {

    public bool finished;

    private int delayMs;
    private Action OnTimerComplete;
    private int loop;
    private int accTime;

    public LogicTimer(int delayMs, Action OnTimerComplete, int loop = 1) {
        this.delayMs = delayMs;
        this.OnTimerComplete = OnTimerComplete;
        this.loop = loop;
    }

    public void OnCreate() {
        
    }

    public void OnDestroy() {
        
    }

    public void OnLogicFrameUpdate() {
        accTime += LogicFrameConfig.LogicFrameIntvertalMs;
        if (accTime >= delayMs && loop > 0) {
            OnTimerComplete?.Invoke();
            loop--;
            accTime = 0;
            if (loop == 0) {
                finished = true;
            }
        }
    }
}
