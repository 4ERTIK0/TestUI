using UnityEngine;

public class ViewportAdaptiveHeight : MonoBehaviour
{
    public RectTransform viewport;


    public float referenceHeight = 1080f;

    public float minHeight = 300f;
    public float maxHeight = 900f;

    private int lastScreenHeight;

    void Start()
    {
        UpdateViewport();
    }

    void Update()
    {
        if (Screen.height != lastScreenHeight)
        {
            UpdateViewport();
        }
    }

    void UpdateViewport()
    {
        float screenH = Screen.height;

        float scale = screenH / referenceHeight;

        float newHeight = Mathf.Clamp(600f * scale, minHeight, maxHeight);

        Vector2 size = viewport.sizeDelta;
        size.y = newHeight;
        viewport.sizeDelta = size;

        lastScreenHeight = Screen.height;

        Debug.Log("Viewport height: " + newHeight);
    }
}