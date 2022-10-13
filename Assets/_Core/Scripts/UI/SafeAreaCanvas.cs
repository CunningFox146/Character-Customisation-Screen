using UnityEngine;

namespace DonutLab.UI
{
    [RequireComponent(typeof(Canvas))]
    public class SafeAreaCanvas : MonoBehaviour
    {
        [SerializeField] private RectTransform _safeAreaRect;

        private Rect _lastSafeArea = Rect.zero;
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        void Start()
        {
            UpdateSafeArea();
        }

        private void Update()
        {
            UpdateSafeArea();
        }

        private void UpdateSafeArea()
        {
            var currentSafeArea = Screen.safeArea;
            if (_lastSafeArea != currentSafeArea)
            {
                _lastSafeArea = currentSafeArea;
                ApplySafeArea(currentSafeArea);
            }
        }

        void ApplySafeArea(Rect safeArea)
        {
            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= _canvas.pixelRect.width;
            anchorMin.y /= _canvas.pixelRect.height;
            anchorMax.x /= _canvas.pixelRect.width;
            anchorMax.y /= _canvas.pixelRect.height;

            _safeAreaRect.anchorMin = anchorMin;
            _safeAreaRect.anchorMax = anchorMax;
        }
    }

}
