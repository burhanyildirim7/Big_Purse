using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameController : MonoBehaviour
{

    [SerializeField] private UIController _uiController;

    private PlayerController _playerController;

    private AnimationControl _animationControl;

    [SerializeField] private LevelController _levelController;

    // private EnemyCameraMovement _enemyCameraMovement;

    private DusmanControl _dusmanControl;

    [SerializeField] private GameObject _confettiPaket;

    [SerializeField] private ParticleSystem _confetti1;
    [SerializeField] private ParticleSystem _confetti2;

    private GameObject _yolSonuDuvari;

    private GameObject _purse;

    private GameObject _playerObject;

    private PlayerMovement _playerMovement;

    private GameObject _cameraObject;

    public static bool _oyunAktif;

    private GameObject Enemy;

   // [SerializeField] private GameObject _enemyCamera;
    

    void Start()
    {
        _oyunAktif = false;
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _animationControl = GameObject.FindWithTag("Player").GetComponent<AnimationControl>();
        //Enemy = GameObject.FindGameObjectWithTag("Enemy");
        _cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        _purse = GameObject.FindGameObjectWithTag("Purse");
        _yolSonuDuvari = GameObject.FindGameObjectWithTag("OyunSonuDuvari");
       // _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
    }

   

    
    void Update()
    {
        if (_oyunAktif == false && AnimationControl._yolSonuKontrol == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                _uiController.TapToStartScreenClose();
                _uiController.LevelScreenOpen();
                _oyunAktif = true;
                PlayerMovement._playerHareket = true;
                _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
                _animationControl = GameObject.FindWithTag("Player").GetComponent<AnimationControl>();
                _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
                _playerMovement.PlayerHiziniArtir();
                _playerController.PlayerYurume();
                _animationControl.DusmanGuncelle();
                _levelController.DusmanYenile();
                // _enemyCameraMovement.EnemyKameraPozisyonDuzenle();
                _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
                _dusmanControl.EnemyYenile();
                PlayerMovement._playerMerdivende = false;
                // EnemyCameraMovement._enemyKameraTakip = false;
                //  _enemyCamera.transform.position = new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + 20, Enemy.transform.position.z - 20);



            }
            else
            {

            }
        }
        else
        {

        }
    }

    public void PlayerSevinmeOrganizasyon()
    {
        StartCoroutine(PlayerSevinme());
        
    }


    IEnumerator PlayerSevinme()
    {
        Time.timeScale = 1;
        _yolSonuDuvari = GameObject.FindGameObjectWithTag("OyunSonuDuvari");
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _cameraObject.transform.position = new Vector3(0, _yolSonuDuvari.transform.position.y + 15f, _playerObject.transform.position.z - 13);
        _confettiPaket.transform.position = new Vector3(0, _yolSonuDuvari.transform.position.y + 3f, _playerObject.transform.position.z);
       // _playerObject.transform.position = new Vector3(0, _yolSonuDuvari.transform.position.y, _playerObject.transform.position.z);
        _playerObject.transform.eulerAngles = new Vector3(0, 180, 0);
        _purse = GameObject.FindGameObjectWithTag("Purse");
        _purse.SetActive(false);
        _playerController.DansAnimasyonBaslat();
        yield return new WaitForSeconds(0.5f);
        _confetti1.Play();
        _confetti2.Play();
        _oyunAktif = false;

    }

    public void ConfettileriDurdur()
    {
        _confetti1.Stop();
        _confetti2.Stop();
    }
}
