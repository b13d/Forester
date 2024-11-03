using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    const int MAX_VALUE = 10;
    const int MIN_VALUE = 0;

    [SerializeField]
    Slider _sliderStamina;

    void Start()
    {
        _sliderStamina.value = MAX_VALUE;
    }
}
