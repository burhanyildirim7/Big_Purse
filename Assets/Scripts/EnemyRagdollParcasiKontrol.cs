using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdollParcasiKontrol : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.isKinematic = false;
    }

    private void RagdollIsKinematic()
    {
        m_Rigidbody.isKinematic = true;
        Invoke("NormaleDon", 0.1f);

    }

    private void NormaleDon()
    {
        m_Rigidbody.isKinematic = false;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "X1")
        {
            RagdollIsKinematic();
        }
        else if (collision.gameObject.tag == "X2")
        {
            RagdollIsKinematic();
        }
        else if (collision.gameObject.tag == "X3")
        {
            RagdollIsKinematic();
        }
        else if (collision.gameObject.tag == "X4")
        {
            RagdollIsKinematic();
        }
        else if (collision.gameObject.tag == "X5")
        {
            RagdollIsKinematic();
        }
        else if (collision.gameObject.tag == "X6")
        {
            RagdollIsKinematic();
        }
        else if (collision.gameObject.tag == "X7")
        {
            RagdollIsKinematic();
        }
        else if (collision.gameObject.tag == "X8")
        {
            RagdollIsKinematic();
        }
        else if (collision.gameObject.tag == "X9")
        {
            RagdollIsKinematic();
        }
        else if (collision.gameObject.tag == "X10")
        {
            RagdollIsKinematic();
        }
    }
}
