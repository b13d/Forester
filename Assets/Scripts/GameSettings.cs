using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _textCoins;
    [SerializeField]
    TextMeshProUGUI _textWoods;
    [SerializeField]
    TextMeshProUGUI _textSeeds1;
    [SerializeField]
    TextMeshProUGUI _textSeeds2;
    [SerializeField]
    TextMeshProUGUI _textSeeds3;

    int _coins;
    int _woods;

    int _seeds1;
    int _seeds2;
    int _seeds3;

    public Item currentItem;
    public Seed prefabSeed;
    public List<int> _seedsList;
    public static GameSettings instance;

    private GameObject _seedOnMouse;

    [SerializeField]
    GameObject _canvasStart;
    [SerializeField]
    List<Item> _items;
    [SerializeField]
    Item _axe;
    [SerializeField]
    PlayerCursor _cursor;
    [SerializeField]
    bool _canPlant = true;

    public bool Plant
    {
        get { return _canPlant; }
        set { _canPlant = value; }
    }

    public Item GetAxe => _axe;

    public PlayerCursor SetCursor
    {
        get { return _cursor; }
    }

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



    private void Update()
    {
        _cursor.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1.0f;
            Destroy(_canvasStart.gameObject);
        }

        if (prefabSeed != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (currentItem.CountSeed > 0 && _canPlant)
                {
                    var currentCount = currentItem.RemoveSeed();
                    RemoveSeed(currentItem.GetIdSeed);
                    var newSeed = Instantiate(prefabSeed.gameObject, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                    //newSeed.GetComponent<Seed>().SetPlanted = true;
                    newSeed.GetComponent<Seed>().Planted();
                    //Destroy(_seedOnMouse.gameObject);

                    if (currentCount <= 0)
                    {
                        prefabSeed = null;
                    }
                }

            }
        }
    }

    public List<int> GetSeedCount()
    {
        _seedsList = new List<int> { _seeds1, _seeds2, _seeds3 };

        return _seedsList;
    }

    void Initial()
    {
        _textCoins.text = _coins.ToString();
        _textWoods.text = _woods.ToString();
        _textSeeds1.text = _seeds1.ToString();
        _textSeeds2.text = _seeds2.ToString();
        _textSeeds3.text = _seeds3.ToString();
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

    public void AddSeed(int idSeed)
    {
        if (idSeed == 1)
        {
            _seeds1++;
            _textSeeds1.text = _seeds1.ToString();
            _items[0].CountSeed = _seeds1;
        }

        if (idSeed == 2)
        {
            _seeds2++;
            _textSeeds2.text = _seeds2.ToString();
            _items[1].CountSeed = _seeds2;
        }

        if (idSeed == 3)
        {
            _seeds3++;
            _textSeeds3.text = _seeds3.ToString();
            _items[2].CountSeed = _seeds3;
        }
    }

    public void RemoveSeed(int idSeed)
    {
        if (idSeed == 0)
        {
            _seeds1--;
            _textSeeds1.text = _seeds1.ToString();
            _items[0].CountSeed = _seeds1;
        }

        if (idSeed == 1)
        {
            _seeds2--;
            _textSeeds2.text = _seeds2.ToString();
            _items[1].CountSeed = _seeds2;
        }

        if (idSeed == 2)
        {
            _seeds3--;
            _textSeeds3.text = _seeds3.ToString();
            _items[2].CountSeed = _seeds3;
        }
    }
}
