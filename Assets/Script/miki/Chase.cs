using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    private Vector3 TargetPosition;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        TargetPosition = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target)
        {
            agent.destination = target.transform.position;
            transform.LookAt(TargetPosition);
        }
    }
}
