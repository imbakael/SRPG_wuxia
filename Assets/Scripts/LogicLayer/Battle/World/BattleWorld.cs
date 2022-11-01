using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWorld {

    private float accLogicRuntime;
    private float nextLogicRuntime;

    public void OnUpdate() {
        accLogicRuntime += Time.deltaTime;
        while (accLogicRuntime > nextLogicRuntime) {
            OnLogicFrameUpdate();
            nextLogicRuntime += LogicFrameConfig.LogicFrameIntvertal;
        }
    }

    public void OnLogicFrameUpdate() {
        LogicTimerManager.Instance.OnLogicFrameUpdate();
        DamageManager.Instance.OnLogicFrameUpdate();
    }
}
