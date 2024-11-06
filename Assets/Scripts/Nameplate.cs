using TMPro;
using UnityEngine;

public class Nameplate : MonoBehaviour
{
    [SerializeField]
    UseObject _pressE;
    [SerializeField]
    GameObject _area;
    [SerializeField]
    int _priceArea;
    [SerializeField]
    TextMeshProUGUI _textPriceArea;

    private void Start()
    {
        _textPriceArea.text = _priceArea.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _pressE.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _pressE.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_pressE.gameObject.activeSelf)
        {
            bool canBuy = GameSettings.instance.Coins >= _priceArea;

            if (Input.GetKeyDown(KeyCode.E) && canBuy)
            {
                _area.SetActive(false);
                GameSettings.instance.Coins -= _priceArea;
                Destroy(gameObject);
            }
        }
    }
}
