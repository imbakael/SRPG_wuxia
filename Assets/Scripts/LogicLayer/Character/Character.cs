using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    public bool IsDead { get; private set; }

    public CharacterProperty currentProperty; // �������� + buff�������� + װ����������
    private CharacterProperty baseProperty; // ��������

    public List<BuffObj> buffs = new List<BuffObj>();

    public Character() {
        
    }
}