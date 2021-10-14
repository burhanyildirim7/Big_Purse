using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanControl : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    Collider m_Collider;
    public float m_Thrust = 20f;

    private CoinsController _coinsController;

    private GameObject _playerCamera;
    [SerializeField] private GameObject _enemyCamera;

    private UIController _uiController;

    [SerializeField] private EnemyRagdollControl _ragdollControl;

    private GameController _gameController;

    public static bool _yereCarpti;

    void Start()
    {
        _playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();
        m_Rigidbody.isKinematic = true;
        _playerCamera.SetActive(true);
        _enemyCamera.SetActive(false);
        _yereCarpti = false;
        GetComponent<Animator>().enabled = true;
        

        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        _coinsController = GameObject.FindWithTag("CoinsController").GetComponent<CoinsController>();
        _uiController = GameObject.FindWithTag("UiController").GetComponent<UIController>();
        _playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    

    public void EnemyYenile()
    {
        _playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();
        m_Rigidbody.isKinematic = true;
        _playerCamera.SetActive(true);
        _enemyCamera.SetActive(false);
        _yereCarpti = false;
        
    }

    public void EnemyAnimatorBaslat()
    {
        GetComponent<Animator>().enabled = true;
    }

    public void DusamaniFirlatma(float deger)
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        _coinsController = GameObject.FindWithTag("CoinsController").GetComponent<CoinsController>();
        _uiController = GameObject.FindWithTag("UiController").GetComponent<UIController>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();
        _playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        // _puanZemini.SetActive(true);
        GetComponent<Animator>().enabled = false;
        m_Rigidbody.isKinematic = false;
        m_Rigidbody.AddForce(transform.up * (deger * Time.deltaTime), ForceMode.Impulse);
        m_Rigidbody.AddForce(transform.forward * (-deger * Time.deltaTime), ForceMode.Impulse);
        _playerCamera.SetActive(false);
        _enemyCamera.SetActive(true);
        // EnemyCameraMovement._enemyKameraTakip = true;

        Debug.Log("Dusmanı Fırlatma Tamamlandı");
        // Debug.Log(deger);
    }

    public void KameralariNormaleDondur()
    {
        _playerCamera.SetActive(true);
        _enemyCamera.SetActive(false);
    }

    IEnumerator SevinmeSahnesineGecis()
    {
        
        yield return new WaitForSeconds(2.5f);
        KameralariNormaleDondur();
        _gameController.PlayerSevinmeOrganizasyon();
        yield return new WaitForSeconds(0.5f);
        _uiController.WinScreenOpen();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (_yereCarpti == false)
        {

            if (other.gameObject.tag == "RagdollSerbest")
            {
                _ragdollControl.RagdollIsKinematic();
            }
            else
            {

            }





            if (other.gameObject.tag == "X1")
            {
                //m_Collider.isTrigger = false;
                //_ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(1);
                m_Rigidbody.isKinematic = true;
                StartCoroutine(SevinmeSahnesineGecis());
               // Debug.Log("X1");
            }
            else if (other.gameObject.tag == "X2")
            {
                //m_Collider.isTrigger = false;
                //_ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(2);
                m_Rigidbody.isKinematic = true;
                StartCoroutine(SevinmeSahnesineGecis());
               // Debug.Log("X2");
            }
            else if (other.gameObject.tag == "X3")
            {
                //m_Collider.isTrigger = false;
                //_ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(3);
                m_Rigidbody.isKinematic = true;
                StartCoroutine(SevinmeSahnesineGecis());
              //  Debug.Log("X3");
            }
            else if (other.gameObject.tag == "X4")
            {
                //m_Collider.isTrigger = false;
                //_ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(4);
                m_Rigidbody.isKinematic = true;
                StartCoroutine(SevinmeSahnesineGecis());
               // Debug.Log("X4");
            }
            else if (other.gameObject.tag == "X5")
            {
                //m_Collider.isTrigger = false;
                //_ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(5);
                m_Rigidbody.isKinematic = true;
                StartCoroutine(SevinmeSahnesineGecis());
               // Debug.Log("X5");
            }
            else if (other.gameObject.tag == "X6")
            {
                //m_Collider.isTrigger = false;
                //_ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(6);
                m_Rigidbody.isKinematic = true;
                StartCoroutine(SevinmeSahnesineGecis());
               // Debug.Log("X6");
            }
            else if (other.gameObject.tag == "X7")
            {
                //m_Collider.isTrigger = false;
                //_ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(7);
                m_Rigidbody.isKinematic = true;
                StartCoroutine(SevinmeSahnesineGecis());
               // Debug.Log("X7");
            }
            else if (other.gameObject.tag == "X8")
            {
                //m_Collider.isTrigger = false;
                //_ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(8);
                m_Rigidbody.isKinematic = true;
                StartCoroutine(SevinmeSahnesineGecis());
              //  Debug.Log("X8");
            }
            else if (other.gameObject.tag == "X9")
            {
                // m_Collider.isTrigger = false;
                //_ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(9);
                m_Rigidbody.isKinematic = true;
                StartCoroutine(SevinmeSahnesineGecis());
              //  Debug.Log("X9");
            }
            else if (other.gameObject.tag == "X10")
            {
                // m_Collider.isTrigger = false;
                //_ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(10);
                m_Rigidbody.isKinematic = true;
                StartCoroutine(SevinmeSahnesineGecis());
              //  Debug.Log("X10");
            }
            else
            {

            }
        }
        else
        {

        }
        
    }
}
