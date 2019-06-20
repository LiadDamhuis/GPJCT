using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{

    public int num;
    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }



    /// <summary>
    /// /////////////
    /// </summary>

    public Transform gunBarrelTransform;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            RaycastGun();
        }
    }

   // private void RaycastGun()
   // {
    //    RaycastHit hit;

   //     if (Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit))
   //     {
   //         if (hit.collider.gameObject.CompareTag("Cube"))
   //         {
   //             Destroy(hit.collider.gameObject);
   //         }
  //      }
   // }


    private void RaycastGun()
    {
        RaycastHit hit;

        if (Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Switch"))
            {
                SceneManager.LoadScene(num);
                Debug.Log("Scene changed to " + num);
            }
        }
    }
}
