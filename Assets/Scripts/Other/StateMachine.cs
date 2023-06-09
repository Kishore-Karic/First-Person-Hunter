﻿using UnityEngine;

namespace FPHunter.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        protected BaseState currentState;

        public void SetState(BaseState newState)
        {
            if(currentState != null)
            {
                currentState.OnStateExit();
            }

            currentState = newState;

            if(currentState != null)
            {
                currentState.OnStateEnter();
            }
        }
    }
}