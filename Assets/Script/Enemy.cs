using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

		public int E_HP;
		public int E_At;
		public int E_Adef;
		public int E_Mdef;
		public int getsp;

		PlayerAnim pp;
		Battle badd;
		TouchSerch flag;

		private Animator anims;

	// Use this for initialization
	void Start () {

				pp = GameObject.FindObjectOfType<PlayerAnim>();
				anims = GetComponent<Animator> ();
				badd = GameObject.FindObjectOfType<Battle>();
				flag = GameObject.FindObjectOfType<TouchSerch>();
				flag.enemyturn = false;

				badd.EnemyInfoSave (E_HP, E_At, E_Adef, E_Mdef,getsp);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		public void MotionDelay(){
				Invoke ("Enemyda", 0.5f);
		}

		public void Enemyda(){
				anims.SetBool ("bright", true);
		}

		public void Enemyattack(){
				anims.SetBool ("Attack", true);
				pp.Dapush ();
				Invoke("Resett",0.5f);
		}

		public void Resett(){
				anims.SetBool ("bright", false);
				anims.SetBool ("Attack", false);
				pp.Regenepoint ();
				pp.GUIupdate ();
				flag.enemyturn = false;
		}
}
