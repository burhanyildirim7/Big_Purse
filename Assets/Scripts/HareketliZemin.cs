using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HareketliZemin : MonoBehaviour
{

    [SerializeField] private Animator _zeminAnimator;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void ZeminiKaldir()
    {
        _zeminAnimator.SetBool("ZeminYukari", true);
    }
}
