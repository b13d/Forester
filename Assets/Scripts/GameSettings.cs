using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _textCoins;
    [SerializeField]
    TextMeshProUGUI _textWoods;
    [SerializeField]
    GameObject _canvasStart;
    [SerializeField]
    bool _canPlant = true;

    int _coins = 100;
    int _woods;

    public static GameSettings instance;

    private GameObject _seedOnMouse;


    #region Property

    public bool IsCanPlant
    {
        get { return _canPlant; }
        set { _canPlant = value; }
    }

    public int Coins
    {
        get { return _coins; }
        set
        {
            if (value >= 0)
            {
                _coins = value;
                _textCoins.text = _coins.ToString();
            }
        }
    }

    public int Woods
    {
        get { return _woods; }
        set
        {
            if (value >= 0)
            {
                _woods = value;
                _textWoods.text = _woods.ToString();
            }
        }
    }

    public GameObject SeedOnMouse
    {
        set { _seedOnMouse = value; }
        get { return _seedOnMouse; }
    }

    #endregion


    #region Methods

    void Start()
    {
        if (instance == null)
        {
            instance = this;

            Initial();
        }
    }

    void Initial()
    {
        _textCoins.text = _coins.ToString();
        _textWoods.text = _woods.ToString();
    }

    public void AddCoin(int sum)
    {
        _coins += sum;

        _textCoins.text = _coins.ToString();
    }

    public void AddWood()
    {
        _woods++;

        _textWoods.text = _woods.ToString();
    }

    public void BuySeed()
    {
        Debug.Log("Вычисляю стоимость");
        Debug.Log("Добавляю саженец");
    }

    public void SellWood()
    {
        Debug.Log("Продаю дерево");
        Debug.Log("Получаю денежку");
    }

    #endregion




}
