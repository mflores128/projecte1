using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Scripting.APIUpdating;

public class PickupControl : MonoBehaviour
{
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans=GetComponent<Transform>();
        trans.DORotate(new Vector3(0, 0, 360), 5, RotateMode.WorldAxisAdd).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
