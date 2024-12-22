using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    public float number;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Page"))
        {
            number++;
            Destroy(other);

        }
    }

}
