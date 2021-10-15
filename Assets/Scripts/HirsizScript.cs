using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HirsizScript : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _mesafeSiniri;

    private Transform _targetTransform;

    private bool _playerGordu;

    void Start()
    {
        _playerGordu = false;
    }

   
    void Update()
    {
        if (_playerGordu == true)
        {
            float step = _speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, step);

            Vector3 relativePos = _targetTransform.position - transform.position;

            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;

            float _aradakiMesafe = _targetTransform.position.z - transform.position.z;

            if (_aradakiMesafe > _mesafeSiniri)
            {
                _playerGordu = false;
            }
            else
            {

            }

        }
        else
        {

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerGordu = true;
            _targetTransform = other.gameObject.transform;
        }
        else
        {
           

        }
    }
}
