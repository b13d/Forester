using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private Canvas _pressE;
    [SerializeField]
    Canvas _shop;

    bool _canPress = false;

    private void Start()
    {
        _pressE.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _pressE.gameObject.SetActive(true);
            _canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _pressE.gameObject.SetActive(false);
            _canPress = false;
            _shop.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_canPress)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _shop.gameObject.SetActive(!_shop.gameObject.activeSelf);
            }
        }
    }
}
