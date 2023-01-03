using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5f;

    private void FixedUpdate() => RotatePlayerAlongY();

    public void RotatePlayerAlongY() => transform.Rotate(new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed, 0), Space.World);
}
