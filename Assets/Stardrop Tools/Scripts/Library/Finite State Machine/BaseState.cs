﻿
using UnityEngine;

namespace StardropTools.FiniteStateMachine
{
    /// <summary>
    /// Base state Class from which all other state may derive from.
    /// </summary>
    public abstract class BaseState : IBaseState
    {
        [SerializeField] protected FiniteStateMachine stateMachine;
        [SerializeField] protected int stateID;
        [SerializeField] protected float timeInState;

        public FiniteStateMachine StateMachine => stateMachine;
        public int StateID => stateID;
        public float TimeInState => timeInState;

        public bool IsInitialized { get; protected set; }
        public bool IsPaused { get; protected set; }
        public int GetStateID() => stateID;


        public readonly BaseEvent<BaseState> OnStateEnter = new BaseEvent<BaseState>();
        public readonly BaseEvent<BaseState> OnStateExit = new BaseEvent<BaseState>();
        public readonly BaseEvent<BaseState> OnStateUpdate = new BaseEvent<BaseState>();
        public readonly BaseEvent<BaseState> OnStateInput = new BaseEvent<BaseState>();


        public virtual void Initialize(FiniteStateMachine stateMachine, int stateID)
        {
            if (IsInitialized)
                return;

            this.stateMachine = stateMachine;
            this.stateID = stateID;

            IsInitialized = true;
        }


        public virtual void EnterState()
        {
            timeInState = 0;
            OnStateEnter?.Invoke(this);
        }


        public virtual void ExitState()
        {
            OnStateExit?.Invoke(this);
        }


        public virtual void HandleInput()
        {
            if (IsPaused)
                return;

            OnStateInput?.Invoke(this);
        }


        public virtual void UpdateState()
        {
            if (IsPaused)
                return;

            timeInState += Time.deltaTime;
            OnStateUpdate?.Invoke(this);
        }

        public void PauseState()
        {
            if (IsPaused)
                return;

            IsPaused = true;
        }

        public void ResumeState()
        {
            if (IsPaused == false)
                return;

            IsPaused = false;
        }


        protected virtual void ChangeState(BaseStateComponent nextState)
            => stateMachine.ChangeState(nextState);

        protected virtual void ChangeState(int nextStateID)
            => stateMachine.ChangeState(nextStateID);

        public void SetStateID(int stateID)
            => this.stateID = stateID;
    }
}