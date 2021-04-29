using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    //public Animator playerAnimator;
    int hitType = 0;
    [SerializeField] private GameObject _purse;

    [SerializeField] private DusmanControl _dusmanControl;

    [SerializeField] private LevelController _levelController;

    [SerializeField] private ParticleSystem _moneyEffect;
    [SerializeField] private GameObject _moneyEffectObject;

    [SerializeField] private GameObject _purseObject;

    public static bool _dusmaniFirlat;

    public static bool _yolSonuKontrol;

    private Vector3 _purseBoyutu;

    private float _purseBoyutX;

    [SerializeField] private PlayerController _playerController;

    [SerializeField] private EnemyAnimatorController _enemyAnimatorController;




    private void Start()
    {
        _yolSonuKontrol = false;
        _dusmaniFirlat = false;


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
        if (_purseBoyutX <= 0.32f && _yolSonuKontrol == true && _dusmaniFirlat == false && LevelController._dusmaniFirlatmaKuvveti > 0)
        {
            _dusmaniFirlat = true;
            _purse.gameObject.transform.localScale = new Vector3(0.32f, 0.32f, 0.32f);
            _dusmanControl.DusamaniFirlatma(LevelController._dusmaniFirlatmaKuvveti);

        }
        else
        {

        }
    }


    public void HitAnim()
    {
        if (hitType == 0 && _dusmaniFirlat == false)
        {

            _moneyEffectObject.transform.position = _purseObject.transform.position;
            

            hitType = Random.Range(1, 4);
            Debug.Log(hitType);
            if (hitType == 1)
            {
                //playerAnimator.SetTrigger("bir");
                _playerController.PlayerHit1();
                _enemyAnimatorController.EnemyHit1();
                _moneyEffect.Play();
            }
            else if (hitType == 2)
            {
                // playerAnimator.SetTrigger("iki");
                _playerController.PlayerHit3();
                _enemyAnimatorController.EnemyHit2();
                _moneyEffect.Play();
            }
            else
            {
                // playerAnimator.SetTrigger("uc");
                _playerController.PlayerHit2();
                _enemyAnimatorController.EnemyHit3();
                _moneyEffect.Play();
            }
            _purse.gameObject.transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
            _purse.gameObject.transform.localPosition -= new Vector3(0, 0.02f, 0);

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
        yield return new WaitForSeconds(.6f);
        hitType = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "YolSonu")
        {
            Debug.Log("YolSonu");
            _playerController.PlayerZipla();
            GameController._oyunAktif = false;
            _levelController.DusmanaUygulanacakKuvvet();
            //JumpAnim();
            _yolSonuKontrol = true;
        }
    }



}
