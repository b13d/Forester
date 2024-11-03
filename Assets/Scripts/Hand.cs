using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    PlayerCursor _cursor;

    SpriteRenderer _cursorSprite;
    Inventory _inventory;
    Seed _selectedSeed;

    bool _currentItemEmpty;

    private void Start()
    {
        _inventory = transform.parent.GetComponent<Inventory>();
        _cursorSprite = _cursor.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //if (_currentItemEmpty)
        //{
        //    _selectedSeed = null;
        //    _cursorSprite.sprite = null;
        //    return;
        //}

        _cursor.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (_inventory && _inventory.GetPrefabCurrentItem)
        {
            Seed seed = _inventory.GetPrefabCurrentItem.GetComponent<Seed>();
            _selectedSeed = seed;
            _cursorSprite.sprite = seed.GetSprite.sprite;

            Planting();
        }
        else
        {
            _selectedSeed = null;
            _cursorSprite.sprite = null;
        }
    }

    void Planting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameSettings.instance.IsCanPlant)
        {
            int idItem = _selectedSeed.GetIdSeed;
            int count = GameSettings.instance.items.GetItem(idItem).GetCount;

            if (_selectedSeed != null && count > 0)
            {
                _currentItemEmpty = false;

                GameSettings.instance.items.GetItem(idItem).ReduceCount();

                var position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var newSeed = Instantiate(_selectedSeed.gameObject, position, Quaternion.identity);
                newSeed.GetComponent<Seed>().Planted();
                newSeed.GetComponent<InteractiveObject>().PlantSeed();

                count = GameSettings.instance.items.GetItem(idItem).GetCount;

                if (count <= 0)
                {
                    _currentItemEmpty = true;
                }
            }

            if (count <= 0)
            {
                _currentItemEmpty = true;
            }
        }
    }
}
