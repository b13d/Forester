using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tree : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator _animator;

    [SerializeField]
    int _health = 3;

    [SerializeField]
    Wood _wood;

    [SerializeField]
    Seed _seed;

    [SerializeField]
    AudioSource _audio;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawSphere(transform.position, 1);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Триггер в зоне");

        if (collision.tag == "Axe")
        {
            _audio.Play();
            _animator.SetTrigger("Hit");

            _health--;

            if (_health <= 0)
            {
                int random = Random.Range(1, 5);
                int randomSeeds = Random.Range(1, 3);


                for (int i = random; i > 0; i--)
                {
                    Vector2 newPosition = new Vector2(Random.Range(-1.55f, 1.55f), Random.Range(-1.55f, 1.55f));

                    var newWood = Instantiate(_wood,(Vector2)transform.position + newPosition, Quaternion.identity);

                    Sequence sequence = DOTween.Sequence();

                    sequence.Append(newWood.transform.DOScale(0, 0));
                    sequence.Append(newWood.transform.DOScale(4, 1f));
                }

                for (int j = randomSeeds; j > 0; j--)
                {
                    Vector2 newPosition = new Vector2(Random.Range(-0.75f, 0.75f), Random.Range(-0.75f, 0.75f));

                    var newSeed = Instantiate(_seed.gameObject, (Vector2)transform.position + newPosition, Quaternion.identity);
                    newSeed.GetComponent<Seed>().SetPlanted = false;

                    Sequence sequence = DOTween.Sequence();

                    sequence.Append(newSeed.transform.DOScale(0, 0));
                    sequence.Append(newSeed.transform.DOScale(4, 1f));
                }

                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(gameObject, 0.5f);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (GameSettings.instance.prefabSeed != null) 
        //{
        //    GameSettings.instance.Plant = false;
        //    _allocation.SetActive(true);
        //}
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //GameSettings.instance.Plant = true;
        //_allocation.SetActive(false);
    }
}
