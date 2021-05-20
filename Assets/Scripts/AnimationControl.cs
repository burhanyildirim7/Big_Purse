using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationControl : MonoBehaviour
{
    //public Animator playerAnimator;
    int hitType = 0;
    

    private DusmanControl _dusmanControl;

    [SerializeField] private LevelController _levelController;

    [SerializeField] private ParticleSystem _moneyEffect;
    [SerializeField] private GameObject _moneyEffectObject;

    [SerializeField] private GameObject _purseObject;

    [SerializeField] private CameraShake _cameraShake;

    [SerializeField] private GameObject TapTapText;



    private int _hitNumber = 0;

    public static bool _firlatmaKuvvetiUygula;

    public static bool _dusmaniFirlat;

    public static bool _yolSonuKontrol;

    private Vector3 _purseBoyutu;

    private float _purseBoyutX;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _moneyPurseObject;

    private EnemyAnimatorController _enemyAnimatorController;

    private GameObject _enemyObject;

    // [SerializeField] private Rigidbody _enemyRigidbody;




    private void Start()
    {
        _yolSonuKontrol = false;
        _dusmaniFirlat = false;
        _firlatmaKuvvetiUygula = false;
        TapTapText.SetActive(false);
       // _enemyAnimatorController = GameObject.FindWithTag("Enemy").GetComponent<EnemyAnimatorController>();
       // _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
       // _enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        // _purseObject = GameObject.FindGameObjectWithTag("Purse");



    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _yolSonuKontrol == true && LevelController._dusmaniFirlatmaKuvveti > 1)
        {
            HitAnim();

        }
        else
        {
            _playerController.HitleriKapat();
            _enemyObject = GameObject.FindGameObjectWithTag("Enemy");
            _enemyAnimatorController = GameObject.FindWithTag("Enemy").GetComponent<EnemyAnimatorController>();

            if (_enemyObject != null)
            {
                _enemyAnimatorController.EnemyHitleriKapat();
            }
            else
            {

            }
           
        }

        _purseBoyutX = _purseObject.gameObject.transform.localScale.x;
    }

    private void FixedUpdate()
    {
        if (_firlatmaKuvvetiUygula == true && _yolSonuKontrol == true && _dusmaniFirlat == false && LevelController._dusmaniFirlatmaKuvveti > 1)
        {
            _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
            _dusmaniFirlat = true;
            _firlatmaKuvvetiUygula = false;
            _purseObject.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            _purseObject.gameObject.transform.localPosition = new Vector3(0, -0.637f, -1.493f);
            //_purse.transform.eulerAngles = new Vector3(210, 172, 4);
            _dusmanControl.DusamaniFirlatma(LevelController._dusmaniFirlatmaKuvveti);


        }
        else
        {

        }
    }

    public void DusmanGuncelle()
    {
        _enemyAnimatorController = GameObject.FindWithTag("Enemy").GetComponent<EnemyAnimatorController>();
        _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
    }


    public void HitAnim()
    {
        if (hitType == 0 && _dusmaniFirlat == false)
        {

            _moneyEffectObject.transform.position = _moneyPurseObject.transform.position;


            hitType = Random.Range(1, 4);

           // Debug.Log(hitType);
            if (_hitNumber == 0)
            {
                //playerAnimator.SetTrigger("bir");
                // _playerController.PlayerHit3();
                //  _enemyAnimatorController.EnemyHit1();
                // _moneyEffect.Play();
                StartCoroutine(PlayerHitType1());
                _hitNumber++;
            }
            else if (_hitNumber == 1)
            {
                // playerAnimator.SetTrigger("iki");
                // _playerController.PlayerHit3();
                // _enemyAnimatorController.EnemyHit2();
                // _moneyEffect.Play();
                StartCoroutine(PlayerHitType2());
                _hitNumber++;
            }
            else if (_hitNumber == 2)
            {
                // playerAnimator.SetTrigger("uc");
                // _playerController.PlayerHit3();
                // _enemyAnimatorController.EnemyHit3();
                // _moneyEffect.Play();
                StartCoroutine(PlayerHitType3());
                // _firlatmaKuvvetiUygula = true;
                _hitNumber = 0;
            }
            // _purse.gameObject.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
            // _purse.gameObject.transform.localPosition += new Vector3(0, 0.025f, 0.05f);

            StartCoroutine(DelayHitType());
        }
        else
        {
            //_moneyEffect.Stop();
        }

    }

   


    /*
    public void JumpAnim()
	{
		playerAnimator.SetTrigger("zipla");
	}
	*/
    IEnumerator DelayHitType()
    {
        yield return new WaitForSeconds(1f);
        hitType = 0;
    }

    IEnumerator PlayerHitType1()
    {
        _enemyAnimatorController = GameObject.FindWithTag("Enemy").GetComponent<EnemyAnimatorController>();
        _playerController.PlayerHit1();
        yield return new WaitForSeconds(0.3f);
        _enemyAnimatorController.EnemyHit1();
        _cameraShake.ShakeOnce();
        _moneyEffect.Play();

    }

    IEnumerator PlayerHitType2()
    {
        _enemyAnimatorController = GameObject.FindWithTag("Enemy").GetComponent<EnemyAnimatorController>();
        _playerController.PlayerHit2();
        yield return new WaitForSeconds(0.3f);
        _enemyAnimatorController.EnemyHit2();
        _cameraShake.ShakeOnce();
        _moneyEffect.Play();

    }

    IEnumerator PlayerHitType3()
    {
        Time.timeScale = 0.3f;
        _playerController.PlayerHit3();
        yield return new WaitForSeconds(0.35f);
        //_enemyAnimatorController.EnemyHit3();
        //_cameraShake.ShakeOnce();
        _moneyEffect.Play();
        _firlatmaKuvvetiUygula = true;
        TapTapText.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 1.2f;
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "YolSonu")
        {
           // Debug.Log("YolSonu");
            _playerController.PlayerZipla();
            TapTapText.SetActive(true);
            GameController._oyunAktif = false;
            _dusmaniFirlat = false;
            _levelController.DusmanaUygulanacakKuvvet();
            //JumpAnim();
            _yolSonuKontrol = true;
        }
    }






}
