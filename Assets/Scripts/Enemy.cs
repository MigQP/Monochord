using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject mainpoint;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        mainpoint = GameObject.FindGameObjectWithTag("MainPoint");
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
            Destroy(this.gameObject);
        }
    }
}
