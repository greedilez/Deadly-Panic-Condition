using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private MoveMouseButton _moveMouseButton = MoveMouseButton.Right;

    [SerializeField] private float _maxRaycastDistance = 30f;

    [SerializeField] private Animator _betweenMovementScreenAnimator;

    [SerializeField] private float _moveDelay = 0.5f;

    private bool _canMove = true;

    [SerializeField] private ScreamerAppearChanceGenerator _screamerAppearChanceGenerator;

    private void Update() => SendRaycastOnMouseClick();

    public void SendRaycastOnMouseClick() {
        if (Input.GetMouseButtonDown((int)_moveMouseButton) && _canMove) SendRaycastToTargetMoveBox();
    }

    public void SendRaycastToTargetMoveBox() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * _maxRaycastDistance, Color.red);
        if(Physics.Raycast(ray, out hit, _maxRaycastDistance)) {
            if(hit.collider.tag == "MoveBox") {
                MoveBox targetMoveBox = hit.collider.GetComponent<MoveBox>();
                MoveToMoveBoxPosition(targetMoveBox);
                if(targetMoveBox.MainColliderHasToBeDisabled) TurnOffColliderForCurrentBox(targetMoveBox);
                EnableCollidersForOtherBoxes(targetMoveBox);
            }
        }
    }

    public void TurnOffColliderForCurrentBox(MoveBox targetMoveBox) {
        targetMoveBox.MainCollider.enabled = false;
    }

    public void EnableCollidersForOtherBoxes(MoveBox targetMoveBox) {
        MoveBox[] moveBoxes = FindObjectsOfType<MoveBox>();
        for (int i = 0; i < moveBoxes.Length; i++) {
            if (moveBoxes[i] != targetMoveBox) moveBoxes[i].MainCollider.enabled = true;
        }
    }

    public void MoveToMoveBoxPosition(MoveBox targetMoveBox) {
        _canMove = false;
        StartCoroutine(MoveDelay(_moveDelay, targetMoveBox));
        StartCoroutine(CanMoveAgainDelay());
        TurnBetweenMovementScreen();
    }

    public IEnumerator MoveDelay(float moveDelay, MoveBox targetMoveBox) {
        yield return new WaitForSeconds(moveDelay);
        {
            transform.position = targetMoveBox.TargetMovePosition.position;
            if (targetMoveBox.IsDoor && _screamerAppearChanceGenerator.IsScreamerWillBeShowed()) _screamerAppearChanceGenerator.MoveToScreamerScene();
        }
    }

    public IEnumerator CanMoveAgainDelay() {
        int multiplier = 2;
        yield return new WaitForSeconds(_moveDelay * multiplier); _canMove = true;
    }

    public void TurnBetweenMovementScreen() => _betweenMovementScreenAnimator.SetTrigger("Appear");
}
public enum MoveMouseButton{ Right, Left }