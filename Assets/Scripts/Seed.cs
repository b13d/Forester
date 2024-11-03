using System.Collections;
using UnityEngine;

public class Seed : MonoBehaviour
{
    const float WAIT_TIME = 10f;

    [SerializeField]
    bool _isPlanted = false;
    [SerializeField]
    bool _isSelected = false;
    [SerializeField]
    Sprite _earlierTree;
    [SerializeField]
    Tree _tree;
    [SerializeField]
    SpriteRenderer _sprite;
    [SerializeField]
    Allocation _allocation;
    [SerializeField]
    int _idSeed;
    

    public int GetIdSeed => _idSeed;
    public SpriteRenderer GetSprite => _sprite;
    public bool SetPlanted { set { _isPlanted = value; } }
    public bool GetIsSelected { get { return _isSelected; } }

    void Start()
    {
        if (!_isPlanted)
        {
            _allocation.gameObject.SetActive(false);
        }
    }

    public void Planted()
    {
        _isPlanted = true;
        Destroy(GetComponent<InteractiveObject>());
        Destroy(GetComponent<FollowOnMouse>());
        StartCoroutine(TreeGrowth());
    }

    IEnumerator TreeGrowth()
    {
        yield return new WaitForSeconds(WAIT_TIME);
        _sprite.sprite = _earlierTree;
        yield return new WaitForSeconds(WAIT_TIME);
        Instantiate(_tree, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
