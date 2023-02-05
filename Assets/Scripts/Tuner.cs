using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuner : MonoBehaviour
{
    public Transform from;
    public Transform to;
    public float speed = 0.01f;
    public float alpha;

    public float modification;

    public SphereManager sphere;

    public Transform center;
    public Transform fromCenter;
    public Transform toCenter;


    // Start is called before the first frame update
    void Start()
    {
        sphere = FindObjectOfType<SphereManager>();
        Debug.Log(sphere.transform.rotation.normalized.z);
    }
    void Update()
    {


        float i = Mathf.InverseLerp(fromCenter.rotation.z, toCenter.rotation.z, center.rotation.z);
        float addRot = Mathf.Clamp01(i);
        addRot += modification;

        transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, i + modification);
        

        //Debug.Log(Mathf.Clamp01(i));

        
    }

}
