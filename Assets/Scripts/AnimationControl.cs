using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    //public Animator playerAnimator;
    int hitType = 0;
    [SerializeField] private GameObject _purse;

    private DusmanControl _dusmanControl;

    [SerializeField] private LevelController _levelController;

    [SerializeField] private ParticleSystem _moneyEffect;
    [SerializeField] private GameObject _moneyEffectObject;

    [SerializeField] private GameObject _purseObject;

    private int _hitNumber = 0;

    public static bool _firlatmaKuvvetiUygula;

    public static bool _dusmaniFirlat;

    public static bool _yolSonuKontrol;

    private Vector3 _purseBoyutu;

    private float _purseBoyutX;

    [SerializeField] private PlayerController _playerController;

    private EnemyAnimatorController _enemyAnimatorController;

    // [SerializeField] private Rigidbody _enemyRigidbody;




    private void Start()
    {
        _yolSonuKontrol = false;
        _dusmaniFirlat = false;
        _firlatmaKuvvetiUygula = false;

        _enemyAnimatorController = GameObject.FindWithTag("Enemy").GetComponent<EnemyAnimatorController>();
        _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();



    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _yolSonuKontrol == true && LevelController._dusmaniFirlatmaKuvveti > 0)
        {
            HitAnim();

        }
        else
        {
            _playerController.HitleriKapat();
            _enemyAnimatorController.EnemyHitleriKapat();
        }

        _purseBoyutX = _purse.gameObject.transform.localScale.x;
    }

    private void FixedUpdate()
    {
        if (_firlatmaKuvvetiUygula == true && _yolSonuKontrol == true && _dusmaniFirlat == false && LevelController._dusmaniFirlatmaKuvveti > 0)
        {
            _dusmaniFirlat = true;
            _firlatmaKuvvetiUygula = false;
            // _purse.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
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

            _moneyEffectObject.transform.position = _purseObject.transform.position;


            hitType = Random.Range(1, 4);

            Debug.Log(hitType);
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
        _playerController.PlayerHit1();
        yield return new WaitForSeconds(0.3f);
        _enemyAnimatorController.EnemyHit1();
        _moneyEffect.Play();

    }

    IEnumerator PlayerHitType2()
    {
        _playerController.PlayerHit2();
        yield return new WaitForSeconds(0.3f);
        _enemyAnimatorController.EnemyHit2();
        _moneyEffect.Play();

    }

    IEnumerator PlayerHitType3()
    {
        Time.timeScale = 0.5f;
        _playerController.PlayerHit3();
        yield return new WaitForSeconds(0.5f);
        _enemyAnimatorController.EnemyHit3();
        _moneyEffect.Play();
        yield return new WaitForSeconds(0.1f);
        _firlatmaKuvvetiUygula = true;
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "YolSonu")
        {
            Debug.Log("YolSonu");
            _playerController.PlayerZipla();
            GameController._oyunAktif = false;
            _dusmaniFirlat = false;
            _levelController.DusmanaUygulanacakKuvvet();
            //JumpAnim();
            _yolSonuKontrol = true;
        }
    }



}
