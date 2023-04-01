using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeImageOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image firstImage;
    public Image secondImage;

    public Sprite firstHoverSprite;
    public Sprite secondHoverSprite;

    private Sprite firstNormalSprite;
    private Sprite secondNormalSprite;

    void Awake()
    {
        // Store the normal sprites of the two images
        firstNormalSprite = firstImage.sprite;
        secondNormalSprite = secondImage.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Change the sprites of the two images to the hover sprites
        firstImage.sprite = firstHoverSprite;
        secondImage.sprite = secondHoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Change the sprites of the two images back to the normal sprites
        firstImage.sprite = firstNormalSprite;
        secondImage.sprite = secondNormalSprite;
    }
}