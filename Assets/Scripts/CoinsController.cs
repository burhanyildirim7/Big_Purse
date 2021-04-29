using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _coinsText;
    private int _coins;
    private int _oyundaToplananCoins;

    void Start()
    {
        _coins = PlayerPrefs.GetInt("Coins");
    }

    
    void Update()
    {
        _coins = PlayerPrefs.GetInt("Coins");
        _coinsText.text = _coins.ToString();
    }


    public void CoinToplama(int miktar)
    {
        _oyundaToplananCoins += miktar;
    }

    public void OyunSonuCoinsHesapla(int deger)
    {
        _coins = PlayerPrefs.GetInt("Coins");
        _coins += _oyundaToplananCoins * deger;
        //PlayerPrefs.SetInt("Coins", _coins);
    }

    public void CollectCoins()
    {
        PlayerPrefs.SetInt("Coins", _coins);
    }

    public void CollectCoins3x()
    {
        _coins = _coins * 3;
        PlayerPrefs.SetInt("Coins", _coins);
    }
}
