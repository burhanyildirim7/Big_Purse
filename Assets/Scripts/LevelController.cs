using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelPrefabs = new List<GameObject>();
    [SerializeField] private List<float> _toplanmasiGerekenEsyaSayisi = new List<float>();

    private float _toplananEsyaSayisi;

    [SerializeField] private float _maksimumFirlatmaKuvveti;

    private float _esyaOrani;

    public static float _dusmaniFirlatmaKuvveti;

    [SerializeField] private CoinsController _coinsController;

    [SerializeField] private UIController _uiController;

    void Start()
    {
        _toplananEsyaSayisi = 0;
    }

    
    void Update()
    {
        
    }

    public void ToplananEsyaSayisi()
    {
        _toplananEsyaSayisi += 1;
        Debug.Log("TOPLADI" + _toplananEsyaSayisi.ToString());
    }

    public void EksilenEsyaSayisi()
    {
        _toplananEsyaSayisi -= 1;
    }

    public void DusmanaUygulanacakKuvvet()
    {
        _esyaOrani = (_toplananEsyaSayisi / _toplanmasiGerekenEsyaSayisi[0]) * 100;

        if (_esyaOrani >= 15)
        {
            _dusmaniFirlatmaKuvveti = _maksimumFirlatmaKuvveti * (_toplananEsyaSayisi / _toplanmasiGerekenEsyaSayisi[0]);
            Debug.Log("FirlatmaKuvveti = " + _dusmaniFirlatmaKuvveti.ToString());
        }
        else
        {
            Debug.Log(_esyaOrani.ToString() + " - Minimumun Altinda Kaldi");
        }
        
    }

    public void CollectButonu()
    {
        _coinsController.CollectCoins();
        DusmanControl._yereCarpti = false;
        _uiController.WinScreenClose();
    }

    public void Collect3xButonu()
    {
        _coinsController.CollectCoins3x();
        DusmanControl._yereCarpti = false;
        _uiController.WinScreenClose();
    }
}
