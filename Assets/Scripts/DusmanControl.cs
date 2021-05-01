using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanControl : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    Collider m_Collider;
    public float m_Thrust = 20f;

    [SerializeField] GameObject _puanZemini;

    [SerializeField] private CoinsController _coinsController;

    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private GameObject _enemyCamera;

    [SerializeField] private UIController _uiController;

    [SerializeField] private EnemyRagdollControl _ragdollControl;

    public static bool _yereCarpti;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();
        _puanZemini.SetActive(false);
        m_Rigidbody.isKinematic = true;
        _playerCamera.SetActive(true);
        _enemyCamera.SetActive(false);
        _yereCarpti = false;
        GetComponent<Animator>().enabled = true;
    }

    
    void Update()
    {
        
    }

    public void DusamaniFirlatma(float deger)
    {
        // _puanZemini.SetActive(true);
        m_Rigidbody.isKinematic = false;
        GetComponent<Animator>().enabled = false;
        m_Rigidbody.AddForce(transform.up * (deger * Time.deltaTime), ForceMode.Impulse);
        m_Rigidbody.AddForce(transform.forward * (-deger * Time.deltaTime), ForceMode.Impulse);
        _playerCamera.SetActive(false);
        _enemyCamera.SetActive(true);
        

        Debug.Log(deger);
    }

    public void KameralariNormaleDondur()
    {
        _playerCamera.SetActive(true);
        _enemyCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_yereCarpti == false)
        {
            if (other.gameObject.tag == "X1")
            {
                //m_Collider.isTrigger = false;
                _ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(1);
                m_Rigidbody.isKinematic = true;
                _uiController.WinScreenOpen();
                Debug.Log("X1");
            }
            else if (other.gameObject.tag == "X2")
            {
                //m_Collider.isTrigger = false;
                _ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(2);
                m_Rigidbody.isKinematic = true;
                _uiController.WinScreenOpen();
                Debug.Log("X2");
            }
            else if (other.gameObject.tag == "X3")
            {
                //m_Collider.isTrigger = false;
                _ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(3);
                m_Rigidbody.isKinematic = true;
                _uiController.WinScreenOpen();
                Debug.Log("X3");
            }
            else if (other.gameObject.tag == "X4")
            {
                //m_Collider.isTrigger = false;
                _ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(4);
                m_Rigidbody.isKinematic = true;
                _uiController.WinScreenOpen();
                Debug.Log("X4");
            }
            else if (other.gameObject.tag == "X5")
            {
                //m_Collider.isTrigger = false;
                _ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(5);
                m_Rigidbody.isKinematic = true;
                _uiController.WinScreenOpen();
                Debug.Log("X5");
            }
            else if (other.gameObject.tag == "X6")
            {
                //m_Collider.isTrigger = false;
                _ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(6);
                m_Rigidbody.isKinematic = true;
                _uiController.WinScreenOpen();
                Debug.Log("X6");
            }
            else if (other.gameObject.tag == "X7")
            {
                //m_Collider.isTrigger = false;
                _ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(7);
                m_Rigidbody.isKinematic = true;
                _uiController.WinScreenOpen();
                Debug.Log("X7");
            }
            else if (other.gameObject.tag == "X8")
            {
                //m_Collider.isTrigger = false;
                _ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(8);
                m_Rigidbody.isKinematic = true;
                _uiController.WinScreenOpen();
                Debug.Log("X8");
            }
            else if (other.gameObject.tag == "X9")
            {
                // m_Collider.isTrigger = false;
                _ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(9);
                m_Rigidbody.isKinematic = true;
                _uiController.WinScreenOpen();
                Debug.Log("X9");
            }
            else if (other.gameObject.tag == "X10")
            {
                // m_Collider.isTrigger = false;
                _ragdollControl.RagdollIsKinematic();
                _yereCarpti = true;
                _coinsController.OyunSonuCoinsHesapla(10);
                m_Rigidbody.isKinematic = true;
                _uiController.WinScreenOpen();
                Debug.Log("X10");
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
