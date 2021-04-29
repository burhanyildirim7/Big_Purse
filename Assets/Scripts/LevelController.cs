using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private GameObject _playerObject;
    [SerializeField] private GameObject _enemyObject;

    [SerializeField] private DusmanControl _dusmanControl;

    public int _sonrakiSahneLeveli;

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
        SceneManager.LoadScene(_sonrakiSahneLeveli);
        // DusmanControl._yereCarpti = false;
        //_uiController.WinScreenClose();
        // _playerObject.transform.position = new Vector3(0, 0, 5);
        // _enemyObject.transform.position = new Vector3(0, 0, 194);
        // _dusmanControl.KameralariNormaleDondur();
    }

    public void Collect3xButonu()
    {
        _coinsController.CollectCoins3x();
        SceneManager.LoadScene(_sonrakiSahneLeveli);
        //DusmanControl._yereCarpti = false;
        //_uiController.WinScreenClose();
        // _playerObject.transform.position = new Vector3(0, 0, 5);
        // _enemyObject.transform.position = new Vector3(0, 0, 194);
        // _dusmanControl.KameralariNormaleDondur();
    }
}
