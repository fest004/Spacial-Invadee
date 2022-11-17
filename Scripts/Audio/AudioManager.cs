using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class AudioManager : MonoBehaviour
{

  public Sound[] sounds;
  public static AudioManager instance;

  

  void Awake()
  {
    if (instance == null) {
      instance = this;
    } else {
      Destroy(gameObject);
      return;
    }

    DontDestroyOnLoad(gameObject);

    foreach (Sound s in sounds) {
      s.source = gameObject.AddComponent<AudioSource>();
      s.source.clip = s.clip;

      s.source.volume = s.volume;
      s.source.pitch = s.pitch;
    } 
  }

  #region Play and Stop
  public void Play(string name) 
  {
    if (name == null) {
      Debug.LogWarning($"Name {name} is null");
    } else {
      Sound s = Array.Find(sounds, sound => sound.name == name); s.source.Play();
    }
  }

  public void Stop(string name)
  {
    if (name == null) {
      Debug.LogWarning($"Name {name} is null");
    } else {
      Sound s = Array.Find(sounds, sound => sound.name == name); s.source.Stop();
      }
  }
  #endregion

}
