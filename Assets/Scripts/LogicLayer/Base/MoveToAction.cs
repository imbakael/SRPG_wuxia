using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAction : ActionBase {

    private Transform moveObj;
    private Vector3 targetPos;
    private int timeMs;
    private Action OnNextAction;

    private int lerpTime;
    private Vector3 originPos;

    public MoveToAction(Transform moveObj, Vector3 targetPos, int timeMs, Action OnNextAction = null) {
        this.moveObj = moveObj;
        this.targetPos = targetPos;
        this.timeMs = timeMs;
        this.OnNextAction = OnNextAction;
    }

    public override void OnLogicFrameUpdate() {
        base.OnLogicFrameUpdate();
        lerpTime += LogicFrameConfig.LogicFrameIntvertalMs;
        float lerp = lerpTime * 1f / timeMs;
        moveObj.position = Vector3.Lerp(originPos, targetPos, lerp);
        if (lerp >= 1) {
            OnNextAction?.Invoke();
            actionComplete = true;
        }
    }
}
