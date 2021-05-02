using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuglaDavranis : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    private void Update()
    {
        if (TuglaYokEtme.yoketme==true)
        {
            Destroy(gameObject,3f);
        }
    }


}
