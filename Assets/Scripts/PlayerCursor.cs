using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("В мой диапозон - " + collision.gameObject);
    }
}
