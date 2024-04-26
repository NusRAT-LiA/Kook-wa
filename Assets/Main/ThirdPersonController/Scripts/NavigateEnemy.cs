using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigateEnemy : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent agent;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
     void Update()
    {
        agent.destination = Player.position;

        // Check if the agent has reached its destination
        if (agent.remainingDistance < 0.1f && !agent.pathPending)
        {
            Debug.Log("here");
            // Agent has reached its destination
            // You can trigger attack or other actions here
           Attack();
        }
    }


    void Attack()
    {
        animator.SetTrigger("attack");
    }
}
