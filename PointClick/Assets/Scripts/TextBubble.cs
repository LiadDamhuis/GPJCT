using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextBubble : MonoBehaviour
{


    public GameObject displayCanvas;
 

    public void ShowDisplayImage()
    {
        displayCanvas.SetActive(false);
    }


    private void OnMouseEnter()
    {
        displayCanvas.SetActive(true);

    }

    private void OnMouseExit()
    {
        displayCanvas.SetActive(false);
    }


}
