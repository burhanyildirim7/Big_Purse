using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdollControl : MonoBehaviour
{

    [SerializeField] private GameObject _enemyObject;
    Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.isKinematic = false;
    }

    public void RagdollIsKinematic()
    {
        m_Rigidbody.isKinematic = true;
    }

    
    void Update()
    {
        transform.position = new Vector3(_enemyObject.transform.position.x, _enemyObject.transform.position.y + 2, _enemyObject.transform.position.z);
    }
}
