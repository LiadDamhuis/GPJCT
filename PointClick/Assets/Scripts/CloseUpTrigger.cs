using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpTrigger : MonoBehaviour
{

    public GameObject closeupScreen;
    //public GameObject canvasSwitch;


    private void OnMouseDown()
    {
        closeupScreen.SetActive(false);
        //canvasSwitch.SetActive(false);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.gameObject)
                {
                    closeupScreen.SetActive(true);
                    //canvasSwitch.SetActive(false);
                    print("Sphere click!");
                }
            }
        }
    }
}