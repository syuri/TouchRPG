using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {

		private Animator anim;
		private AnimatorStateInfo currentBaseState;
		//マジック用の各種パーティクル
		public GameObject Majiceffect;
		public GameObject Majiceffect2;
		public GameObject Healeffect;
		public GameObject Healeffect2;

		public GameObject DeathUI;

		//プレイヤーステータス
		public int Hp;
		public int MaxHp;
		public int Tp;//MP的なパラメータ
		public int MaxTp;
		public int At;
		public int Def;
		public int Inte;//魔法・回復力
		public int Mdef;
		public int Sp;//スキルポイント

		public int Skillcost;
		public int Majiccost;
		public int Healcost;

		public int regenerateHP;
		public int regenerateTP;



		//各種テキスト表示
		public GUIText Hptext;
		public GUIText Attext;
		public GUIText Intext;
		public GUIText Sptext;
		public GUIText Tptext;
		//アニメーション中に他のボタンの制限に使う
		TouchSerch animbool;
		StackPanel stpanel;
		Battle ba;

		public int stackpanels;    // スタックパネルの数検索用

	// Use this for initialization
	void Start () {
				anim = GetComponent<Animator> ();

				ba = GameObject.FindObjectOfType<Battle>();
				animbool = GameObject.FindObjectOfType<TouchSerch>();
				stpanel = GameObject.FindObjectOfType<StackPanel>();

				Hptext.text = "HP:"+Hp+"/"+MaxHp;
				Intext.text = "魔法力:" + Inte;
				Attext.text = "攻撃力:"+At;
				Sptext.text = "SP:" + Sp;
				Tptext.text = "TP:" + Tp+"/"+MaxTp;

				regenerateHP = Mathf.CeilToInt(MaxHp * 0.1f);
				regenerateTP = Mathf.CeilToInt(MaxTp * 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		public void Atpush(){
				float attackpower = At + Random.Range (-2,3);
				Debug.Log ("基本攻撃値:"+attackpower);
				GameObject[] atpanels;
				atpanels = GameObject.FindGameObjectsWithTag("Attack");
				stackpanels = atpanels.Length;
				attackpower *= 1 + (stackpanels * 0.5f);
				Debug.Log ("スタック" + atpanels.Length + "攻撃力" + attackpower);
				int a = (int)attackpower;
				ba.Battledamege (a,0);
				anim.SetBool ("Atbool",true);
				stpanel.StackDel ();
				//
		}

		public void Skpush(){
				float skillpower = Mathf.CeilToInt(At * 1.8f);
				Debug.Log ("基本攻撃値:"+skillpower);
				GameObject[] skpanels;
				skpanels = GameObject.FindGameObjectsWithTag("Skill");
				stackpanels = skpanels.Length;
				skillpower *= 1 + (stackpanels * 0.5f);
				Debug.Log ("スタック" + skpanels.Length + "攻撃力" + skillpower);
				int k = (int)skillpower;
				ba.Battledamege (k,0);
				GUIupdate ();
				anim.SetBool ("Skbool",true);
				stpanel.StackDel ();
		}
		public void Mapush(){
				GameObject effect_pos = GameObject.Find ("MajicVector");
				Vector3 effect_vec = effect_pos.transform.position;
				float majicmag = Random.Range (1.5f, 2.5f);
				float Majikpower = Mathf.CeilToInt(Inte * majicmag);
				Debug.Log ("基本攻撃値:"+Majikpower);
				GameObject[] mapanels;
				mapanels = GameObject.FindGameObjectsWithTag("Majic");
				stackpanels = mapanels.Length;
				Majikpower *= (stackpanels * 0.9f);
				Debug.Log ("スタック" + mapanels.Length + "攻撃力" + Majikpower);
				int m = (int)Majikpower;
				ba.Battledamege (m,1);
				GUIupdate ();
				anim.SetBool ("Mabool",true);
				Instantiate(Majiceffect, transform.position, Quaternion.identity);
				Instantiate(Majiceffect2, new Vector3(-1.2f,3.4f,0), transform.rotation);
				stpanel.StackDel ();
		}

		public void Hepush(){
				float Healpower = Inte * -1.7f;
				Debug.Log ("基本攻撃値:"+Healpower);
				GameObject[] hepanels;
				hepanels = GameObject.FindGameObjectsWithTag("Heal");
				stackpanels = hepanels.Length;
				Healpower *= 1 +(stackpanels * 0.6f);
				Debug.Log ("スタック" + hepanels.Length + "攻撃力" + Healpower);
				int l = (int)Healpower;
				ba.Battledamege (l,1);
				GUIupdate ();
				anim.SetBool ("Hebool",true);
				Instantiate(Healeffect, transform.position, transform.rotation);
				Invoke ("heal2", 1f);
				stpanel.StackDel ();

		}

		public void heal2(){
				Instantiate(Healeffect2, transform.position, transform.rotation);
		}

		public void Dapush(){
				Debug.Log ("Calldamege");
				anim.SetBool ("Dabool",true);
				Invoke ("Boolre", 0.5f);
		}
				

		//全初期化
		public void Boolre(){
				animbool.animplay = true;
				anim.SetBool ("Atbool",false);
				anim.SetBool ("Skbool",false);
				anim.SetBool ("Mabool",false);
				anim.SetBool ("Dabool",false);
				anim.SetBool ("Hebool",false);
		}

		//GUItext update
		public void GUIupdate(){
				if(Hp>MaxHp){
						Hp = MaxHp;
				}
				if(Tp>MaxTp){
						Tp = MaxTp;
				}
				Hptext.text = "HP:"+Hp+"/"+MaxHp;
				Intext.text = "魔法力:" + Inte;
				Attext.text = "攻撃力:"+At;
				Sptext.text = "SP:" + Sp;
				Tptext.text = "TP:" + Tp+"/"+MaxTp;
		}
		public void Regenepoint(){
				regenerateHP = Mathf.CeilToInt(MaxHp * 0.1f);
				regenerateTP = Mathf.CeilToInt(MaxTp * 0.1f);
				Debug.Log("HP再生量:"+regenerateHP+"TP再生量:"+regenerateTP);
				Hp += regenerateHP;
				Tp += regenerateTP;
				GUIupdate ();
		}
		public void Deathanim(){
				anim.SetBool ("Dead", true);
				Invoke ("DeathUIapper", 0.5f);

		}
		public void DeathUIapper(){
				DeathUI.transform.Translate (0, 12, 0);
		}
}
