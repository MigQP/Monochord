using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject mainpoint;
    public float speed = 1.0f;
    Tuner tuner;

    SphereManager sphere;
    // Start is called before the first frame update
    void Start()
    {
        mainpoint = GameObject.FindGameObjectWithTag("MainPoint");
        tuner = FindObjectOfType<Tuner>();
        sphere = FindObjectOfType<SphereManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(this.transform.position, mainpoint.transform.position, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainPoint"))
        {
            tuner.modification = Random.Range(-0.25f, 0.25f);
            sphere.DoTorque();
            Destroy(this.gameObject);
        }
    }

}
