using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject _playerPurse;

    [SerializeField] private ParticleSystem _engelTrailEffect;
    [SerializeField] private GameObject _engelTrailEffectObject;

    void Start()
    {
        
    }

    
    void Update()
    {
        _engelTrailEffectObject.transform.position = transform.position;
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
            _playerPurse.gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            _playerPurse.gameObject.transform.localPosition -= new Vector3(0, 0.01f, 0);
            _engelTrailEffect.Play();
            // Destroy(other.gameObject);
        }
        else
        {
            _engelTrailEffect.Stop();
        }
    }


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
