using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI2 : MonoBehaviour
{
    public float PlayerDistance = 2.0f;
    GameObject target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float close = Vector2.Distance(target.transform.position, transform.position);

        if (close <= PlayerDistance)//perseguir jugador
        {
            agent.SetDestination(target.transform.position);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerDistance);
    }
}