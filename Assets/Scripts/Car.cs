using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private Canvas _pressE;

    private void Start()
    {
        _pressE.gameObject.SetActive(false);
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
}
