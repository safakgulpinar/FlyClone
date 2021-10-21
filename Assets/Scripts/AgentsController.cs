using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentsController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject target;
    [SerializeField] bool isPlaying;
    [SerializeField] Animator botAnimator;
    [SerializeField] private BotsStack botsStackController;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }



    private void FixedUpdate()
    {
        if (isPlaying)
        {
            agent.SetDestination(target.transform.position);
            botAnimator.SetBool("isRun", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaying == false)
            {
                isPlaying = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stack"))
        {
            botsStackController.AddList(other.gameObject);
        }
    }
}
