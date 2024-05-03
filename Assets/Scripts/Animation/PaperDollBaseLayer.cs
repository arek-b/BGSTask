using UnityEngine;

namespace Animation
{
    public class PaperDollBaseLayer : MonoBehaviour
    {
        [SerializeField] private Animator animator = null;
        [SerializeField] private PaperDollAnimationFrameOffsets offsets = null;
        [SerializeField] private PaperDollLayer[] layers = null;

        void LateUpdate()
        {
            AnimationClip currentClip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            float clipLength = currentClip.length;
            float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1;
            int currentFrameIndex = (int)(normalizedTime * currentClip.frameRate * clipLength);
            for (int i = 0; i < layers.Length; i++)
            {
                layers[i].SetFrameIndex(currentFrameIndex + offsets.GetByAnimationClip(currentClip).frameOffset);
            }
        }
    }
}