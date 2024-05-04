using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [ExecuteAlways]
    public class CanvasIntegerScaling : MonoBehaviour
    {
        [SerializeField] private int minimumScreenWidthPixels = 960;
        [SerializeField] private int minimumScreenHeightPixels = 540;
        [SerializeField] private CanvasScaler scaler;

        private void OnValidate()
        {
            if (scaler == null)
            {
                TryGetComponent<CanvasScaler>(out scaler);
            }
        }

        private void OnRectTransformDimensionsChange()
        {
            float widthScaleFactor = Mathf.Max(Mathf.Floor(Screen.width / minimumScreenWidthPixels), 1f);
            float heightScaleFactor = Mathf.Max(Mathf.Floor(Screen.height / minimumScreenHeightPixels), 1f);
            scaler.scaleFactor = Mathf.Min(widthScaleFactor, heightScaleFactor);
        }
    }
}