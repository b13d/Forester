using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _items = new List<GameObject>();

    [SerializeField]
    int _currentItem = 0;


    void Start()
    {
        _items[0].GetComponent<Item>().SetSelected();
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            _items[_currentItem].GetComponent<Item>().SetDefault();

            _currentItem++;

            if (_currentItem >= _items.Count)
            {
                _currentItem = 0;
            }

            ChangeItem();
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            _items[_currentItem].GetComponent<Item>().SetDefault();

            _currentItem--;

            if (_currentItem < 0)
            {
                _currentItem = _items.Count - 1;
            }

            ChangeItem();
        }
    }

    public void ChangeItem()
    {
        _items[_currentItem].GetComponent<Item>().SetSelected();
        //GameSettings.instance.SeedOnMouse = null;

        Destroy(GameSettings.instance.SeedOnMouse);

        GameSettings.instance.currentItem = _items[_currentItem].GetComponent<Item>();
        GameSettings.instance.prefabSeed = _items[_currentItem].GetComponent<Item>().GetSeed;
        GameSettings.instance.SetCursor.GetComponent<SpriteRenderer>().sprite = _items[_currentItem].GetComponent<Item>().GetSprite;

        Debug.Log(GameSettings.instance.prefabSeed == null ? "YES is AXEEE" : "NO IS SEED!");
    }
}
