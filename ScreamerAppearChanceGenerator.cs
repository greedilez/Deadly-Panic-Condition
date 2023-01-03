using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreamerAppearChanceGenerator : MonoBehaviour
{
    [SerializeField] private int _maxRandomChanceInclusive = 9;

    [SerializeField] private int _afterWhatValueScreamerShow = 5;

    [SerializeField] private int _screamerSceneIndex = 4;

    public bool IsScreamerWillBeShowed() {
        int chance = Random.Range(0, _maxRandomChanceInclusive);
        Debug.Log($"Current chance: {chance}");
        return (chance > _afterWhatValueScreamerShow);
    }

    public void MoveToScreamerScene() {
        Debug.Log("Screamer will be showed!");
        SceneManager.LoadScene(_screamerSceneIndex);
    }
}
