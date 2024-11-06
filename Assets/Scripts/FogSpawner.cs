using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSpawner : MonoBehaviour
{
    [SerializeField]
    List<Sprite> _spritesFog;

    [SerializeField]
    Fog _fog;

    void Start()
    {
        StartCoroutine(SpawnFog());
    }

    IEnumerator SpawnFog()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);

            int randomSprite = Random.Range(0, _spritesFog.Count);

            var newFog = Instantiate(_fog, transform);
            newFog.GetComponent<SpriteRenderer>().sprite = _spritesFog[randomSprite];

            Sequence sequence = DOTween.Sequence();
            sequence.Append(newFog.gameObject.transform.DOScale(0, 0));
            sequence.Append(newFog.gameObject.transform.DOScale(Random.Range(3f, 7f), 1f));// mb here change value
            newFog.transform.position = new Vector2(Random.Range(-8, 8), Random.Range(-6, 6));

            float randomValue = Random.Range(10, 25f);
            StartCoroutine(DestroyFog(randomValue, newFog.gameObject));
        }
    }

    IEnumerator DestroyFog(float value, GameObject fog)
    {
        yield return new WaitForSeconds(value);

        fog.transform.DOScale(0, 1f);
        Destroy(fog, 1.3f);
    }
}
