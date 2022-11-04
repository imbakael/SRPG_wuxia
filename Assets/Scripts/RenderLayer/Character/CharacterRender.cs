using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ɫ�Լ�Ѫ����UI����Ⱦ
public class CharacterRender : MonoBehaviour {

    private Animator animator;

    public void Init() {
        animator = GetComponentInChildren<Animator>();
    }

    public void PlayAnim(string animName) {
        animator.SetTrigger(animName);
    }
}
