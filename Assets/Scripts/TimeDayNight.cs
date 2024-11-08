using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

[Serializable]
public class AnimationDayOver
{
    public GameObject canvas;
    public TextMeshProUGUI textDayOver;
    public Image imageBg;
}

public class TimeDayNight : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _textTime;
    [SerializeField]
    TextMeshProUGUI _textDay;
    [SerializeField]
    Light2D _light;
    [SerializeField]
    Vector2 _posSpawnPlayer;
    public AnimationDayOver animationDayOver;

    PlayerController _player;
    Stamina _stamina;

    int _countDay = 1;
    const float START_SECONDS = 10f;

    float _seconds = START_SECONDS;
    int _minutes = 0;
    int _hours = 8;

    bool _wasUpdateDay = false;

    void Awake()
    {
        Time.timeScale = 50;
        string hours = _hours > 9 ? _hours.ToString() : "0" + _hours;
        string minutes = _minutes == 0 ? "00" : _minutes.ToString();
        _textTime.text = $"{hours}:{minutes}";
        _textDay.text = $"Day {_countDay}";

        _player = FindObjectOfType<PlayerController>();
        _stamina = FindObjectOfType<Stamina>();
    }

    private void Start()
    {

    }

    void HideCanvas()
    {
        animationDayOver.canvas.SetActive(false);
    }

    void ChangeDay()
    {
        _wasUpdateDay = true;
        _countDay++;
        _textDay.text = $"Day {_countDay}";

    }

    public void NewDay()
    {
        if (_hours > 1 && _hours <= 23)
        {
            ChangeDay();
        }

        _hours = 8;
        _minutes = 0;

        string hours = $"0{_hours}";
        string minutes = $"0{_minutes}";
        _textTime.text = $"{hours}:{minutes}";

        _stamina.ResetStamina();
        _player.gameObject.transform.position = _posSpawnPlayer;

        animationDayOver.canvas.SetActive(true);
        Sequence sequence = DOTween.Sequence();
        Sequence sequenceText = DOTween.Sequence();

        animationDayOver.textDayOver.gameObject.transform.localScale = Vector2.zero;
        sequenceText.Append(animationDayOver.textDayOver.gameObject.transform.DOScale(1, 1f));
        sequence.Append(animationDayOver.imageBg.GetComponent<Image>().DOColor(new Color(0.462f, 0.338f, 0.192f, 1), 1f));
        sequenceText.Append(animationDayOver.textDayOver.gameObject.transform.DOScale(0, 2f));
        sequence.Append(animationDayOver.imageBg.GetComponent<Image>().DOColor(new Color(0.462f, 0.338f, 0.192f, 0), 2f));

        Invoke("HideCanvas", 2.5f);
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

                if (_hours == 1)
                {
                    NewDay();
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
