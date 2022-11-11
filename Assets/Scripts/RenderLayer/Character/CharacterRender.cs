using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �����ɫ������Ѫ�����˺����ֵ�
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
        // ����һ���˺�UI���ϸ�����ʧ
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
