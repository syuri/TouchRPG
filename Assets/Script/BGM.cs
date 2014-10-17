using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

		/*
		 * 戦闘のBGM専用スクリプト
		 * BGMの処理のみ
		 * 
		*/

		//通常戦闘BGM
		public AudioClip audioClip;
		AudioSource audioSource;
		//ボス戦闘BGM
		public AudioClip audioClip2;
		AudioSource audioSource2;

		void Start() {
				audioSource = gameObject.GetComponent<AudioSource>();
				audioSource.clip = audioClip;
				audioSource.Play();
		}

		void Update () {
		}

		void BGMchemge (){
				audioSource.Stop ();
				audioSource2 = gameObject.GetComponent<AudioSource>();
				audioSource2.clip = audioClip2;
				audioSource2.Play();
		}
}