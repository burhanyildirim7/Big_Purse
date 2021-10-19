using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private ParticleSystem _moneyEffect;
    [SerializeField] private GameObject _moneyEffectObject;

    [SerializeField] private ParticleSystem _angryEmojiEffect;
    [SerializeField] private GameObject _angryEmojiObject;

    [SerializeField] private ParticleSystem _happyEmojiEffect;
    [SerializeField] private GameObject _happyEmojiObject;

    [SerializeField] private ParticleSystem _windEffect;
    [SerializeField] private GameObject _windObject;

    [SerializeField] private GameObject _purseObject;

    [SerializeField] private LevelController _levelController;

    [SerializeField] private Animator _playerAnimator;

    Rigidbody p_Rigidbody;

    [SerializeField] private float _ziplamaDegeri;

    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private CameraShake _cameraShake;


    private HareketliZemin _hareketliZemin;

    // [SerializeField] private GameObject _duvarYikmaKuresi;

    [SerializeField] private GameObject _yikmaObject;
    [SerializeField] private GameObject _moneyPurseObject;

    private UIController _uiController;

    private CoinsController _coinsController;

    private GameObject _purse;

    private float _purseBoyutX;
    private int _playerNumber;
    public static bool _artiBirAktif;
    public static bool _eksiBirAktif;
    void Start()
    {
        _artiBirAktif = false;
        _eksiBirAktif = false;
        p_Rigidbody = GetComponent<Rigidbody>();
        _uiController = GameObject.FindWithTag("UiController").GetComponent<UIController>();
        _coinsController = GameObject.FindWithTag("CoinsController").GetComponent<CoinsController>();
        _purse = GameObject.FindGameObjectWithTag("Purse");
        _purseObject.SetActive(false);
        // _purseObject = GameObject.FindGameObjectWithTag("Purse");

    }


    void Update()
    {
        _angryEmojiObject.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        _happyEmojiObject.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        _purseBoyutX = _purseObject.gameObject.transform.localScale.x;
        // _duvarYikmaKuresi.transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z + 3f);
        _windObject.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DegerliEsya")
        {
            _playerNumber = PlayerPrefs.GetInt("PlayerNumber");
            _artiBirAktif = true;
            if (_playerNumber == 2)
            {
                _purseObject.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                _purseObject.gameObject.transform.localPosition -= new Vector3(0, 0.08f, 0.15f);
            }
            else
            {
                _purseObject.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                _purseObject.gameObject.transform.localPosition -= new Vector3(0, 0.16f, 0.32f);
            }
            //_playerPurse.gameObject.transform.localScale += Vector3.Lerp(transform.localScale, new Vector3(0.1f, 0.1f, 0.1f), Time.deltaTime * 0.1f);

            _levelController.ToplananEsyaSayisi();
            _happyEmojiEffect.Play();

            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "DegersizEsya")
        {
            if (_purseBoyutX >= 1.1f)
            {
                _playerNumber = PlayerPrefs.GetInt("PlayerNumber");

                if (_playerNumber == 2)
                {
                    _purseObject.gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                    _purseObject.gameObject.transform.localPosition += new Vector3(0, 0.08f, 0.15f);
                }
                else
                {
                    _purseObject.gameObject.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
                    _purseObject.gameObject.transform.localPosition += new Vector3(0, 0.16f, 0.32f);
                }
 
            }
            _eksiBirAktif = true;
            _levelController.EksilenEsyaSayisi();
            _moneyEffectObject.transform.position = _moneyPurseObject.transform.position;
            _moneyEffect.Play();
            _angryEmojiEffect.Play();
            _playerAnimator.SetBool("tokezle", true);
            _playerMovement.PlayerHiziniDusur();
            Invoke("TokezleIptal", 1);


            // Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "DurmaZemini")
        {
            PlayerMovement._playerHareket = false;
            _hareketliZemin = GameObject.FindWithTag("HareketliZemin").GetComponent<HareketliZemin>();
            _hareketliZemin.ZeminiKaldir();
            Invoke("PlayerTekrarHareket", 1);
        }
        else if (other.gameObject.tag == "ZiplamaZemini")
        {
            p_Rigidbody.AddForce(transform.up * (_ziplamaDegeri * Time.fixedDeltaTime), ForceMode.Impulse);
            p_Rigidbody.AddForce(transform.forward * (_ziplamaDegeri * Time.fixedDeltaTime), ForceMode.Impulse);
            _windEffect.Play();
            StartCoroutine(PlayerUcusAnimasyonKontrol());
        }
        else if (other.gameObject.tag == "YikmaSinir")
        {
            _playerMovement.PlayerHiziniDusur();
            StartCoroutine(PlayerKinematicKontrol());
            _playerAnimator.SetBool("attack", true);
            Instantiate(_yikmaObject, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
            _cameraShake.ShakeOnce();
            Invoke("AttackIptal", 0.5f);

        }
        else if (other.gameObject.tag == "MerdivenBaslangici")
        {
            _playerMovement.PlayerHiziniDusur();
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            PlayerMovement._playerMerdivende = true;

        }
        else if (other.gameObject.tag == "Hirsiz")
        {
            if (_purseBoyutX >= 1.1f)
            {
                _playerNumber = PlayerPrefs.GetInt("PlayerNumber");

                if (_playerNumber == 2)
                {
                    _purseObject.gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                    _purseObject.gameObject.transform.localPosition += new Vector3(0, 0.08f, 0.15f);
                }
                else
                {
                    _purseObject.gameObject.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
                    _purseObject.gameObject.transform.localPosition += new Vector3(0, 0.16f, 0.32f);
                }

            }
            _eksiBirAktif = true;
            _levelController.EksilenEsyaSayisi();
            _moneyEffectObject.transform.position = _moneyPurseObject.transform.position;
            _moneyEffect.Play();
            _angryEmojiEffect.Play();
            _playerAnimator.SetBool("tokezle", true);
            _playerMovement.PlayerHiziniDusur();
            Invoke("TokezleIptal", 1);
        }
        else
        {
            _moneyEffect.Stop();
            _windEffect.Stop();
        }

    }

    public void PlayerDusme()
    {
        _uiController = GameObject.FindWithTag("UiController").GetComponent<UIController>();
        StartCoroutine(PlayerDusmeAnimasyonKontrol());
        _coinsController = GameObject.FindWithTag("CoinsController").GetComponent<CoinsController>();
        _coinsController.OyunSonuCoinsHesapla(10);
       // _purse = GameObject.FindGameObjectWithTag("Purse");

        _purseObject.SetActive(false);
        _uiController.LoseScreenOpen();

    }

    IEnumerator PlayerDusmeAnimasyonKontrol()
    {

        _playerAnimator.SetBool("dusme", true);
        yield return new WaitForSeconds(1f);
        GameController._oyunAktif = false;


    }

    IEnumerator PlayerUcusAnimasyonKontrol()
    {

        _playerAnimator.SetBool("ucus", true);
        _playerAnimator.SetBool("yuru", false);
        yield return new WaitForSeconds(3f);
        _playerAnimator.SetBool("ucus", false);
        _playerAnimator.SetBool("yuru", true);


    }

    IEnumerator PlayerKinematicKontrol()
    {

        p_Rigidbody.isKinematic = true;
        yield return new WaitForSeconds(1f);
        p_Rigidbody.isKinematic = false;

    }

    private void PlayerTekrarHareket()
    {
        PlayerMovement._playerHareket = true;
    }

    public void PlayerYurume()
    {
        //_playerAnimator.SetBool("zipla", false);
        p_Rigidbody.isKinematic = false;
        _playerAnimator.SetBool("yuru", true);
        _purseObject.SetActive(true);

    }

    public void PlayerZipla()
    {
        _playerAnimator.SetBool("zipla", true);
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 5f);
        p_Rigidbody.isKinematic = true;
    }

    private void TokezleIptal()
    {
        _playerAnimator.SetBool("tokezle", false);
        _playerMovement.PlayerHiziniArtir();
    }

    private void AttackIptal()
    {
        _playerAnimator.SetBool("attack", false);
        _playerMovement.PlayerHiziniArtir();

    }

    public void PlayerHit1()
    {
        _playerAnimator.SetBool("vurus1", true);
        _playerAnimator.SetBool("vurus2", false);
        _playerAnimator.SetBool("vurus3", false);
    }

    public void PlayerHit2()
    {
        _playerAnimator.SetBool("vurus2", true);
        _playerAnimator.SetBool("vurus1", false);
        _playerAnimator.SetBool("vurus3", false);
    }

    public void PlayerHit3()
    {
        _playerAnimator.SetBool("vurus3", true);
        _playerAnimator.SetBool("vurus1", false);
        _playerAnimator.SetBool("vurus2", false);
    }

    public void HitleriKapat()
    {
        _playerAnimator.SetBool("vurus1", false);
        _playerAnimator.SetBool("vurus2", false);
        _playerAnimator.SetBool("vurus3", false);
    }

    public void DansAnimasyonBaslat()
    {
        _playerAnimator.SetBool("dans", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CounterEsya")
        {
            if (_purseBoyutX >= 1.1f)
            {
                _playerNumber = PlayerPrefs.GetInt("PlayerNumber");

                if (_playerNumber == 2)
                {
                    _purseObject.gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                    _purseObject.gameObject.transform.localPosition += new Vector3(0, 0.08f, 0.15f);
                }
                else
                {
                    _purseObject.gameObject.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
                    _purseObject.gameObject.transform.localPosition += new Vector3(0, 0.16f, 0.32f);
                }

            }
            _eksiBirAktif = true;
            Destroy(collision.gameObject);
            _levelController.EksilenEsyaSayisi();

        }
        else
        {

        }


    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ZiplamaZemini")
        {
            p_Rigidbody.AddForce(transform.up * (_ziplamaDegeri * Time.deltaTime), ForceMode.Impulse);
            p_Rigidbody.AddForce(transform.forward * (_ziplamaDegeri * Time.deltaTime), ForceMode.Impulse);
        }
        else if (collision.gameObject.tag == "DurmaZemini")
        {
            PlayerMovement._playerHareket = false;
            Invoke("PlayerTekarHareket", 3);
        }
    }
    */



    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "DegersizEsya")
        {
            _engelTrailEffect.Play();
        }
        else
        {
            _engelTrailEffect.Pause();
        }
    }
    */
}
