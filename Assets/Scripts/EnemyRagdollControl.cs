using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdollControl : MonoBehaviour
{

    [SerializeField] private GameObject _enemyObject;
    Rigidbody m_Rigidbody;
    private bool _ragdollSerbest;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.isKinematic = false;
        _ragdollSerbest = false;
    }

    public void RagdollIsKinematic()
    {
        //m_Rigidbody.isKinematic = true;
        _ragdollSerbest = true;
        //Invoke("ZEksenSinirla", 0.2f);


    }

    private void ZEksenSinirla()
    {

        //m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
        m_Rigidbody.isKinematic = true;
    }

    private void XEksenSinirla()
    {
        //m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        // m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
        Invoke("ZEksenSinirla", 0.1f);
    }
    
    
    void Update()
    {

        if (!_ragdollSerbest)
        {
            transform.position = new Vector3(_enemyObject.transform.position.x, _enemyObject.transform.position.y + 2, _enemyObject.transform.position.z);
        }
        else
        {

        }
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "X1")
        {
            //Invoke("YEksenSinirla",0.5f);
            XEksenSinirla();
        }
        else if (collision.gameObject.tag == "X2")
        {
            //Invoke("YEksenSinirla", 0.5f);
            XEksenSinirla();
        }
        else if (collision.gameObject.tag == "X3")
        {
            //Invoke("YEksenSinirla", 0.5f);
            XEksenSinirla();
        }
        else if (collision.gameObject.tag == "X4")
        {
            //Invoke("YEksenSinirla", 0.5f);
            XEksenSinirla();
        }
        else if (collision.gameObject.tag == "X5")
        {
            //Invoke("YEksenSinirla", 0.5f);
            XEksenSinirla();
        }
        else if (collision.gameObject.tag == "X6")
        {
            //Invoke("YEksenSinirla", 0.5f);
            XEksenSinirla();
        }
        else if (collision.gameObject.tag == "X7")
        {
            //Invoke("YEksenSinirla", 0.5f);
            XEksenSinirla();
        }
        else if (collision.gameObject.tag == "X8")
        {
            //Invoke("YEksenSinirla", 0.5f);
            XEksenSinirla();
        }
        else if (collision.gameObject.tag == "X9")
        {
            //Invoke("YEksenSinirla", 0.5f);
            XEksenSinirla();
        }
        else if (collision.gameObject.tag == "X10")
        {
            //Invoke("YEksenSinirla", 0.5f);
            XEksenSinirla();
        }
    }
}
