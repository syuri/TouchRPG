using UnityEngine;
using System.Collections;

public class Dungeon : MonoBehaviour {

		public int Nowfloortext;
		public int Nowfloor;
		public GUIText Floortext;

		public GameObject[] Enemys;

		TouchSerch ss4;
		PlayerAnim ss5;


	// Use this for initialization
	void Start () {
				ss4 = GameObject.FindObjectOfType<TouchSerch>();
				ss5 = GameObject.FindObjectOfType<PlayerAnim>();
				Nowfloor = 0;
				Nowfloortext++;
				Floortext.text = Nowfloortext+"F";

				GameObject enemy = Enemys [Nowfloor];
				//new Vector3(-4.7f,5.7f,0)
				enemy = (GameObject)Instantiate (enemy, new Vector3(-1.2f,2.56f,0), Quaternion.identity);
				enemy.name = "Enemy";

	}


	// Update is called once per frame
	void Update () {
	
	}
		public void FloorUpdate(){
				Nowfloor++;
				if(Nowfloor==76){
						//仮処理
						Debug.Log ("clear");
						Application.LoadLevel (0);
				}
				Nowfloortext++;
				Floortext.text = Nowfloortext+"F";
				GameObject enem = Enemys [Nowfloor];
				//new Vector3(-4.7f,5.7f,0)
				enem = (GameObject)Instantiate (enem, new Vector3(-1.2f,2.56f,0), Quaternion.identity);
				enem.name = "Enemy";
				ss5.Regenepoint ();
				ss5.GUIupdate ();
				ss4.enemyturn = false;
		}
}
