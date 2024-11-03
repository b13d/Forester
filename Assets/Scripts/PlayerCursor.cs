using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    string _tagStay = "";

    [SerializeField]
    TextMeshProUGUI _textCanPlanting;

    [SerializeField]
    List<Seed> _listActiveTrigger;


    private void Update()
    {
        _textCanPlanting.text = _tagStay;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError("Столкнулся с новым саженцем");

        if (collision.CompareTag("Seed"))
        {
            _listActiveTrigger.Add(collision.GetComponent<Seed>());

            _tagStay = collision.tag;

            GameSettings.instance.IsCanPlant = false;

            _textCanPlanting.text = "FALSE";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Seed"))
        {
            _listActiveTrigger.Remove(collision.GetComponent<Seed>());

            if (_listActiveTrigger.Count <= 0)
            {
                _tagStay = "";

                GameSettings.instance.IsCanPlant = true;
            }
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    //_tagStay = collision.tag;

    //    if (!GameSettings.instance.IsCanPlant && _tagStay != "Seed") 
    //    {
    //        GameSettings.instance.IsCanPlant = true;

    //        _textCanPlanting.text = "TRUE";
    //    }
    //}
}
