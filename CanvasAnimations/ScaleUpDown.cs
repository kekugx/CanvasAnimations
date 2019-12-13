using System.Collections;
using UnityEngine;

namespace EasyAnimationPack
{
    public class ScaleUpDown
    {
        private Transform AnimationTarget { get; }
        private float Speed { get; }
        private float FrameRate { get; }
        private float IncreaseSize { get; }

        public ScaleUpDown(Transform animationTarget, float speed, float frameRate, float modifyAmount)
        {
            AnimationTarget = animationTarget;
            Speed = speed;
            FrameRate = frameRate;
            IncreaseSize = modifyAmount;
        }

        public void PlayAnimation(MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(AnimationCoroutine(Speed));
        }

        IEnumerator AnimationCoroutine(float speed)
        {
            for (int i = 0; i < FrameRate; i++)
            {
                var localScale = AnimationTarget.localScale;
                var newSize = new Vector3(localScale.x + IncreaseSize / FrameRate,
                    localScale.y + IncreaseSize / FrameRate, 1f);

                localScale = newSize;
                AnimationTarget.localScale = localScale;
                yield return new WaitForSeconds(speed / 2 / FrameRate);
            }

            for (int i = 0; i < FrameRate; i++)
            {
                var localScale = AnimationTarget.localScale;
                var newSize = new Vector3(localScale.x - IncreaseSize / FrameRate,
                    localScale.y - IncreaseSize / FrameRate, 1f);

                localScale = newSize;
                AnimationTarget.localScale = localScale;
                yield return new WaitForSeconds(speed / 2 / FrameRate);
            }

            AnimationTarget.localScale = Vector3.one;
        }
    }
}