using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField]
    UseObject _pressE;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _pressE.gameObject.SetActive(true);
            Debug.Log("Игрок задел дом!");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _pressE.gameObject.SetActive(false);
            Debug.Log("Игрок отошел от дома!");
        }
    }

    private void Update()
    {
        if (_pressE.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.LogError("ТУТ ДОЛЖЕН НАЧИНАТЬСЯ НОВЫЙ ДЕНЬ");

                FindObjectOfType<Stamina>().IncreaseInEndurance(100);
            }
        }
    }
}
