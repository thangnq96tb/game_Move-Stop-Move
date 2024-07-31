using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    public NavMeshAgent agent;
    public Vector3 destination;
    public IState<Bot> currentState;

    //bot will reach the destination if the distance of it to the destination < 0.1f (very close)
    //Vector3.right & Vector3.forward to lock the Y axis...
    public bool isDestination => Vector3.Distance(destination,
        Vector3.right * transform.position.x + Vector3.forward * transform.position.z) < 0.1f;


    void Start()
    {
        ChangeState(new IdleState());
    }

    void Update()
    {
        currentState.OnExecute(this);
    }

    public void ChangeState(IState<Bot> newState)
    {
        if(currentState != null)
        {
            currentState.OnExit(this);
        }    

        if(currentState != newState)
        {
            currentState = newState;
            currentState.OnEnter(this);
        }    
    }    

    public void SetDestination(Vector3 des)
    {
        agent.enabled = true; //for moving by NavMesh
        destination = des;
        agent.SetDestination(des);
        destination.y = 0f;
    }
}
