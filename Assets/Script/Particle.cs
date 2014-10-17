using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

		public float time;

	// Use this for initialization
	void Start () {
				Invoke( "Del", time );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		void Del(){
				Destroy(this.gameObject);
		}

}
