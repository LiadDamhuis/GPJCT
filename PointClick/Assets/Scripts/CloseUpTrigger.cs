using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpTrigger : MonoBehaviour
{

    public GameObject closeupObject;
    public GameObject canvasSwitch;


    private void OnMouseDown()
    {
        closeupObject.SetActive(false);
        canvasSwitch.SetActive(false);
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
                    closeupObject.SetActive(true);
                    print("Sphere click!");
                }
            }
        }
        //if (Input.GetMouseButtonDown(0)) 
        //{
        //    if (closeupObject.activeInHierarchy == true)
         //   {
             //   closeupObject.SetActive(false);
         //   }
       // }
    }
}