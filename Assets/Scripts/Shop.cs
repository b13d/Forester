using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    List<Item> _seedItems;
    [SerializeField]
    List<TextMeshProUGUI> _seedTextsCount;
    [SerializeField]
    TextMeshProUGUI _textWood;
    [SerializeField]
    TextMeshProUGUI _textCoin;

    public List<Item> SeedItems => _seedItems;

    public void BuySeed(int idSeed)
    {
        int coins = GameSettings.instance.Coins;

        if (coins < 50)
        {
            Debug.Log("���� �����");
        }
        else
        {
            Debug.Log("�� ������ ������� ��� id" + idSeed);
            Debug.Log("�� ����� ����� ����" + coins);
            coins -= 50;
            Debug.Log("�� ����� ����� �����" + coins);
            GameSettings.instance.Coins = coins;

            Debug.Log("�������� �������");
            _seedItems[idSeed].AddCount();
            _seedTextsCount[idSeed].text = _seedItems[idSeed].GetCountSeed.ToString();
        }

        _textCoin.text = coins.ToString();
    }

    public void SellSeed(int idSeed)
    {
        int coins = GameSettings.instance.Coins;

        if (_seedItems[idSeed].GetCountSeed <= 0)
        {
            Debug.LogError("������������� ���-�� �������� ��� �������!");
            return;
        }

        Debug.Log("�� ����� ����� ����" + coins);
        coins += 10;
        Debug.Log("�� ����� ����� �����" + coins);
        GameSettings.instance.Coins = coins;

        Debug.Log("������ �������");
        _seedItems[idSeed].ReduceCount();
        _seedTextsCount[idSeed].text = _seedItems[idSeed].GetCountSeed.ToString();

        _textCoin.text = coins.ToString();
    }

    public void SellWood()
    {
        int woods = GameSettings.instance.Woods;
        int coins = GameSettings.instance.Coins;

        if (woods > 0)
        {
            int countWoods = GameSettings.instance.Woods -= 1;
            coins += 5;

            _textWood.text = countWoods.ToString(); 
        } 
        else
        {
            Debug.LogError("������������ ������ ��� �������, ���������� ������� 1 ������!");
        }

        GameSettings.instance.Coins = coins;
        _textCoin.text = coins.ToString();
    }
}
