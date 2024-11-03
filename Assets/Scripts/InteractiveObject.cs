using System;
using UnityEngine;

public enum OPTIONS
{
    WOOD = 0,
    SEED1 = 1,
    SEED2 = 2,
    SEED3 = 3
}

public class InteractiveObject : MonoBehaviour
{
    bool _isPlayerClose;
    public bool isOnMouseCursor;

    PlayerController _player;
    public OPTIONS _typeObject;

    private void Update()
    {
        if (isOnMouseCursor)
        {
            return;
        }

        if (_isPlayerClose)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.gameObject.transform.position, 0.05f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOnMouseCursor)
        {
            return;
        }

        if (collision.tag == "Player")
        {
            _isPlayerClose = true;
            _player = collision.GetComponent<PlayerController>();
        }

        if (collision.tag == "TriggerInnerPlayer")
        {
            Debug.Log("”ничтожаюсь!!");

            if (_typeObject == OPTIONS.WOOD)
            {
                GameSettings.instance.AddWood();
            } 
            else
            {
                GameSettings.instance.AddSeed((int)_typeObject);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isOnMouseCursor)
        {
            return;
        }

        if (collision.tag == "Player")
        {
            _isPlayerClose = false;
            _player = null;
        }
    }
}
