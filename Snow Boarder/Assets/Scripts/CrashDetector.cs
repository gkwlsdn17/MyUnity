using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool isCrash = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !isCrash)
        {

            isCrash = true;
            FindObjectOfType<PlayerController>().DisableControls();
            Debug.Log("Ouch, hit my head");
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delay);

        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
