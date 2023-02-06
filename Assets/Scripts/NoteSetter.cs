using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSetter : MonoBehaviour
{
    // AQUI PODRIA IR EL TRIGGEREO DE CLIP DE AUDIO
    public AudioSource noteTuned;

    public Tuner tuner;

    public Transform center;

    // Start is called before the first frame update
    void Start()
    {
        tuner = FindObjectOfType<Tuner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        tuner.center = center;
        noteTuned.Play();
    }
}
