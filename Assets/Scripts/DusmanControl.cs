using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanControl : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }

    public void DusamaniFirlatma()
    {
        m_Rigidbody.AddForce(transform.up * (m_Thrust * Time.deltaTime), ForceMode.Impulse);
        m_Rigidbody.AddForce(transform.forward * (m_Thrust * Time.deltaTime), ForceMode.Impulse);

        Debug.Log("UC DUSMAN UC");
    }
}
