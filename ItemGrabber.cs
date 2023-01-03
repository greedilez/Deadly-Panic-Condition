using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabber : MonoBehaviour
{
    [SerializeField] private int _targetMouseButtonIndex = 0;

    [SerializeField] private float _rayDistance = 50f;

    [SerializeField] private string _targetItemTag = "GameItem";

    [SerializeField] private ItemsSpawner _itemsSpawner;

    [SerializeField] private ItemsLeftText _itemsLeftText;

    private void Update() => TryToTakeAnItemOnMouseClick();

    private void TryToTakeAnItemOnMouseClick() {
        if (Input.GetMouseButtonDown(_targetMouseButtonIndex)) {
            TryToTakeAnItem();
        }
    }

    private void TryToTakeAnItem() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * _rayDistance, Color.red);
        if (Physics.Raycast(ray, out hit, _rayDistance)) {
            if(hit.collider.tag == _targetItemTag) {
                TakeAnItem(hit);
            }
        }
    }

    private void TakeAnItem(RaycastHit hit) {
        GameObject targetItem = hit.collider.gameObject;
        Debug.Log($"{targetItem.name} was taken!");
        RemoveTargetItemFromList(targetItem);
        Destroy(targetItem);
        _itemsLeftText.UpdateItemsLeftCount();
    }

    private void RemoveTargetItemFromList(GameObject targetItem) {
        for (int i = 0; i < _itemsSpawner.ItemsAtScene.Count; i++) {
            if (_itemsSpawner.ItemsAtScene[i] == targetItem) {
                _itemsSpawner.ItemsAtScene.RemoveAt(i);
                break;
            }
        }
    }
}
