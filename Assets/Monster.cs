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
    public TMP_Text dietext;
    public AudioSource jumpscare;
    public Flashlight flashlight;
    public bool checkjumpscare;
    public NavMeshAgent agent;
    public Vector3 randomdistination;
    public float timerdist;
    public PaperCollecting papercollecting;
    public float speed;


    void Start()
    {
        jumpscare.GetComponent<AudioSource>().loop = false;
        checkjumpscare = false;
        agent = GetComponent<NavMeshAgent>();
        speed = GetComponent<NavMeshAgent>().speed;

        agent.speed = 3;
    }
    void Update()
    {


        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < viewdistance)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            randomdistination = new Vector3(Random.Range(0,10), Random.Range(0,10), Random.Range(0,10));
            print(randomdistination);
            timerdist = Time.deltaTime;
            if(timerdist > 30)
            {
                timerdist -= Time.deltaTime;
            }
        }


        if (distance < 3)
        {
            flashlight.light.intensity = Random.Range(0.5f, 1f);
            float angle = Vector3.Angle(transform.forward, target.transform.forward);
            print(angle);
            if(angle > 130f)
            {
                checkjumpscare = true;
                jumpscare.Play();
                if (checkjumpscare == true)
                {
                    dietext.gameObject.SetActive(true);
                }
            }
        }

        if(papercollecting.number >= 3)
        {
            agent.SetDestination(target.position);
            agent.speed = 7;
            print("Someone coming...");
        }
    }


}
