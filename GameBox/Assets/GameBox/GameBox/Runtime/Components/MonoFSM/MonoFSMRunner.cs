using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBox.Runtime.Component
{
    public class MonoFSMRunner : MonoBehaviour
    {
        private List<IMonoFSM> stateMachineList = new List<IMonoFSM>();

        public MonoFSM<T> Initialize<T>(MonoBehaviour component) where T : struct, IConvertible, IComparable
        {
            var fsm = new MonoFSM<T>(this, component);

            stateMachineList.Add(fsm);
            return fsm;
        }

        public MonoFSM<T> Initialize<T>(MonoBehaviour component, T startState) where T : struct, IConvertible, IComparable
        {
            var fsm = Initialize<T>(component);

            fsm.ChangeState(startState);

            return fsm;
        }

        void FixedUpdate()
        {
            for (int i = 0; i < stateMachineList.Count; i++)
            {
                var fsm = stateMachineList[i];
                if (!fsm.IsInTransition && fsm.Component.enabled) fsm.CurrentStateMap.FixedUpdate();
            }
        }

        void Update()
        {
            for (int i = 0; i < stateMachineList.Count; i++)
            {
                var fsm = stateMachineList[i];
                if (!fsm.IsInTransition && fsm.Component.enabled)
                {
                    fsm.CurrentStateMap.Update();
                }
            }
        }

        void LateUpdate()
        {
            for (int i = 0; i < stateMachineList.Count; i++)
            {
                var fsm = stateMachineList[i];
                if (!fsm.IsInTransition && fsm.Component.enabled)
                {
                    fsm.CurrentStateMap.LateUpdate();
                }
            }
        }


        public static void DoNothing()
        {
        }

        public static void DoNothingCollider(Collider other)
        {
        }

        public static void DoNothingCollision(Collision other)
        {
        }

        public static IEnumerator DoNothingCoroutine()
        {
            yield break;
        }
    }



}
