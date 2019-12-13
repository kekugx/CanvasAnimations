using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace EasyAnimationPack
{
    public class ChangeImageColorAnimation
    {
        public Transform Transform { get; set; }
        public float AnimationTime { get; set; }
        public Color[] Colors { get; set; }
        
        public ChangeImageColorAnimation(Transform transform, float animationTime, params Color[] colors)
        {
            Transform = transform;
            AnimationTime = animationTime;
            Colors = colors;
        }

        public void Play(MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(SwitchColor());
        }

        IEnumerator SwitchColor()
        {
            for (int i = 0; i < Colors.Length; i++)
            {
                Transform.GetComponent<Image>().color = Colors[i];
                yield return new WaitForSeconds(AnimationTime / Colors.Length);
            }
        }
    }
}