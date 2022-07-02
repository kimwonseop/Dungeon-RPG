using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class AnimationController : MonoBehaviour {
    // Placeholder functions for Animation events.
    public UnityEvent OnHit = new UnityEvent();
    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent OnFootR = new UnityEvent();
    public UnityEvent OnFootL = new UnityEvent();
    public UnityEvent OnLand = new UnityEvent();
    public UnityEvent OnWeaponSwitch = new UnityEvent();

    // Components.
    private Animator animator;
    private bool isSkillCasting = false;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private async UniTaskVoid CheckAnimationState(string targetAnimation) {
        isSkillCasting = true;
            
        await UniTask.WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(targetAnimation));

        isSkillCasting = false;
    }

    public void PlaySkillAnimation(int keyCodeIndex) {
        if (isSkillCasting) {
            return;
        }
        animator.SetTrigger($"skill_{keyCodeIndex + 1}");
        CheckAnimationState($"Skill_{keyCodeIndex + 1}").Forget();
    }

    public void Hit() {
        OnHit.Invoke();
    }

    public void Shoot() {
        OnShoot.Invoke();
    }

    public void FootR() {
        OnFootR.Invoke();
    }

    public void FootL() {
        OnFootL.Invoke();
    }

    public void Land() {
        OnLand.Invoke();
    }

    public void WeaponSwitch() {
        OnWeaponSwitch.Invoke();
    }
}
