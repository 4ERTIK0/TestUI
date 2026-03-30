using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image targetImage;

    public Color normalColor = new Color(1, 1, 1, 0); 
    public Color hoverColor = new Color(0, 1, 0, 0.3f);

    void Start()
    {
        if (targetImage == null)
            targetImage = GetComponent<Image>();

        targetImage.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetImage.color = normalColor;
    }
}