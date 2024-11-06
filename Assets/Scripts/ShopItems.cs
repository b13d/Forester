using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItems : MonoBehaviour
{
    [SerializeField]
    List<TextMeshProUGUI> _textsSeed;
    [SerializeField]
    TextMeshProUGUI _textWood;
    [SerializeField]
    TextMeshProUGUI _textCoin;
    
    Shop _shop;
    List<Item> _seedItems;

    private void Start()
    {
    }

    private void OnEnable()
    {
        if (!_shop)
        {
            _shop = FindObjectOfType<Shop>();
            _seedItems = _shop.SeedItems;
        }

        Debug.LogWarning("Магазин открылся");

        _textCoin.text = GameSettings.instance.Coins.ToString();
        _textWood.text = GameSettings.instance.Woods.ToString();
    
        for (int i = 0; i < _textsSeed.Count; i++)
        {
            _textsSeed[i].text = _seedItems[i].GetCountSeed.ToString();
        }
    }

    private void OnDisable()
    {
        Debug.LogWarning("Магазин закрылся");
    }

}
