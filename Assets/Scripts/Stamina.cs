using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    const float MAX_VALUE = 100;
    const float MIN_VALUE = 0;
    const float MINUS_STAMINA = 0.5f;

    [SerializeField]
    Slider _sliderStamina;

    void Start()
    {
        _sliderStamina.value = MAX_VALUE;

        StartCoroutine(Expiration());
    }

    public void IncreaseInEndurance(float power)
    {
        _sliderStamina.value += power;
    }

    public void WasteOfStamina(float power)
    {
        _sliderStamina.value -= power;

        if (_sliderStamina.value <= MIN_VALUE)
        {
            _sliderStamina.value = MIN_VALUE;

            Debug.LogError("Стамина закончилась, игрок уснул");
        }
    }

    IEnumerator Expiration()
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);

            if (_sliderStamina.value > MIN_VALUE)
            {
                if (_sliderStamina.value - MINUS_STAMINA <= MIN_VALUE)
                {
                    _sliderStamina.value = MIN_VALUE;

                    Debug.LogError("Стамина закончилась, игрок уснул");

                    break;
                }

                _sliderStamina.value -= MINUS_STAMINA;
            }
            else
            {
                Debug.LogError("Стамина закончилась, игрок уснул");

                break;
            }
        }
    }
}
