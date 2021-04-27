using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _coinsText;
    private int _coins;

    void Start()
    {
        
    }

    
    void Update()
    {
        _coinsText.text = _coins.ToString();
    }


    public void CoinToplama(int miktar)
    {
        _coins += miktar;
    }
}
