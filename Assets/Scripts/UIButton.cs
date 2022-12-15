using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private Sprite buttonHoverSprite;
    [SerializeField] private Sprite buttonSprite;
    [SerializeField] private Sprite buttonDownSprite;



    public void PointerEnter()
    {
        gameObject.GetComponent<Image>().sprite = buttonHoverSprite;
    }

    public void PointerExit()
    {
        gameObject.GetComponent<Image>().sprite = buttonSprite;
    }

    public void buttonClick()
    {
        gameObject.GetComponent<Image>().sprite = buttonDownSprite;
    }

    public void buttonUp()
    {
        gameObject.GetComponent<Image>().sprite = buttonHoverSprite;
    }
}
