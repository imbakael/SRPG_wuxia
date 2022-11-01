using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffObj {
    public BuffModel model;
    public Character caster; // buff释放者(产生buff的单位)
    public Character carrier; // buff携带者(携带buff的单位)
    public int buffId;
    public bool permanent;
    public int stack; // 当前叠加层数
    public int existedTurns; // 已经存在多少回合
}
