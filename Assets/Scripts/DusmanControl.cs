using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanControl : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    [SerializeField] GameObject _puanZemini;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        _puanZemini.SetActive(false);
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
}
