using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject _playerPurse;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DegerliEsya")
        {
            //_playerPurse.gameObject.transform.localScale += Vector3.Lerp(transform.localScale, new Vector3(0.1f, 0.1f, 0.1f), Time.deltaTime * 0.1f);
            _playerPurse.gameObject.transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
            _playerPurse.gameObject.transform.localPosition += new Vector3(0, 0.02f, 0);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "DegersizEsya")
        {
            _playerPurse.gameObject.transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
            _playerPurse.gameObject.transform.localPosition -= new Vector3(0, 0.02f, 0);
           // Destroy(other.gameObject);
        }
    }
}
