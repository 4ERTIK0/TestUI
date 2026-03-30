using UnityEngine;

public class ScrollViewAdaptiveHeight : MonoBehaviour
{
    public RectTransform scrollView;
    [Header("Настройки")]
    public float referenceHeight = 1080f;
    public float minHeight = 400f;
    public float maxHeight = 900f;

    private int lastHeight;

    void Start()
    {
        UpdateSize();
    }

    void Update()
    {
        if (Screen.height != lastHeight)
        {
            UpdateSize();
        }
    }

    void UpdateSize()
    {
        float screenH = Screen.height;


        float scale = screenH / referenceHeight;

        float newHeight = Mathf.Clamp(600f * scale, minHeight, maxHeight);

        Vector2 size = scrollView.sizeDelta;
        size.y = newHeight;
        scrollView.sizeDelta = size;

        lastHeight = Screen.height;

        Debug.Log($"ScrollView height: {newHeight}");
    }
}