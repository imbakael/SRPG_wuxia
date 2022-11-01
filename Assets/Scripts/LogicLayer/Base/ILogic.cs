using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogic {
    void OnCreate();
    void OnDestroy();
    void OnLogicFrameUpdate();
}
