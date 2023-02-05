using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemy;

    public Tuner tuner;

    public float timer;

    public bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        tuner = FindObjectOfType<Tuner>();
        InvokeRepeating("CheckSpawn", 0f, 1f);
    }

    void CheckSpawn()
    {
        if (canSpawn)
        {
            SpawnEnemy();
        }
    }

    private static float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }

    // Update is called once per frame
    void Update()
    {
        if (WrapAngle(tuner.transform.localEulerAngles.z) < 8 && WrapAngle(tuner.transform.localEulerAngles.z) > -8)
        {
            timer += Time.deltaTime;
            GameManager.instance.SetScore((int)timer);

            if (timer > 0.5f)
            {
                //SpawnEnemy();
                canSpawn = true;
            }
        }

        else
        {
            timer = 0.0f;
            canSpawn = false;
        }

        Debug.Log(WrapAngle(tuner.transform.localEulerAngles.z));
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.name == "MonoBar")
        //SpawnEnemy();
        //tuner.transform.rotation = center.transform.rotation;
    }

    private void OnTriggerExit(Collider other)
    {
        //tuner.transform.rotation = center.transfor;
        
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, Quaternion.identity);
    }
}
