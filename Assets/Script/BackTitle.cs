using UnityEngine;
using System.Collections;

public class BackTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
				//
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		public void TitleBack(){
				Application.LoadLevel(0);
		}
		public void OperatingInstructions(){
				Application.LoadLevel(1);
		}
		public void ScreenDescription(){
				Application.LoadLevel(2);
		}
		public void GameScene(){
				Application.LoadLevel(3);
		}
}
