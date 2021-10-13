using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Animations;

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

    [SerializeField] private GameObject _gücSliderObject;

    [SerializeField] private GameObject _gücSliderAnimation;

    private float _firlatmaDegeri;

    private bool _gücBariAcik;



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
        _gücSliderObject.SetActive(false);
        _gücBariAcik = false;
       // _enemyAnimatorController = GameObject.FindWithTag("Enemy").GetComponent<EnemyAnimatorController>();
       // _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
       // _enemyObject = GameObject.FindGameObjectWithTag("Enemy");
       // _purseObject = GameObject.FindGameObjectWithTag("Purse");



    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _yolSonuKontrol == true && _gücBariAcik == true)
        {
            StartCoroutine(HitAnim());

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


    IEnumerator HitAnim()
    {
        if (_dusmaniFirlat == false)
        {
            _gücSliderAnimation.GetComponent<Animator>().enabled = false;

            _moneyEffectObject.transform.position = _moneyPurseObject.transform.position;

            _gücBariAcik = false;

            GücHesapla();

            _levelController.DusmanaUygulanacakKuvvet(_firlatmaDegeri);



            yield return new WaitForSeconds(1f);

            _gücSliderObject.SetActive(false);


            StartCoroutine(PlayerHitType1());

            yield return new WaitForSeconds(1f);

            StartCoroutine(PlayerHitType2());

            yield return new WaitForSeconds(1f);

            StartCoroutine(PlayerHitType3());
              
          
           
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
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 1.2f;
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "YolSonu")
        {
            _gücBariAcik = true;
            // Debug.Log("YolSonu");
            _gücSliderObject.SetActive(true);
            _gücSliderAnimation.GetComponent<Animator>().enabled = true;
            _playerController.PlayerZipla();
            GameController._oyunAktif = false;
            _dusmaniFirlat = false;
            // _firlatmaDegeri = 50;
            
            
            //JumpAnim();
            _yolSonuKontrol = true;
        }
    }



    private void GücHesapla()
    {

        float aci = _gücSliderAnimation.transform.eulerAngles.z;

       // Debug.Log("Transform Euler Rotation : " + aci);


        _firlatmaDegeri = 50 + (((30 - Mathf.Abs(aci))) * (14 / 3));


    }


}
