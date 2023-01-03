using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _items;

    [SerializeField] private Transform[] _spawnPositions;

    [SerializeField] private ItemsLeftText _itemsLeftText;

    public List<GameObject> ItemsAtScene = new List<GameObject>();

    private void Awake() => SpawnItemsAtRandomPositions(_items, _spawnPositions);

    public void SpawnItemsAtRandomPositions(GameObject[] items, Transform[] spawnPositions) {
        for (int i = 0; i < spawnPositions.Length; i++) {
            int itemIndex = Random.Range(0, items.Length);
            Vector3 position = spawnPositions[i].position;
            GameObject newItem = Instantiate(items[itemIndex], position, Quaternion.identity);
            ItemsAtScene.Add(newItem);
            _itemsLeftText.UpdateItemsLeftCount();
        }
    }
}
