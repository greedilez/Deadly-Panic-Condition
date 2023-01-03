using System.Collections;
using UnityEngine;

public class GameExitAfterDelay : MonoBehaviour
{
    [SerializeField] private float _targetDelay = 5f;

    private void Awake() => StartCoroutine(ExitFromGameAfterDelay(_targetDelay));

    private IEnumerator ExitFromGameAfterDelay(float delay) {
        yield return new WaitForSeconds(delay); Application.Quit();
    }
}
