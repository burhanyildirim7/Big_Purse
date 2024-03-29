using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ElephantSDK;


public class LevelController : MonoBehaviour
{
    [SerializeField] private float _maksimumFirlatmaKuvveti;

    [SerializeField] private CameraMovement _cameraMovement;

    [SerializeField] private CoinsController _coinsController;

    [SerializeField] private UIController _uiController;

    [SerializeField] private List<GameObject> _levelPrefabs = new List<GameObject>();

    [SerializeField] private List<float> _toplanmasiGerekenEsyaSayisi = new List<float>();

    [SerializeField] private List<GameObject> _playerPrefabs = new List<GameObject>();

    [SerializeField] private List<GameObject> _enemyPrefabs = new List<GameObject>();

    // [SerializeField] private List<GameObject> _enemySpawnPoints = new List<GameObject>();

    // [SerializeField] private List<GameObject> _normalLevelPrefabs = new List<GameObject>();

    // [SerializeField] private List<GameObject> _bonusLevelPrefabs = new List<GameObject>();

    private GameObject _spawnPoint;

    private int _levelNumarasi;

    private float _toplananEsyaSayisi;

    private float _esyaOrani;

    public static float _dusmaniFirlatmaKuvveti;

    private GameObject _playerObject;

    private GameController _gameController;

    private DusmanControl _dusmanControl;

    private GameObject _enemyObject;

    private PlayerController _playerController;

    // private int _enemySpawnNumber;

    private int _playerNumber;

    private int _enemyNumber;

    private int _randomLevelNumarasi;

    private int _randomBonusLevelNumarasi;

    private int _bonusLevelSayac;
    private float _bosnusLevelMod;

    private GameObject _aktifLevelPrefab;

    private int _levellerTamamlandi;

    private int geciciLevelNum;



