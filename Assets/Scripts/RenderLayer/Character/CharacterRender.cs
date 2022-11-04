using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 负责角色以及血条等UI的渲染
public class CharacterRender : MonoBehaviour {

    private Animator animator;

    public void Init() {
        animator = GetComponentInChildren<Animator>();
    }

    public void PlayAnim(string animName) {
        animator.SetTrigger(animName);
    }
}
