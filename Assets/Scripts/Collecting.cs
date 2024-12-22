using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    public float number;
    public MeshRenderer paper;

    void OnTriggerEnter(Collider other)
    {
        number++;
        paper.enabled = false;
    }

}
