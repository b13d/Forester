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
            Debug.Log("Мало денег");
        }
        else
        {
            Debug.Log("Вы купили саженец под id" + idSeed);
            Debug.Log("На вашем счету было" + coins);
            coins -= 50;
            Debug.Log("На вашем счету стало" + coins);
            GameSettings.instance.Coins = coins;

            Debug.Log("Добавляю саженец");
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
            Debug.LogError("Недостаточное кол-во саженцев для продажи!");
            return;
        }

        Debug.Log("На вашем счету было" + coins);
        coins += 10;
        Debug.Log("На вашем счету стало" + coins);
        GameSettings.instance.Coins = coins;

        Debug.Log("Удаляю саженец");
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
            Debug.LogError("Недостаточно дерева для продажи, необходимо минимум 1 дерево!");
        }

        GameSettings.instance.Coins = coins;
        _textCoin.text = coins.ToString();
    }
}
