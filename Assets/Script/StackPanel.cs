using UnityEngine;
using System.Collections;

public class StackPanel : MonoBehaviour {

		public GameObject Apanel;
		public GameObject Spanel;
		public GameObject Mpanel;
		public GameObject Hpanel;

		public ArrayList stack;

		public GameObject stackparent;

		private int panelid;
		private int createid;

	// Use this for initialization
	void Start () {

				stackparent = GameObject.Find ("StackObj");

				StartCoroutine ("Create");

				//Debug.Log (stack[0]);
				//Stackcreate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		//0:attack 1:Skill 2:majic 3:heal
		private IEnumerator Create(){
				ArrayList stack = new ArrayList ();
				for(int i = 0;i<3;i++){
						panelid = Random.Range (0, 4);
						stack.Add (panelid);
				}
				for(int h = 0;h<stack.Count;h++){
						yield return 10;
						createid = (int)stack [h];
						switch(createid){
						case 0:
								GameObject panel0 = (GameObject)Instantiate (Apanel, new Vector3 (h-2, -3.8f, h), Quaternion.identity);
								panel0.name = "0";
								panel0.transform.parent = stackparent.transform;
								//Debug.Log ("create"+h);
								break;
						case 1:
								GameObject panel1 =(GameObject)Instantiate(Spanel, new Vector3(h-2, -3.8f, h), Quaternion.identity);
								panel1.name = "1";
								panel1.transform.parent = stackparent.transform;
								//Debug.Log ("create"+h);
								break;
						case 2:
								GameObject panel2 =(GameObject)Instantiate(Mpanel, new Vector3(h-2, -3.8f, h), Quaternion.identity);
								panel2.name = "2";
								panel2.transform.parent = stackparent.transform;
								//Debug.Log ("create"+h);
								break;
						case 3:
								GameObject panel3 =(GameObject)Instantiate(Hpanel, new Vector3(h-2, -3.8f, h), Quaternion.identity);
								panel3.name = "3";
								panel3.transform.parent = stackparent.transform;
								//Debug.Log ("create"+h);
								break;
						}

						//stack.RemoveAt(s);
				}

		}
		public void StackDel(){
				foreach(Transform child in transform) {
						Destroy(child.gameObject);
				}
				StartCoroutine ("Create");
		}
}
