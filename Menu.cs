using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour, ISceneLoader
{
    [SerializeField] private int _gameSceneIndex = 1;

    [SerializeField] private float _buttonRaycastDistance = 100f;

    private void Update() => SendRaycastOnMouseClick();

    private void SendRaycastOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) SendRaycastToButtons();
    }

    private void SendRaycastToButtons() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, _buttonRaycastDistance)) TryToUseClickableBox(hit);
    }

    private void TryToUseClickableBox(RaycastHit hit) {
        ClickableBox clickableBox = hit.collider.GetComponent<ClickableBox>();
        if (clickableBox != null) UseClickableBox(clickableBox);
    }

    private void UseClickableBox(ClickableBox clickableBox) => clickableBox.OnBoxClicked.Invoke();

    public void LoadGameScene() => LoadScene(_gameSceneIndex);

    public void LoadScene(int sceneIndex) => SceneManager.LoadScene(sceneIndex);

    public void ExitFromGame() => Application.Quit();
}
