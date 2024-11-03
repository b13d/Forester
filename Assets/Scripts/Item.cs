using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    Sprite _spriteDefault;
    [SerializeField]
    Sprite _spriteFocus;
    [SerializeField]
    TextMeshProUGUI _textCountSeed;
    [SerializeField]
    int _countSeed;
    [SerializeField]
    bool _isAxe;

    public int idItem;

    public int GetCountSeed => _countSeed;

    #region METHODS
    private void Start()
    {
        if (!_isAxe)
        {
            _textCountSeed.text = _countSeed.ToString();
        }

    }

    public void SetFocus()
    {
        GetComponent<Image>().sprite = _spriteFocus;
    }

    public void SetDefault()
    {
        GetComponent<Image>().sprite = _spriteDefault;
    }

    public void AddCount()
    {
        _countSeed++;
        UpdateText();
    }

    public void ReduceCount()
    {
        _countSeed--;
        UpdateText();
    }

    public int GetCount => _countSeed;

    public void UpdateText()
    {
        _textCountSeed.text = _countSeed.ToString();
    }

    #endregion


}
