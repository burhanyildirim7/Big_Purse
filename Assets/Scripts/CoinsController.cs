using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _winScreenCoinsText;
    [SerializeField] private TextMeshProUGUI _loseScreenCoinsText;
    private int _coins;
    private int _oyundaToplananCoins;

    private int _hesaplananCoins;

    void Start()
    {
        //_coins = 0;
        //PlayerPrefs.SetInt("Coins", _coins);
        _coins = PlayerPrefs.GetInt("Coins");
    }

    
    void Update()
    {
        _coins = PlayerPrefs.GetInt("Coins");
        _coinsText.text = "" +  _coins;
    }


    public void CoinToplama(int miktar)
    {
        _oyundaToplananCoins += miktar;
        _coins += miktar;
        PlayerPrefs.SetInt("Coins", _coins);
    }

    public void OyunSonuCoinsHesapla(int deger)
    {
        _hesaplananCoins = 0;
        _coins = PlayerPrefs.GetInt("Coins");
        _hesaplananCoins += (_oyundaToplananCoins * deger);
        _winScreenCoinsText.text = _hesaplananCoins.ToString();
        _loseScreenCoinsText.text = _oyundaToplananCoins.ToString();
        //PlayerPrefs.SetInt("Coins", _coins);
    }

    public void CollectCoins()
    {
        _coins = PlayerPrefs.GetInt("Coins");
        _coins += _hesaplananCoins;
        PlayerPrefs.SetInt("Coins", _coins);
        _oyundaToplananCoins = 0;
    }

    public void CollectCoins3x()
    {
        _coins = PlayerPrefs.GetInt("Coins");
        _coins += (_hesaplananCoins * 3);
        PlayerPrefs.SetInt("Coins", _coins);
        _oyundaToplananCoins = 0;
    }
}
