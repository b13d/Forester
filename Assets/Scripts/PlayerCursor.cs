using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("� ��� �������� - " + collision.gameObject);
    }
}
