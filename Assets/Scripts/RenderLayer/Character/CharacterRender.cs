using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 负责角色动画、血条、伤害数字等
public class CharacterRender : MonoBehaviour {

    private Character character;
    private Slider hpSlider;
    private Animator animator;
    private Transform damagePoint;

    public void Init(Character character) {
        this.character = character;
        animator = GetComponentInChildren<Animator>();
        hpSlider = GetComponentInChildren<Slider>();
        damagePoint = transform.Find("damagePoint");
        character.OnShowDamage += OnShowDamage;
        character.OnHpSliderChange += OnHpChange;
    }

    private void OnShowDamage(int value) {
        // 创建一个伤害UI，上浮后消失
    }

    private void OnHpChange(float value) {
        hpSlider.value = value;
    }

    public void PlayAnim(string animName) {
        animator.SetTrigger(animName);
    }

    public void Destroy() {
        character.OnHpSliderChange -= OnHpChange;
        character.OnShowDamage -= OnShowDamage;
        Destroy(gameObject);
    }
}
