using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _prefabObject = new List<GameObject>();
    [SerializeField]
    List<GameObject> _itemsList = new List<GameObject>();
    [SerializeField]
    int _currentItem = 0;

    public GameObject GetPrefabCurrentItem
    {
        get
        {
            if (_currentItem == 0) return null;
            else
            {
                return _prefabObject[_currentItem];
            }
        }
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            _itemsList[_currentItem].GetComponent<Item>().SetDefault();

            _currentItem++;

            if (_currentItem >= _itemsList.Count)
            {
                _currentItem = 0;
            }

            ChangeItem();
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            _itemsList[_currentItem].GetComponent<Item>().SetDefault();

            _currentItem--;

            if (_currentItem < 0)
            {
                _currentItem = _itemsList.Count - 1;
            }

            ChangeItem();
        }
    }

    public void ChangeItem()
    {
        _itemsList[_currentItem].GetComponent<Item>().SetFocus();
    }
}
