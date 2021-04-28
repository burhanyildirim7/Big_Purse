using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject _playerPurse;

    [SerializeField] private ParticleSystem _engelTrailEffect;
    [SerializeField] private GameObject _engelTrailEffectObject;

    [SerializeField] private ParticleSystem _moneyEffect;
    [SerializeField] private GameObject _moneyEffectObject;

    [SerializeField] private ParticleSystem _angryEmojiEffect;
    [SerializeField] private GameObject _angryEmojiObject;

    [SerializeField] private ParticleSystem _happyEmojiEffect;
    [SerializeField] private GameObject _happyEmojiObject;

    [SerializeField] private GameObject _purseObject;

    [SerializeField] private LevelController _levelController;

    Rigidbody p_Rigidbody;

    [SerializeField] private float _ziplamaDegeri;

    void Start()
    {
        p_Rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        _engelTrailEffectObject.transform.position = transform.position;
        _angryEmojiObject.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        _happyEmojiObject.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DegerliEsya")
        {
            //_playerPurse.gameObject.transform.localScale += Vector3.Lerp(transform.localScale, new Vector3(0.1f, 0.1f, 0.1f), Time.deltaTime * 0.1f);
            _playerPurse.gameObject.transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
            _playerPurse.gameObject.transform.localPosition += new Vector3(0, 0.03f, 0);
            _levelController.ToplananEsyaSayisi();
            _happyEmojiEffect.Play();


            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "DegersizEsya")
        {
            _playerPurse.gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            _playerPurse.gameObject.transform.localPosition -= new Vector3(0, 0.01f, 0);
            _levelController.EksilenEsyaSayisi();
            _moneyEffectObject.transform.position = _purseObject.transform.position;
            _engelTrailEffect.Play();
            _moneyEffect.Play();
            _angryEmojiEffect.Play();
            // Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "DurmaZemini")
        {
            PlayerMovement._playerHareket = false;
            Invoke("PlayerTekarHareket", 3);
        }
        else if (other.gameObject.tag == "ZiplamaZemini")
        {
            p_Rigidbody.AddForce(transform.up * (_ziplamaDegeri * Time.deltaTime), ForceMode.Impulse);
            p_Rigidbody.AddForce(transform.forward * (_ziplamaDegeri * Time.deltaTime), ForceMode.Impulse);
        }
        else
        {
            _engelTrailEffect.Stop();
            _moneyEffect.Stop();
        }
        
    }

    private void PlayerTekarHareket()
    {
        PlayerMovement._playerHareket = true;
    }


    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ZiplamaZemini")
        {
            p_Rigidbody.AddForce(transform.up * (_ziplamaDegeri * Time.deltaTime), ForceMode.Impulse);
            p_Rigidbody.AddForce(transform.forward * (_ziplamaDegeri * Time.deltaTime), ForceMode.Impulse);
        }
        else if (collision.gameObject.tag == "DurmaZemini")
        {
            PlayerMovement._playerHareket = false;
            Invoke("PlayerTekarHareket", 3);
        }
    }
    */



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
