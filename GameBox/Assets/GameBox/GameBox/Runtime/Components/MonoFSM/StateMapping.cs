using System;
using System.Collections;
using UnityEngine;

namespace GameBox.Runtime.Component
{
    public class StateMapping
    {
        public object state;

        public bool HasEnterRoutine;
        public Action EnterCall = MonoFSMRunner.DoNothing;
        public Func<IEnumerator> EnterRoutine = MonoFSMRunner.DoNothingCoroutine;

        public bool HasExitRoutine;
        public Action ExitCall = MonoFSMRunner.DoNothing;
        public Func<IEnumerator> ExitRoutine = MonoFSMRunner.DoNothingCoroutine;

        public Action Finally = MonoFSMRunner.DoNothing;
        public Action Update = MonoFSMRunner.DoNothing;
        public Action LateUpdate = MonoFSMRunner.DoNothing;
        public Action FixedUpdate = MonoFSMRunner.DoNothing;
        public Action<Collision> OnCollisionEnter = MonoFSMRunner.DoNothingCollision;

        public StateMapping(object state)
        {
            this.state = state;
        }

    }
}
