using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelPrefabs = new List<GameObject>();
    [SerializeField] private List<float> _toplanmasiGerekenEsyaSayisi = new List<float>();

    private int _levelNumarasi;

    private float _toplananEsyaSayisi;

    [SerializeField] private float _maksimumFirlatmaKuvveti;

    private float _esyaOrani;

    public static float _dusmaniFirlatmaKuvveti;

    [SerializeField] private CoinsController _coinsController;

    [SerializeField] private UIController _uiController;

    [SerializeField] private GameObject _playerObject;

    [SerializeField] private CameraMovement _cameraMovement;

    private DusmanControl _dusmanControl;

    


    void Start()
    {
        _toplananEsyaSayisi = 0;
        _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();

    }

    
    void Update()
    {
        
    }

    public void DusmanYenile()
    {
        _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
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
        _uiController.WinScreenClose();
        DusmanControl._yereCarpti = false;
        _cameraMovement.KameraPzoisyonResetle();
        _playerObject.transform.position = new Vector3(0, 0, 5);
        GameController._oyunAktif = false;
        AnimationControl._yolSonuKontrol = false;
        _playerObject.SetActive(false);
        _playerObject.SetActive(true);
        LevelDegistir();
        _dusmanControl.KameralariNormaleDondur();
        _toplananEsyaSayisi = 0;
    }

    public void Collect3xButonu()
    {
        _coinsController.CollectCoins3x();
        _uiController.WinScreenClose();
        DusmanControl._yereCarpti = false;
        _cameraMovement.KameraPzoisyonResetle();
        _playerObject.transform.position = new Vector3(0, 0, 5);
        GameController._oyunAktif = false;
        AnimationControl._yolSonuKontrol = false;
        _playerObject.SetActive(false);
        _playerObject.SetActive(true);
        LevelDegistir();
        _dusmanControl.KameralariNormaleDondur();
        _toplananEsyaSayisi = 0;
    }

    private void LevelDegistir()
    {
        _levelPrefabs[_levelNumarasi].SetActive(false);
        _levelNumarasi++;
        _levelPrefabs[_levelNumarasi].SetActive(true);

    }
}
