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

    int _coins;
    int _woods;

    public Items items;
    public Seed prefabSeed;
   
    public static GameSettings instance;

    private GameObject _seedOnMouse;



    public bool IsCanPlant
    {
        get { return _canPlant; }
        set { _canPlant = value; }
    }

    public int GetCoins => _coins;

    public GameObject SeedOnMouse
    {
        set { _seedOnMouse = value; }
        get { return _seedOnMouse; }
    }

    void Start()
    {
        //Time.timeScale = 0;

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
}
