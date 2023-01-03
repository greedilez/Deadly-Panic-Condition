using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SceneTransitionEffect : MonoBehaviour
{
    [SerializeField] private Animator _targetScreenAnimator;
    
    public UnityEvent OnAppearPlayed, OnDisappearPlayed;

    private string[] _effectNames = { "Appear", "Disappear" };

    private float[] _effectDurations = { 0.5f, 0.5f };

    [SerializeField] private bool _playOnAwake = false;

    [SerializeField] private int _effectTypeIndexOnAwake = 1;

    private void Awake() {
        if (_playOnAwake) _targetScreenAnimator.SetTrigger(_effectNames[_effectTypeIndexOnAwake]);
    }

    public void TryToPlayEffect(int effectType) => PlayEffect(effectType);

    private void PlayEffect(int effectTypeIndex) {
        _targetScreenAnimator.SetTrigger(_effectNames[effectTypeIndex]);
        StartCoroutine(TurnAnimationPlayedEvent(_effectDurations[effectTypeIndex], effectTypeIndex));
    }

    public IEnumerator TurnAnimationPlayedEvent(float animationLength, int effectType) {
        yield return new WaitForSeconds(animationLength);
        {
            switch (effectType)
            {
                case 0: OnAppearPlayed.Invoke(); break;
                case 1: OnDisappearPlayed.Invoke(); break;
            }
        }
    }
}