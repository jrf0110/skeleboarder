﻿using UnityEngine;
using System.Collections;
// Is the parent Base manager all other Managers will use AudioClips or other data from
public class BaseSoundManager : MonoBehaviour
{
	//baseSoundManagerInstance of class (Singleton)
	public static BaseSoundManager baseSoundManagerInstance = null;

	public AnimationClip fadeClip;
	// audio clips to play one time
	public AudioClip collide;
	public AudioClip win;
	public AudioClip jump;
	public AudioClip lose;
	public AudioClip secret;
	public AudioClip hitEnemy;
	public AudioClip killEnemy;
	public AudioClip getItem;
	public AudioClip died;
	public AudioClip gotHit;
	public AudioClip linkGotItem;
	public AudioClip cannonRamp;
	//Music
	public AudioClip level1Music;
	public AudioClip titleMusic;
	public static GameObject level1MusicObject;
	public static GameObject titleMusicObject;

	//public bool musicIsPlaying;

	// declare baseSoundManagerInstance
	void OnEnable()
	{
		if (baseSoundManagerInstance == null) 
		{
			baseSoundManagerInstance = this;
			DontDestroyOnLoad (this);
		}
	}

}
