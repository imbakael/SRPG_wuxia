using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffObj {
    public BuffModel model;
    public Character caster; // buff�ͷ���(����buff�ĵ�λ)
    public Character carrier; // buffЯ����(Я��buff�ĵ�λ)
    public int buffId;
    public bool permanent;
    public int stack; // ��ǰ���Ӳ���
    public int existedTurns; // �Ѿ����ڶ��ٻغ�
}
