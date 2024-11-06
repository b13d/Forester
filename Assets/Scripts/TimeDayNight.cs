using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeDayNight : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _textTime;
    [SerializeField]
    TextMeshProUGUI _textDay;
    [SerializeField]
    Light2D _light;

    int _countDay = 1;
    const float START_SECONDS = 10f;

    float _seconds = START_SECONDS;
    int _minutes = 0;
    int _hours = 8;

    void Awake()
    {
        Time.timeScale = 50;
        string hours = _hours > 9 ? _hours.ToString() : "0" + _hours;
        string minutes = _minutes == 0 ? "00" : _minutes.ToString();
        _textTime.text = $"{hours}:{minutes}";
        _textDay.text = $"Day {_countDay}";
    }

    void ChangeDay()
    {
        _countDay++;
        _textDay.text = $"Day {_countDay}";
    }

    void Update()
    {
        _seconds -= Time.deltaTime;

        if (_seconds <= 0)
        {
            _minutes += 10;
            _seconds = START_SECONDS;

            if (_minutes == 60)
            {
                _hours += 1;
                _minutes = 0;

                if (_hours > 23)
                {
                    _hours = 0;

                    ChangeDay();
                }
            }

            string hours = _hours > 9 ? _hours.ToString() : "0" + _hours;
            string minutes = _minutes == 0 ? "00" : _minutes.ToString();
            _textTime.text = $"{hours}:{minutes}";

            if (_hours == 4)
            {
                _light.color = new Color32(110, 110, 110, 255);
            }

            if (_hours == 5)
            {
                _light.color = new Color32(130, 130, 130, 255);
            }

            if (_hours == 6)
            {
                _light.color = new Color32(160, 160, 160, 255);
            }

            if (_hours == 7)
            {
                _light.color = new Color32(200, 200, 200, 255);
            }

            if (_hours == 8)
            {
                _light.color = new Color32(255, 255, 255, 255);
            }

            if (_hours == 13)
            {
                _light.color = new Color32(220, 220, 220, 255);
            }

            if (_hours == 17)
            {
                _light.color = new Color32(195, 195, 195, 255);
            }

            if (_hours == 21)
            {
                _light.color = new Color32(130, 130, 130, 255);
            }

            if (_hours == 22)
            {
                _light.color = new Color32(90, 90, 90, 255);
            }

            if (_hours == 22)
            {
                _light.color = new Color32(70, 70, 70, 255);
            }

            if (_hours == 0)
            {
                _light.color = new Color32(35, 35, 35, 255);
            }
        }
    }
}
