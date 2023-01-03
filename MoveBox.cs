using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    [SerializeField] private Transform _targetMovePosition;

    public Transform TargetMovePosition{ get => _targetMovePosition; }

    [SerializeField] private Collider _mainCollider;

    public Collider MainCollider{ get => _mainCollider; }

    [SerializeField] private bool _mainColliderHasToBeDisabled = true;

    public bool MainColliderHasToBeDisabled{ get => _mainColliderHasToBeDisabled; }

    [SerializeField] private bool _isDoor = false;

    public bool IsDoor { get => _isDoor; }
}