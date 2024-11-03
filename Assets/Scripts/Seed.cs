using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField]
    bool _isPlanted = false;
    bool _isSeedClose = false;

    const float WAIT_TIME = 10f;

    [SerializeField]
    bool _isSelected = false;

    [SerializeField]
    Sprite _earlierTree;

    [SerializeField]
    Tree _tree;

    SpriteRenderer _sprite;


    public bool IsSeedClose => _isSeedClose;
    public bool SetPlanted { set { _isPlanted = value; } }
    public bool GetIsSelected { get { return _isSelected; } }

    void Start()
    {
        _isPlanted = false;
        _sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();

        //if (_isPlanted)
        //{
        //    Destroy(GetComponent<FollowOnMouse>());
        //    Destroy(GetComponent<InteractiveObject>());
        //    StartCoroutine(TreeGrowth());
        //}
    }

    public void Planted()
    {
        _isPlanted = true;
        Destroy(GetComponent<InteractiveObject>());
        Destroy(GetComponent<FollowOnMouse>());
        StartCoroutine(TreeGrowth());
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0) && !_isPlanted && !_isSeedClose)
    //    {
    //        _isPlanted = true;
    //        Destroy(GetComponent<InteractiveObject>());
    //        Destroy(GetComponent<FollowOnMouse>());
    //        StartCoroutine(TreeGrowth());
    //    }
    //}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CloseSeed" && other.transform.parent.gameObject != gameObject)
        {
            _isSeedClose = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "CloseSeed" && other.transform.parent.gameObject != gameObject)
        {
            _isSeedClose = false;
        }
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
