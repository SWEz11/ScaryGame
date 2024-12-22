using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public float viewdistance = 10;
    public Transform target;
    public FlashLight flashlight;
    public NavMeshAgent agent;
    public Collecting papercollecting;
    public float speed;
    public bool personDistination;

    void Start()
    {
        personDistination = false;
        agent = GetComponent<NavMeshAgent>();
        speed = GetComponent<NavMeshAgent>().speed;
        


        agent.speed = 3;
    }
    void Update()
    {


        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < viewdistance)
        {
            personDistination = true;
            agent.SetDestination(target.position);
            
        }


        if (distance < 3)
        {
            //flashlight.light.intensity = Random.Range(0.5f, 1f);
            float angle = Vector3.Angle(transform.forward, target.transform.forward);
            if (angle > 130f)
            {
                print("labas");
            }
        }
        
        if (distance >= 4)
        {
            personDistination = false;
        }

        if (papercollecting.number >= 2)
        {
            agent.SetDestination(target.position);
            agent.speed = 70;
        }
    }
}