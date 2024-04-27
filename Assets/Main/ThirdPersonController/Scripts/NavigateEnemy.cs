using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigateEnemy : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent agent;
    public HealthBar healthBar;

    private Animator animator;
    private bool attackFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Start the attack coroutine
        StartCoroutine(AttackWithDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        healthBar.DecreaseHeart();
        
    }

    // Coroutine for attacking with a delay
    private IEnumerator AttackWithDelay()
    {
        while (true)
        {   
            if(animator.GetBool("dead") )
            agent.destination = agent.transform.position;
            else
            agent.destination = Player.position;

        // Check if the agent has reached its destination
        if (agent.remainingDistance < 5.0f)
        {
            // Agent has reached its destination
            // You can trigger attack or other actions here
            Attack();
        }
            yield return new WaitForSeconds(2f); // Wait for 2 seconds
        }
    }
}
