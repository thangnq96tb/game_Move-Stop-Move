using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : IState<Bot>
{
    public void OnEnter(Bot bot)
    {
        bot.ChangeAnim("run");
        bot.SetDestination(SeekTarget());
    }

    public void OnExecute(Bot bot)
    {
        //when reach the destination, stop running, change to idle 
        if(bot.isDestination)
        {
            bot.ChangeState(new IdleState());
        }
    }

    public void OnExit(Bot bot)
    {

    }

    //find a position on map for bot to move to
    private Vector3 SeekTarget()
    {
        return new Vector3(Random.Range(-4f, 27f), 0f, Random.Range(-22f, 8f));
    }
}
