using UnityEngine;

public class Drink : MonoBehaviour
{
    [SerializeField]
    UseObject _pressE;


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
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<Stamina>().IncreaseInEndurance(3);
                Destroy(gameObject);
            }
        }
    }
}
