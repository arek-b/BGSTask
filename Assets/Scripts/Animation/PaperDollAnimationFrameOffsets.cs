using UnityEngine;

namespace Animation
{
    [CreateAssetMenu(fileName = "FrameOffsets", menuName = "ScriptableObjects/PaperDollAnimationFrameOffsets")]
    public class PaperDollAnimationFrameOffsets : ScriptableObject
    {
        public PaperDollAnimationFrameOffset[] offsets;

        public PaperDollAnimationFrameOffset GetByAnimationClip(AnimationClip clip)
        {
            for (int i = 0; i < offsets.Length; i++)
            {
                
                if (offsets[i].clip == clip)
                {
                    return offsets[i];
                }
            }

            Debug.LogError("AnimationClip not found, cannot get offset");
            return null;
        }
    }
}