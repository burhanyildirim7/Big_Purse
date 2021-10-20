using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HirsizDolasanScript : MonoBehaviour
{

    [SerializeField] private float _speed;

    [SerializeField] private float _turnTime;

    // [SerializeField] private float _smooth;

    private float _donmeAcisi;

    private float _timer;

    void Start()
    {
        _timer = 0;
        _donmeAcisi = 180;
    }

    
    void Update()
    {
        _timer += Time.deltaTime;

        transform.Translate(Vector3.forward * Time.deltaTime * _speed);

        if (_timer > _turnTime)
        {
            KarakterDondur();
        }
        else
        {

        }

        Debug.Log(_timer);
    }

    private void KarakterDondur()
    {
        _timer = 0;
        Quaternion target = Quaternion.Euler(transform.rotation.x, _donmeAcisi, transform.rotation.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 720);
        _donmeAcisi += 180;
    }
}
