using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanControl : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    [SerializeField] GameObject _puanZemini;

    [SerializeField] private CoinsController _coinsController;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        _puanZemini.SetActive(false);
        m_Rigidbody.isKinematic = false;
    }

    
    void Update()
    {
        
    }

    public void DusamaniFirlatma(float deger)
    {
        _puanZemini.SetActive(true);
        m_Rigidbody.AddForce(transform.up * (deger * Time.deltaTime), ForceMode.Impulse);
        m_Rigidbody.AddForce(transform.forward * (-deger * Time.deltaTime), ForceMode.Impulse);

        Debug.Log(deger);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "X1")
        {
            _coinsController.OyunSonuCoinsHesapla(1);
            m_Rigidbody.isKinematic = true;
            Debug.Log("X1");
        }
        else if (other.gameObject.tag == "X2")
        {
            _coinsController.OyunSonuCoinsHesapla(2);
            m_Rigidbody.isKinematic = true;
            Debug.Log("X2");
        }
        else if (other.gameObject.tag == "X3")
        {
            _coinsController.OyunSonuCoinsHesapla(3);
            m_Rigidbody.isKinematic = true;
            Debug.Log("X3");
        }
        else if (other.gameObject.tag == "X4")
        {
            _coinsController.OyunSonuCoinsHesapla(4);
            m_Rigidbody.isKinematic = true;
            Debug.Log("X4");
        }
        else if (other.gameObject.tag == "X5")
        {
            _coinsController.OyunSonuCoinsHesapla(5);
            m_Rigidbody.isKinematic = true;
            Debug.Log("X5");
        }
        else if (other.gameObject.tag == "X6")
        {
            _coinsController.OyunSonuCoinsHesapla(6);
            m_Rigidbody.isKinematic = true;
            Debug.Log("X6");
        }
        else if (other.gameObject.tag == "X7")
        {
            _coinsController.OyunSonuCoinsHesapla(7);
            m_Rigidbody.isKinematic = true;
            Debug.Log("X7");
        }
        else if (other.gameObject.tag == "X8")
        {
            _coinsController.OyunSonuCoinsHesapla(8);
            m_Rigidbody.isKinematic = true;
            Debug.Log("X8");
        }
        else if (other.gameObject.tag == "X9")
        {
            _coinsController.OyunSonuCoinsHesapla(9);
            m_Rigidbody.isKinematic = true;
            Debug.Log("X9");
        }
        else if (other.gameObject.tag == "X10")
        {
            _coinsController.OyunSonuCoinsHesapla(10);
            m_Rigidbody.isKinematic = true;
            Debug.Log("X10");
        }
        else
        {

        }
    }
}
