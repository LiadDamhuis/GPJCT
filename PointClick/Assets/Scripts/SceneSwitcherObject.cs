using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherObject : MonoBehaviour
{
    public int num;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(num);
        Debug.Log("Scene changed to " + num);       
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
        {

            if (hit.collider.gameObject.tag == "Switch") //tag not even registered? Any tag will still do.
              {
                    SceneManager.LoadScene(num);
                    Debug.Log("Scene changed to " + num);
              }
           }
        }
    }
}
