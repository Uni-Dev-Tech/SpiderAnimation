using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollToObj : MonoBehaviour
{
    public Transform objToFollow;
    private float X, Y, Z;
    public float sensetive;
    public float sensetiveScroll;
    private void FixedUpdate()
    {
        Transform cameraTr;
        cameraTr = GetComponent<Transform>();

        X = Input.GetAxis("Mouse X");
        Y = Input.GetAxis("Mouse Y");
        Z = Input.GetAxis("Mouse ScrollWheel");

        cameraTr.Translate(X * sensetive * Time.fixedDeltaTime, Y * sensetive * Time.fixedDeltaTime, Z * sensetiveScroll * Time.fixedDeltaTime);
        cameraTr.LookAt(objToFollow);
    }
}
