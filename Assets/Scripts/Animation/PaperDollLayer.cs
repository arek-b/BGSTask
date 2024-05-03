using UnityEngine;

namespace Animation
{
    public class PaperDollLayer : MonoBehaviour
    {
        [SerializeField] private Sprite[] sprites = new Sprite[0];
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            TryGetComponent<SpriteRenderer>(out spriteRenderer);
        }

        public void SetSprites(Sprite[] sprites)
        {
            this.sprites = sprites;
        }

        public void SetFrameIndex(int index)
        {
            if (sprites.Length <= 0)
            {
                return;
            }

            spriteRenderer.sprite = sprites[index];
        }
    }
}