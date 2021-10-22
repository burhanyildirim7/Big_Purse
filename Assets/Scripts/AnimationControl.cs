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

    [SerializeField] private GameObject _tapTapText;

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

    private bool _hitBekle;

    

    // [SerializeField] private Rigidbody _enemyRigidbody;




    private void Start()
    {
        _yolSonuKontrol = false;
        _dusmaniFirlat = false;
        _firlatmaKuvvetiUygula = false;
        _gücSliderObject.SetActive(false);
        _tapTapText.SetActive(false);
        _hitBekle = false;
        //_gücBariAcik = false;
        // _enemyAnimatorController = GameObject.FindWithTag("Enemy").GetComponent<EnemyAnimatorController>();
        // _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
        // _enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        // _purseObject = GameObject.FindGameObjectWithTag("Purse");



    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _yolSonuKontrol == true && _dusmaniFirlat == false && _hitBekle == false)
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
        if (_firlatmaKuvvetiUygula == true && _yolSonuKontrol == true && _dusmaniFirlat == false)
        {
            _dusmanControl = GameObject.FindWithTag("Enemy").GetComponent<DusmanControl>();
            _dusmaniFirlat = true;
            _purseObject.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            _purseObject.gameObject.transform.localPosition = new Vector3(0, -0.637f, -1.493f);
            //_purse.transform.eulerAngles = new Vector3(210, 172, 4);
            _dusmanControl.DusamaniFirlatma(LevelController._dusmaniFirlatmaKuvveti);
            _firlatmaKuvvetiUygula = false;
            _hitNumber = 0;
            Debug.Log("Fırlatma Degeri : " + LevelController._dusmaniFirlatmaKuvveti);
            Debug.Log("Fixed Update Tamamlandı");


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


    private void HitAnim()
    {
        if (_dusmaniFirlat == false)
        {
            _gücSliderAnimation.GetComponent<Animator>().enabled = false;

            _moneyEffectObject.transform.position = _moneyPurseObject.transform.position;

            // _gücBariAcik = false;

            //GücHesapla();

            //_levelController.DusmanaUygulanacakKuvvet(_firlatmaDegeri);

            StartCoroutine(HitBekle());

            //yield return new WaitForSeconds(1f);

            //_gücSliderObject.SetActive(false);

            if (_hitNumber == 0)
            {
                StartCoroutine(PlayerHitType1());
                _hitNumber++;
                _hitBekle = true;
            }
            else if (_hitNumber == 1)
            {
                StartCoroutine(PlayerHitType2());
                _hitNumber++;
                _hitBekle = true;
            }
            else if (_hitNumber == 2)
            {
                StartCoroutine(PlayerHitType3());
                _tapTapText.SetActive(false);
                _hitNumber = 0;
            }
            else
            {

            }

            


            // yield return new WaitForSeconds(1f);



            // yield return new WaitForSeconds(1f);





        }
        else
        {
            //_moneyEffect.Stop();
        }

    }


    IEnumerator HitBekle()
    {
        
        yield return new WaitForSeconds(1f);

        _hitBekle = false;

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
        Time.timeScale = 1f;
        _playerController.PlayerHit3();
        yield return new WaitForSeconds(0.35f);
        //_enemyAnimatorController.EnemyHit3();
        //_cameraShake.ShakeOnce();
        _moneyEffect.Play();
        _firlatmaKuvvetiUygula = true;
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 1.5f;
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "YolSonu")
        {
            //_gücBariAcik = true;
            // Debug.Log("YolSonu");
            //_gücSliderObject.SetActive(true);
            //_gücSliderAnimation.GetComponent<Animator>().enabled = true;
            _levelController.DusmanaUygulanacakKuvvet();
            _playerController.PlayerZipla();
            GameController._oyunAktif = false;
            _dusmaniFirlat = false;
            _tapTapText.SetActive(true);
            // _firlatmaDegeri = 50;


            //JumpAnim();
            _yolSonuKontrol = true;
        }
    }



    private void GücHesapla()
    {

        float aci = _gücSliderAnimation.transform.eulerAngles.z;

        

        // Debug.Log("Transform Euler Rotation : " + aci);
        if (aci < 40)
        {
            _firlatmaDegeri = 50 + (((30 - (Mathf.Abs(aci)))) * (14 / 3));
        }
        else
        {
            aci = 360 - aci;
            _firlatmaDegeri = 50 + (((30 - (Mathf.Abs(aci)))) * (14 / 3));
        }


        Debug.Log("Açı Degeri : " + aci);
        //_firlatmaDegeri = 50 + (((30 - (-aci))) * (14 / 3));




    }


}
