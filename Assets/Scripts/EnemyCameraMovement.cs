using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraMovement : MonoBehaviour
{
    [SerializeField]
    GameObject Enemy;

    



    Vector3 aradakiFark;


    void Start()
    {
        aradakiFark = transform.position - Enemy.transform.position;

    }


    void FixedUpdate()
    {
        /*
        if (AnimationControl._dusmaniFirlat == true)
        {
            transform.position = new Vector3(_dusmanObject.transform.position.x, _dusmanObject.transform.position.y + aradakiFark.y, _dusmanObject.transform.position.z + aradakiFark.z);
        }
       */
            transform.position = Vector3.Lerp(transform.position, new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + aradakiFark.y, Enemy.transform.position.z + aradakiFark.z), Time.deltaTime * 10f);
        

    }
}
