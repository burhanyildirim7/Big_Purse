using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kinematikdeneme1 : MonoBehaviour
{
    [SerializeField]private List<GameObject> Tuglalar = new List<GameObject>();
    public GameObject duvar;
    public bool kinematikAc;
    // Start is called before the first frame update
    void Start()
    {
        /*Tuglalar[0] = duvar.gameObject.transform.GetChild(0).gameObject;
        Tuglalar[1] = duvar.gameObject.transform.GetChild(1).gameObject;*/
        for (int i = 0; i < duvar.transform.childCount; i++)
        {
            Tuglalar[i] = duvar.gameObject.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < duvar.transform.childCount; i++)
        {
            Tuglalar[i] = duvar.gameObject.transform.GetChild(0).GetChild(i).gameObject;
        }*/
        Debug.Log(duvar.gameObject.transform.childCount);
        if (kinematikAc)
        {
            for (int i = 0; i < Tuglalar.Count; i++)
            {
                Tuglalar[i].GetComponent<Rigidbody>().isKinematic=false;
            }
        }
    }





}
