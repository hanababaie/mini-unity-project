using System;
using System.Collections;
using UnityEngine;

public class musicmanage : MonoBehaviour
{
   private static musicmanage instance;
   private static bool muted;
   public AudioSource battleMusic;
   public AudioSource soundEffect;

   private bool isplaying;
   
   private void Awake()
   {
      if(instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(instance);
      }
   }

   private void Start()
   {
      //first we chreck if the player want the game to be muted ot not
      muted = PlayerPrefs.GetInt("muted") == 1; // if equals to 1 we are muted

      if (muted)
      {
         AudioListener.pause = true;
      }
         battleMusic.loop = true;
   }
   
   public void togglemusic()
   {
      muted = !muted;
      if (muted)
      {
         PlayerPrefs.SetInt("muted", 1);
      }
      else
      {
         PlayerPrefs.SetInt("muted", 0);
      }

      if (muted)
      {
         AudioListener.pause = true;
      }
      else
      {
         AudioListener.pause = false;
      }
   }

   public static void playingbattle()
   {
      if (!muted && !instance.battleMusic.isPlaying)
      {
         instance.battleMusic.Play();
      }
   }

   public static void stopbattle()
   {
      if (instance.battleMusic.isPlaying)
      {
         instance.battleMusic.Stop();
      }
   }

   public static void playingsound(AudioClip clip)
   {
      if(!muted)
      {
         instance.soundEffect.PlayOneShot(clip);
      }
   }

  

   private IEnumerator battle()
   {
      while (isplaying)
      {
         yield return new WaitForSeconds(0f);
         battleMusic.Play();
      }
   }
}
