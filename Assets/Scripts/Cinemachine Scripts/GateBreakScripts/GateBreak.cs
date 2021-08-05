using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBreak : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    private void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            audioSource.PlayOneShot(clip, volume);
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }


}