    void Start()
    {
        //PlayerPrefs.SetInt("PlayerNumber", 0);
        //PlayerPrefs.SetInt("LevelNumarasi", 0);
        //PlayerPrefs.SetInt("LevellerTamamlandi", 0);
        _toplananEsyaSayisi = 0;
        // _enemySpawnNumber = 0;
        // PlayerPrefs.SetInt("LevelNumarasi", 0);
        // PlayerPrefs.SetInt("PlayerNumber", 0);
        _playerNumber = PlayerPrefs.GetInt("PlayerNumber");
        _playerPrefabs[_playerNumber].SetActive(true);
        //_enemyPrefabs[_playerNumber].SetActive(true);
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
        _randomLevelNumarasi = PlayerPrefs.GetInt("RandomLevelNumarasi");
        _randomBonusLevelNumarasi = PlayerPrefs.GetInt("RandomBonusLevelNumarasi");
        _bonusLevelSayac = PlayerPrefs.GetInt("BonusLevelSayac");
        // _aktifLevelPrefab = GameObject.FindGameObjectWithTag("LevelPrefab");
        _levellerTamamlandi = PlayerPrefs.GetInt("LevellerTamamlandi");

        

       

        // BaslangicLevelAcma();
        //_levelPrefabs[_levelNumarasi].SetActive(true);
        // _aktifLevelPrefab.SetActive(true);

        _aktifLevelPrefab = Instantiate(_levelPrefabs[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);

        /*
        GameObject _cantalar1;

        _cantalar1 = GameObject.Find("Cantalar" + (_levelNumarasi + 1));
        for (int a = 0; a < _cantalar1.transform.childCount; a++)
        {
            _cantalar1.transform.GetChild(a).GetChild(_playerNumber + 1).gameObject.SetActive(true);
        }
        */

        //_enemyObject.transform.position = new Vector3(0, _enemySpawnPoints[_levelNumarasi].transform.position.y, _enemySpawnPoints[_levelNumarasi].transform.position.z);
       // _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
       // _enemyObject.transform.position = new Vector3(0, _spawnPoint.transform.position.y, _spawnPoint.transform.position.z);
    }

  
    public void DusmanYenile()
    {
        _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
        _enemyObject = GameObject.FindGameObjectWithTag("Enemy");

        

    }

    

    public void ToplananEsyaSayisi()
    {
        _toplananEsyaSayisi += 1;
       // Debug.Log("TOPLADI" + _toplananEsyaSayisi.ToString());
    }

    public void EksilenEsyaSayisi()
    {
        _toplananEsyaSayisi -= 1;
        if (_toplananEsyaSayisi == -2)
        {
            _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            _playerController.PlayerDusme();
        }
    }

    public void DusmanaUygulanacakKuvvet()
    {
        
        _esyaOrani = (_toplananEsyaSayisi / _toplanmasiGerekenEsyaSayisi[_levelNumarasi]) * 100;

        if (_esyaOrani >= 20)
        {
            _dusmaniFirlatmaKuvveti = _maksimumFirlatmaKuvveti * (_toplananEsyaSayisi / _toplanmasiGerekenEsyaSayisi[_levelNumarasi]);
          
        }
        else
        {
            _dusmaniFirlatmaKuvveti = 50;
        }

        if (_esyaOrani >= 100)
        {
            _dusmaniFirlatmaKuvveti = _maksimumFirlatmaKuvveti;
            
        }
        

       // _dusmaniFirlatmaKuvveti = _deger;

    }

    public void CollectButonu()
    {
        _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
        _enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        _coinsController.CollectCoins();

        if (_toplananEsyaSayisi >= -1 )
        {
                Elephant.LevelCompleted(_levelNumarasi + 1);
                _uiController.WinScreenClose();
                DusmanControl._yereCarpti = false;
                PlayerDegistir();
                LevelDegistir();

        }
        else
        {
            Elephant.LevelFailed(_levelNumarasi + 1);

                SceneManager.LoadScene(1);

            
        }
                
        _cameraMovement.KameraPozisyonResetle();
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _playerObject.transform.position = new Vector3(0, 0.5f, 5);
        _playerObject.transform.eulerAngles = new Vector3(0, 0, 0);
        _dusmanControl.EnemyAnimatorBaslat();
        GameController._oyunAktif = false;
        AnimationControl._yolSonuKontrol = false;
        _playerObject.SetActive(false);
        _playerObject.SetActive(true);
        _gameController.ConfettileriDurdur();
        AnimationControl._dusmaniFirlat = false;
        if (_toplananEsyaSayisi >= -1)
        {

                _uiController.UILevelNumber();


        }
        else
        {
            PlayerPrefs.SetInt("Devam",1);
            
        }
        _toplananEsyaSayisi = 0;

        

    }

    public void Collect3xButonu()
    {
        _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
        _enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        _coinsController.CollectCoins3x();
        _uiController.WinScreenClose();
        DusmanControl._yereCarpti = false;  
        // _cantalar = GameObject.Find("Cantalar");
        PlayerDegistir();
        LevelDegistir();
        _cameraMovement.KameraPozisyonResetle();
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _playerObject.transform.position = new Vector3(0, 0.5f, 5);
        _playerObject.transform.eulerAngles = new Vector3(0, 0, 0);
        // _enemySpawnNumber++;
        //_enemyObject.transform.position = new Vector3(0, _enemySpawnPoints[_levelNumarasi].transform.position.y, _enemySpawnPoints[_levelNumarasi].transform.position.z);
        //_spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
       // _enemyObject.transform.position = new Vector3(0, _spawnPoint.transform.position.y, _spawnPoint.transform.position.z);
        _dusmanControl.EnemyAnimatorBaslat();
        GameController._oyunAktif = false;
        AnimationControl._yolSonuKontrol = false;
        _playerObject.SetActive(false);
        _playerObject.SetActive(true);
        _gameController.ConfettileriDurdur();
        // _dusmanControl.KameralariNormaleDondur();
        _toplananEsyaSayisi = 0;
        AnimationControl._dusmaniFirlat = false;
        _uiController.UILevelNumber();

        Elephant.LevelCompleted(_levelNumarasi + 1);

        


    }

    

    private void LevelDegistir()
    {
        _levellerTamamlandi = PlayerPrefs.GetInt("LevellerTamamlandi");
        /*
                _cantalar = GameObject.Find("Cantalar");
                for (int a = 0; a < _cantalar.transform.childCount; a++)
                {
                    _cantalar.transform.GetChild(a).GetChild(_playerNumber + 1).gameObject.SetActive(false);
                }
        */
        if (_levelNumarasi >= 14)
        {
            _levellerTamamlandi = 1;
            PlayerPrefs.SetInt("LevellerTamamlandi", _levellerTamamlandi);
        }
        else
        {

        }

        if (_levellerTamamlandi != 1)
        {


            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
            // _aktifLevelPrefab = GameObject.FindGameObjectWithTag("LevelPrefab");
            // _aktifLevelPrefab.SetActive(false);
            Destroy(_aktifLevelPrefab);
            _levelNumarasi++;
            _aktifLevelPrefab = Instantiate(_levelPrefabs[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);   
            // _levelPrefabs[_levelNumarasi].SetActive(true);
            PlayerPrefs.SetInt("LevelNumarasi", _levelNumarasi);


        }
        else
        {
           // Debug.Log("Elsete");
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
            //  _aktifLevelPrefab = GameObject.FindGameObjectWithTag("LevelPrefab");
            //  _aktifLevelPrefab.SetActive(false);
            Destroy(_aktifLevelPrefab);


            geciciLevelNum = Random.Range(5, 15);
            if (geciciLevelNum != 5 && geciciLevelNum != 10 && geciciLevelNum != 15)
            {
                _bonusLevelSayac++;
                PlayerPrefs.SetInt("BonusLevelSayac", _bonusLevelSayac);
              //  Debug.Log(_bonusLevelSayac);
                _bosnusLevelMod = _bonusLevelSayac % 5;

                if (_bosnusLevelMod == 0)
                {
                    _bonusLevelSayac = 0;
                    PlayerPrefs.SetInt("BonusLevelSayac", _bonusLevelSayac);
                    geciciLevelNum = Random.Range(1, 3);
                    _levelNumarasi = (geciciLevelNum * 5) - 1;
                    // _levelNumarasi = 3;
                    _aktifLevelPrefab = Instantiate(_levelPrefabs[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
                  //  Debug.Log("Leveli yukledi");
                    // _levelPrefabs[_levelNumarasi].SetActive(true);
                    PlayerPrefs.SetInt("LevelNumarasi", _levelNumarasi);

                }
                else
                {
                    _levelNumarasi = geciciLevelNum - 1;
                    // _levelNumarasi = 3;
                    _aktifLevelPrefab = Instantiate(_levelPrefabs[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
                  //  Debug.Log("Leveli yukledi");
                    // _levelPrefabs[_levelNumarasi].SetActive(true);
                    PlayerPrefs.SetInt("LevelNumarasi", _levelNumarasi);
                }
            }
            else
            {
                LevelDegistir();
            }
        }


    }

    private void BaslangicLevelAcma()
    {

        /*
        _cantalar = GameObject.Find("Cantalar");
        for (int a = 0; a < _cantalar.transform.childCount; a++)
        {
            _cantalar.transform.GetChild(a).GetChild(_playerNumber + 1).gameObject.SetActive(true);
        }
        */

        _levellerTamamlandi = PlayerPrefs.GetInt("LevellerTamamlandi");

        if (_levelNumarasi <= 14)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
            // _aktifLevelPrefab.SetActive(false);
            // _levelNumarasi++;
            if (_levelNumarasi <= 14)
            {
                _levelPrefabs[_levelNumarasi].SetActive(true);
                PlayerPrefs.SetInt("LevelNumarasi", _levelNumarasi);
            }
            else
            {
                _levelPrefabs[_levelNumarasi].SetActive(true);
                PlayerPrefs.SetInt("LevelNumarasi", _levelNumarasi);
                //LevelDegistir();
            }

        }
        else
        {
            /*
            if (_bonusLevelSayac <= 4)
            {
                _randomLevelNumarasi = PlayerPrefs.GetInt("RandomLevelNumarasi");
               // _aktifLevelPrefab.SetActive(false);
               // _randomLevelNumarasi = Random.Range(0, 8);
                _normalLevelPrefabs[_randomLevelNumarasi].SetActive(true);
                PlayerPrefs.SetInt("RandomLevelNumarasi", _randomLevelNumarasi);
                _bonusLevelSayac = PlayerPrefs.GetInt("BonusLevelSayac");
               // _bonusLevelSayac++;
                PlayerPrefs.SetInt("BonusLevelSayac", _bonusLevelSayac);
            }
            else
            {
                _randomBonusLevelNumarasi = PlayerPrefs.GetInt("RandomLevelNumarasi");
               // _aktifLevelPrefab.SetActive(false);
               // _randomBonusLevelNumarasi = Random.Range(0, 2);
                _bonusLevelPrefabs[_randomBonusLevelNumarasi].SetActive(true);
                PlayerPrefs.SetInt("RandomBonusLevelNumarasi", _randomBonusLevelNumarasi);
                _bonusLevelSayac = PlayerPrefs.GetInt("BonusLevelSayac");
               // _bonusLevelSayac = 0;
                PlayerPrefs.SetInt("BonusLevelSayac", _bonusLevelSayac);
            }
            */
        }


    }

    private void PlayerDegistir()
    {


        if (_playerNumber == 3)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
            _playerNumber = PlayerPrefs.GetInt("PlayerNumber");
            _enemyObject = GameObject.FindGameObjectWithTag("Enemy");
            Destroy(_enemyObject);
            _playerPrefabs[_playerNumber].SetActive(false);
            _playerNumber = 0;
            _playerPrefabs[_playerNumber].SetActive(true);
            
            //_enemyPrefabs[_playerNumber].SetActive(true);
            PlayerPrefs.SetInt("PlayerNumber", _playerNumber);
            /*
            PlayerPrefs.SetInt("PlayerNumber", _playerNumber);
            GameObject _cantalar;
            _cantalar = GameObject.Find("Cantalar" + (_levelNumarasi + 1));
            Debug.Log("Cantalar" + (_levelNumarasi + 1));
            for (int a = 0; a < _cantalar.transform.childCount; a++)
            {
                Debug.Log("Forda canta acma oncesi");
                _cantalar.transform.GetChild(a).GetChild(_playerNumber + 1).gameObject.SetActive(true);
                Debug.Log("Forda canta acma sonrasi");
            }
            */
            // _cantalar = GameObject.Find("Cantalar");

        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
            _playerNumber = PlayerPrefs.GetInt("PlayerNumber");
            _enemyObject = GameObject.FindGameObjectWithTag("Enemy");
            Destroy(_enemyObject);
            //_enemyPrefabs[_playerNumber].SetActive(false);
            _playerPrefabs[_playerNumber].SetActive(false);
            _playerNumber++;
            _playerPrefabs[_playerNumber].SetActive(true);
            //Instantiate(_enemyPrefabs[_playerNumber], new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
            //_enemyPrefabs[_playerNumber].SetActive(true);
            PlayerPrefs.SetInt("PlayerNumber", _playerNumber);
            /*
            PlayerPrefs.SetInt("PlayerNumber", _playerNumber);
            GameObject _cantalar;
            _cantalar = GameObject.Find("Cantalar" + (_levelNumarasi + 1));
            Debug.Log("Cantalar" + (_levelNumarasi + 1));
            for (int a = 0; a < _cantalar.transform.childCount; a++)
            {
                Debug.Log("Forda canta acma oncesi");
                _cantalar.transform.GetChild(a).GetChild(_playerNumber + 1).gameObject.SetActive(true);
                Debug.Log("Forda canta acma sonrasi");
            }
            */

        }

    }

    


}
