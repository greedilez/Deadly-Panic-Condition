using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingDelay : MonoBehaviour
{
    [SerializeField] private float _loadingDuration = 5f;

    [SerializeField] private int _targetSceneIndex = 3;

    public UnityEvent OnTimeOut;

    private void Awake() => StartCoroutine(LoadTargetSceneAfterDelay());

    public IEnumerator LoadTargetSceneAfterDelay() {
        yield return new WaitForSeconds(_loadingDuration); OnTimeOut.Invoke();
    }

    public void LoadScene(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
}
