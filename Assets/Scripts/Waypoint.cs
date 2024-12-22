using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Waypoint : MonoBehaviour
{
    public List<Transform> waypoint;

    Transform currentTarget;

    int _index = 1;

    NavMeshAgent _agent;
    private bool _inReverse = false;
    private bool _atend = false;
    private bool _moving = false;
    public Monster monster;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        if (waypoint.Count > 0 && waypoint[0] != null)
        {
            currentTarget = waypoint[_index];

            _agent.SetDestination(currentTarget.position);
        }
    }

    void Update()
    {
        //Get current speed percent of agent and set the speed parameter of the animator float speedPercent = _agent.velocity.magnitude/ _agent.speed; _animator.SetFloat("speed", speedPercent);
        if (currentTarget != null)
        {
            if(monster.personDistination == false)
            {
                //Check if the agent has arrived the target position
                if ((Vector3.Distance(transform.position, currentTarget.position) <= 2f) && _moving)
                {
                    //Set moving to false to prevent this if statment from constantly running while at target position _moving = false;
                    _moving = false;
                    StartCoroutine("MoveToNextWaypoint");
                }

                if (monster.personDistination == true)
                {
                    monster.agent.SetDestination(monster.target.position);
                }
            }
        }
        IEnumerator MoveToNextWaypoint()
        {
            if (!_inReverse)
            {
                _index++;
            }


            //If not at the last waypoint and not going in reverse
            if (_index < waypoint.Count && !_inReverse)
            {
                //Pause a random amount of time before going to the first point if(_index == 1)
                yield return new WaitForSeconds(Random.Range(3f, 6f));
                currentTarget = waypoint[_index];
            }
            else
            {
                //If at the last point pause for a random amount of time if (!_atEnd)
                {
                    _atend = true;
                    yield return new WaitForSeconds(Random.Range(3f, 6f));
                    _index--;
                    _inReverse = true;
                    //if next waypoint is the first waypoint reset _inReverse and _atEnd if (_index == 0)
                    {
                        _inReverse = false;
                        _atend = false;
                    }
                    currentTarget = waypoint[_index];
                    //Move agent to next waypoint
                    _agent.SetDestination(currentTarget.position); _moving = true;
                }
            }
        }
    }
}