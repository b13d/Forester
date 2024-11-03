using UnityEngine;

public class FollowOnMouse : MonoBehaviour
{
    Seed _seed;

    private void Start()
    {
        _seed = GetComponent<Seed>();
    }

    void Update()
    {
        if (_seed.GetIsSelected)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
