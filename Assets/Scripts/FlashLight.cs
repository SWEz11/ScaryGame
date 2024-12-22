using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light light;
    public float energy = 100;
    public float dischargeSpeed = 1;
    public AudioSource clicksound;

    void Start()
    {
        light = GetComponentInChildren<Light>();
        clicksound = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            light.enabled = !light.enabled;
            clicksound.Play();
        }

        if (light.enabled)
        {
            energy -= Time.deltaTime * dischargeSpeed;
            energy = Mathf.Clamp(energy, 0, 100);
        }

        // blinking on low battery
        if (energy < 50f)
        {
            light.intensity = Random.Range(0.5f, 1f);
        }

        if (energy <= 0)
        {
            enabled = false;
        }
    }
}
