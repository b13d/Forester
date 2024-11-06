using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    PlayerCursor _cursor;

    SpriteRenderer _cursorSprite;
    Inventory _inventory;
    Seed _selectedSeed;
    List<Item> _seedItems = new();
    Animator _animator;
    Stamina _stamina;

    private void Start()
    {
        _stamina = transform.parent.GetComponent<PlayerController>().Stamina;
        _animator = transform.parent.GetComponent<Animator>();
        _inventory = transform.parent.GetComponent<Inventory>();
        _cursorSprite = _cursor.GetComponent<SpriteRenderer>();
        _seedItems = _inventory.GetItemsSeed;
    }

    void Update()
    {
        _cursor.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (_inventory && _inventory.GetPrefabCurrentItem)
        {
            Seed seed = _inventory.GetPrefabCurrentItem.GetComponent<Seed>();
            _selectedSeed = seed;

            if (_seedItems[seed.GetIdSeed].GetCountSeed <= 0)
            {
                _selectedSeed = null;
                _cursorSprite.sprite = null;
            } 
            else
            {
                _cursorSprite.sprite = seed.GetSprite.sprite;
                Planting();
            }
        }
        else
        {
            Attack();

            _selectedSeed = null;
            _cursorSprite.sprite = null;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_animator.GetBool("Walk"))
            {
                return;
            }

            _stamina.WasteOfStamina(1.5f);
            _animator.SetTrigger("AttackTree");
        }
    }

    void Planting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameSettings.instance.IsCanPlant)
        {
            int idItem = _selectedSeed.GetIdSeed;
            int count = GameSettings.instance.items.GetItem(idItem).GetCountSeed;

            if (_selectedSeed != null && count > 0)
            {
                GameSettings.instance.items.GetItem(idItem).ReduceCount();

                var position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var newSeed = Instantiate(_selectedSeed.gameObject, position, Quaternion.identity);
                newSeed.GetComponent<Seed>().Planted();
                newSeed.GetComponent<InteractiveObject>().PlantSeed();

                count = GameSettings.instance.items.GetItem(idItem).GetCountSeed;
            }
        }
    }
}
