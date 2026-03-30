using UnityEngine;
using UnityEngine.UI;

public class AdaptiveGrid : MonoBehaviour
{
    public GridLayoutGroup grid;

    private ScrollRect scroll;

    private int lastColumnCount = -1;
    private int lastWidth;
    private int lastHeight;

    void Awake()
    {
        scroll = grid.GetComponentInParent<ScrollRect>();
    }

    void Start()
    {
        UpdateGrid();
    }

    void Update()
    {
        if (Screen.width != lastWidth || Screen.height != lastHeight)
        {
            UpdateGrid();
        }
    }

    void UpdateGrid()
    {
        float ratio = (float)Screen.width / Screen.height;

        int newColumnCount;

        if (Screen.width >= 2300)
            newColumnCount = 5;
        else if (ratio >= 2.1f)
            newColumnCount = 5;
        else if (ratio >= 1.5f)
            newColumnCount = 4;
        else
            newColumnCount = 3;

        if (newColumnCount == lastColumnCount)
            return;

        lastColumnCount = newColumnCount;

  
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = newColumnCount;

        Canvas.ForceUpdateCanvases();

        RectTransform content = scroll.content;

        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        LayoutRebuilder.ForceRebuildLayoutImmediate(grid.GetComponent<RectTransform>());


        if (scroll.viewport != null)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(scroll.viewport);
        }


        scroll.StopMovement();
        scroll.verticalNormalizedPosition = 1f;

        lastWidth = Screen.width;
        lastHeight = Screen.height;

        Debug.Log($"AdaptiveGrid → Columns: {newColumnCount}, Ratio: {ratio}");
    }
}