using UnityEngine;
using System.Collections;

public class PanelGen : MonoBehaviour {
		public GameObject Ataack;
		public GameObject Defence;
		public GameObject Heal;
		public GameObject Majic;

		public ArrayList LineList;
		public GameObject[] Line;
		public GameObject[] Line2;
		public GameObject[] Line3;
		public GameObject[] Line4;
		public GameObject[] Line5;

		private int Panelelement;

	// Use this for initialization
	void Start () {
				/*
				for (int i = 0; i < 5; i++) {
						GameObject[] LL = new GameObject[3];
						for (int j = 0; j < 3; j++) {
								Panelelement = Random.Range (0, 4);
								switch (Panelelement) {
								case 0:
										GameObject pobja = (GameObject)Instantiate (Ataack, new Vector3 (-j, -i, 0), Quaternion.identity);
										pobja.name = i + "Line";
										LL [j] = pobja;
										//Block.transform.parent = Manager.transform;
										break;
								case 1:
										GameObject pobjd = (GameObject)Instantiate (Defence, new Vector3 (-j, -i, 0), Quaternion.identity);
										pobjd.name = i + "Line";
										LL [j] = pobjd;
										break;
								case 2:
										GameObject pobjm = (GameObject)Instantiate (Majic, new Vector3 (-j, -i, 0), Quaternion.identity);
										pobjm.name = i + "Line";
										LL [j] = pobjm;
										break;
								case 3:
										GameObject pobjh = (GameObject)Instantiate (Heal, new Vector3 (-j, -i, 0), Quaternion.identity);
										pobjh.name = i + "Line";
										LL [j] = pobjh;
										break;
								}

						}


						//LineList.Add (Line);

				}*/

		}
					
	
	// Update is called once per frame
	void Update () {
				//Debug.Log (LineList);
	}
}
