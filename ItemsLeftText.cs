using TMPro;
using UnityEngine;

public class ItemsLeftText : MonoBehaviour
{
    private TMP_Text _targetText;

    [SerializeField] private ItemsSpawner _itemsSpawner;

    private void Awake() => _targetText = GetComponent<TMP_Text>();

    public void UpdateItemsLeftCount() => _targetText.text = $"Items left: {_itemsSpawner.ItemsAtScene.Count}";
}
