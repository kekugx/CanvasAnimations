using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyAnimationPack
{
    public class GoToTarget
    {
        public Transform Transform { get; }
        public Vector3 Target { get; }
        public float Speed { get; }
        public int Frame { get; }
        public bool DestroyOnArrive { get; set; }
        public Action Command { get; set; }

        public GoToTarget(Transform transform, Vector3 target, float speed, int frame)
        {
            Transform = transform;
            Target = target;
            Speed = speed;
            Frame = frame;
        }

        public void Play(MonoBehaviour monoBehaviour, bool destroyOnArrive, Action action = null)
        {
            DestroyOnArrive = destroyOnArrive;
            Command = action;
            monoBehaviour.StartCoroutine(Move());
        }

        IEnumerator Move()
        {
            var movement = new Vector3((Target.x - Transform.position.x) / Frame,
                (Target.y - Transform.position.y) / Frame, (Target.z - Transform.position.z) / Frame);
            for (int i = 0; i < Frame; i++)
            {
                Transform.position += movement;
                yield return new WaitForSeconds(Speed / Frame);

                if (Vector3.Distance(Transform.position, Target) < 0.001)
                {
                    Transform.position = Target;
                    break;
                }
            }
            
            if (DestroyOnArrive)
            {
                Command?.Invoke();
                GameObject.Destroy(Transform.gameObject);
            }
        }
    }
}