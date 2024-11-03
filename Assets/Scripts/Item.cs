using UnityEngine;
using UnityEngine.UI;

public enum Type
{
    SEED = 0,
    AXE = 1,
}

public class Item : MonoBehaviour
{
    public Type typeItem;

    [SerializeField]
    int _count;
    [SerializeField]
    Sprite _imageDefault;
    [SerializeField]
    Sprite _imageSelected;
    [SerializeField]
    bool _isSelected;
    [SerializeField]
    Seed _seedPrefab;
    [SerializeField]
    int _idSeed;
    [SerializeField]
    Sprite _sprite;

    public bool IsSelected => _isSelected;

    public Sprite GetSprite => _sprite;

    public int GetIdSeed => _idSeed;

    public int CountSeed
    {
        get => _count;
        set
        {
            _count = value;
        }
    }

    public Seed GetSeed
    {
        get => _seedPrefab;
    }

    public void SetDefault()
    {
        GetComponent<Image>().sprite = _imageDefault;
        _isSelected = false;
    }

    public void SetSelected()
    {
        GetComponent<Image>().sprite = _imageSelected;
        _isSelected = true;
    }

    public int RemoveSeed()
    {
        _count--;
        return _count;
    }

}
