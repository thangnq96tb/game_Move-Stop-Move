using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Bot>
{
    float timer = 0f;
    public void OnEnter(Bot bot)
    {
        bot.ChangeAnim("idle");
    }

    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        //after each 5 second, bot will change from idle to running state 
        if(timer > 5f)
        {
            bot.ChangeState(new RunningState());
        }    
    }

    public void OnExit(Bot bot)
    {

    }
}
