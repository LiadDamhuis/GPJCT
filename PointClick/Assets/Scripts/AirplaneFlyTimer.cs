using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneFlyTimer : MonoBehaviour
{
    

AudioSource myAudio;

   void Start()
  {
      myAudio = GetComponent<AudioSource>();
       myAudio.PlayDelayed(20.0f);
   }


  void Update()
   {

  }
}
