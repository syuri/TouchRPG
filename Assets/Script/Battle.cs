using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour {

		//バトルに必要なターン、敵、スキルの羅列

		private int enemyhp;
		private int enemyat;
		private int enemyad;
		private int enemymd;
		private int enemysp;

		public GameObject dead;

		public int minus;

		public enum Turn{
				ENEMY_TURN,
				PLAYER_TURN,
				PAUSE_TURN,
		}

		public Turn state;

		PlayerAnim pl;
		Enemy en;
		Dungeon du;
		TouchSerch hhh;

		public void EnemyInfoSave(int hp,int attack,int adef,int mdef,int sp){
				enemyhp = hp;
				enemyat = attack;
				enemyad = adef;
				enemymd = mdef;
				enemysp = sp;
				en = GameObject.FindObjectOfType<Enemy>();
		}

	// Use this for initialization
	void Start () {
				du = GameObject.FindObjectOfType<Dungeon>();
				state = Turn.PLAYER_TURN;
				pl = GameObject.FindObjectOfType<PlayerAnim>();
				en = GameObject.FindObjectOfType<Enemy>();
				hhh = GameObject.FindObjectOfType<TouchSerch>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		public void Battledamege(int damege,int attackid){
				Debug.Log ("最終ダメージ値"+damege);
				if(state == Turn.PLAYER_TURN){
						if(damege<0){
								pl.Hp += -(damege);
								pl.GUIupdate ();
								state = Turn.ENEMY_TURN;
								Invoke("Enemyturn",3) ;
						}else{
								if(attackid==0){
										minus = enemyad;
								}else{
										minus = enemymd;
								}
								int finaldamege = damege - minus;
								if(finaldamege<0){
										finaldamege = 0;
								}
								enemyhp -= finaldamege;
								en.MotionDelay ();
								if(enemyhp<0){
										pl.Sp += enemysp;
										Instantiate(dead, new Vector3(-1.2f,2.56f,0), transform.rotation);
										pl.Regenepoint ();
										GameObject delenemy = GameObject.Find ("Enemy");
										Destroy(delenemy);
										du.FloorUpdate ();
										hhh.resettouch ();
										Debug.Log ("break");
								}else{
										state = Turn.ENEMY_TURN;
										Invoke("Enemyturn",3) ;
								}
						}

				}
		}

		public void Enemyturn(){
				en.Enemyattack ();
				pl.Hp -= (en.E_At-(pl.Def+pl.Mdef));
				if(pl.Hp<0){
					hhh.resettouch ();
					pl.Deathanim ();
				}else{
					//pl.Dapush ();
					pl.GUIupdate ();
					state = Turn.PLAYER_TURN;
				}

		}
}
