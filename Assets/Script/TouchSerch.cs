using UnityEngine;
using System.Collections;

public class TouchSerch : MonoBehaviour {

		public GameObject Player;
		public GameObject uiback;

		public GameObject Stackss;

		public GameObject chenge_S;
		public GameObject chenge_A;
		public GameObject chenge_M;
		public GameObject chenge_H;

		public GameObject PSui;

		public bool enemyturn;
		public bool cantpuch;
		public bool animplay;
		public bool uinow;
		public bool psnow;

		PlayerAnim actor;
		Enemy eneee;

		// Use this for initialization
		void Start () {
				enemyturn = false;
				actor = GameObject.FindObjectOfType<PlayerAnim> ();
				eneee = GameObject.FindObjectOfType<Enemy>();

				Stackss = GameObject.Find ("StackObj");
				Player = GameObject.Find ("Actor");
				animplay = true;
		}
		// Update is called once per frame
		void Update () {
				if (Input.GetMouseButtonDown(0)) {
						if(enemyturn==true){
								Debug.Log ("Cant touch");
						}else{
								Vector3    aTapPoint   = Camera.main.ScreenToWorldPoint(Input.mousePosition);
								Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

								if (aCollider2d) {
										GameObject obj = aCollider2d.transform.gameObject;
										switch(obj.name){
										case "Attack":
												if(animplay==true){
														animplay = false;
														Player.SendMessage ("Atpush");
														Debug.Log ("turnend");
														enemyturn = true;
														Invoke( "Hoge", 0.6f );
												}else{
														Debug.Log ("animation play now");
												}
												break;
										case "Item":
												if (psnow == false) {
														PSui.transform.Translate (-9, 0, 0);
														psnow = true;
														Debug.Log ("ps call");
												} else {
														PSui.transform.Translate (9, 0, 0);
														psnow = false;
														Debug.Log ("ps back");
												}
												break;
										case "skill":
												if(animplay==true && actor.Tp>actor.Skillcost){
														actor.Tp -=actor.Skillcost;
														animplay = false;
														Player.SendMessage ("Skpush");
														Debug.Log ("turnend");
														enemyturn = true;
														Invoke( "Hoge", 0.8f );
												}else{
														return;
												}
												break;
										case "Majic":
												if(animplay==true && actor.Tp>actor.Majiccost){
														actor.Tp -= actor.Majiccost;
														animplay = false;
														Player.SendMessage ("Mapush");
														Debug.Log ("turnend");
														enemyturn = true;
														Invoke( "Hoge", 1.5f );
												}else{
														return;
												}

												break;
										case "Heal":
												if(animplay==true && actor.Tp>actor.Healcost){
														actor.Tp -= actor.Healcost;
														animplay = false;
														Player.SendMessage ("Hepush");
														Debug.Log ("turnend");
														enemyturn = true;
														Invoke( "Hoge", 1.5f );
												}else{
														return;
												}
												break;
												//スキル割り振りの呼び出し
										case "option":
												if(uinow==false){
														uiback.transform.Translate (-9, 0, 0);
														uinow = true;
														Debug.Log ("optioncall");
												}else{
														uiback.transform.Translate (9, 0, 0);
														uinow = false;
														Debug.Log ("ui back");
												}
												break;
										case "AtoS":
												if (actor.Tp < 30) {
														return;
												}
												actor.Tp -= 30;
												PanelChenge ("Attack",1,chenge_S);
												break;
										case "AtoH":
												if (actor.Tp < 40){
														return;
												}
												actor.Tp -= 40;
												PanelChenge ("Attack",3,chenge_H);
												break;
										case "StoM":
												if (actor.Tp < 50){
														return;
												}
												actor.Tp -= 50;
												Debug.Log ("消費TP50");
												PanelChenge ("Skill",2,chenge_M);
												break;
										case "StoH":
												if (actor.Tp < 45){
														return;
												}
												actor.Tp -= 45;
												Debug.Log ("消費TP45");
												PanelChenge ("Skill",3,chenge_H);
												break;
										case "MtoS":
												if (actor.Tp < 20) {
														return;
												}
												actor.Tp -= 20;
												PanelChenge ("Majic",1,chenge_S);
												Debug.Log ("消費TP20");
												break;
										case "MtoH":
												if (actor.Tp < 35){
														return;
												}
												actor.Tp -= 35;
												PanelChenge ("Majic",3,chenge_H);
												Debug.Log ("消費TP35");
												break;
										case "MaxHP_up":
												if (actor.Sp == 0) {
														Debug.Log ("Sp = 0 !!");
														return;
												}
												actor.Sp--;
												actor.MaxHp += 25;
												actor.Hp += 25;
												actor.GUIupdate ();
												Debug.Log ("MaxHp Up !!");
												break;
										case "MaxTP_up":
												if (actor.Sp == 0) {
														Debug.Log ("Sp = 0 !!");
														return;
												}
												actor.Sp--;
												actor.MaxTp += 15;
												actor.Tp += 15;
												actor.GUIupdate ();
												Debug.Log ("MaxTP Up !!");
												break;
										case "Attack_up":
												if (actor.Sp == 0) {
														Debug.Log ("Sp = 0 !!");
														return;
												}
												actor.Sp--;
												actor.At += 8;
												actor.GUIupdate ();
												Debug.Log ("Attack Up !!");
												break;
										case "Inte_up":
												if (actor.Sp == 0) {
														Debug.Log ("Sp = 0 !!");
														return;
												}
												actor.Sp--;
												actor.Inte += 6;
												actor.GUIupdate ();
												Debug.Log ("Inte Up !!");
												break;
												//防御、魔法防御ステータスは仮実装
										case "Pdef_up":
												if (actor.Sp == 0) {
														Debug.Log ("Sp = 0 !!");
														return;
												}
												actor.Sp--;
												actor.Def += 1;
												actor.GUIupdate ();
												Debug.Log ("Def Up !!");
												break;
										case "Mdef_up":
												if (actor.Sp == 0) {
														Debug.Log ("Sp = 0 !!");
														return;
												}
												actor.Sp--;
												actor.Mdef += 1;
												actor.GUIupdate ();
												Debug.Log ("Mdef Up !!");
												break;
										case "deathuisss":
												Application.LoadLevel (0);
												break;
										default:
												Debug.Log ("touch(click)!! objectname:"+obj.name);
												break;
										}
								}
						}


				}
		}

		void Hoge(){
				Player.SendMessage ("Boolre");
				//eneee.SendMessage ("Enemyda");
		}
		public void resettouch(){
				enemyturn = false;
		}

		public void PanelChenge(string tag,int id,GameObject p){
				actor.GUIupdate ();
				GameObject[] ChengePanelarray;
				ChengePanelarray = GameObject.FindGameObjectsWithTag (tag);
				foreach(GameObject panel in ChengePanelarray){
						Vector3 test = panel.transform.position;
						GameObject chengedp =(GameObject)Instantiate(p, test, Quaternion.identity);
						chengedp.name = ""+id;
						chengedp.transform.parent = Stackss.transform;
						Destroy (panel);
				}

		}
}