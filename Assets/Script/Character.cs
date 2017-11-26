using UnityEngine;
using System.Collections.Generic;
using System.Collections;
 
 public class Character : MonoBehaviour
 {
     private List<RPGClass> m_Classes;
	 private RPGClass m_Class;
	 private RPGClass warrior;
	 private RPGClass enemy;
	 
	 public Animator _AnimMon;
	 public Animator _AnimEnemy;
	 private bool _IsDead = false;
	 private bool _IsStart = false;
	 private bool _MonTurn = false;
	 private bool _EnemyTurn = false;
	 
	 private void Update()
	  {
		if (_IsDead) return;
		//while((warrior.CurrentHealthPoint > 0) || (enemyCurrentHealthPoint > 0)){
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Click");
			if(_MonTurn){
				_AnimMon.SetBool("StartAttack", true);
				_AnimMon.SetBool("MonTurn", true);
			}else{
				_AnimEnemy.SetBool("EnemyStartAttack", true);
				_AnimEnemy.SetBool("EnemyTurn", true);
			}
				//while(!_IsDead)
				//{
					//TakeDamage(warrior.Strength ,warrior);
					//System.Threading.Thread.Sleep(1000);
				//}
		}
	 
	  }
		 
	 public void TakeDamage(int damage,RPGClass obj){
		 obj.CurrentHealthPoint = obj.CurrentHealthPoint - damage;
		 Debug.Log("Fight "+obj.ClassName+" CurrentHealthPoint : "+obj.CurrentHealthPoint);
		 if(obj.CurrentHealthPoint <= 0)
        {
            Death(obj);
        }
		_AnimMon.SetBool("MonTurn", !_MonTurn);
		_MonTurn = !_MonTurn;
		_AnimEnemy.SetBool("EnemyTurn", !_EnemyTurn);
		_EnemyTurn = !_EnemyTurn;
	 }
	 
	 void Death (RPGClass obj)
    {
		Debug.Log("Death");
        _IsDead = true;
		if(obj.ClassName == "Warrior"){
			_AnimMon.SetBool("IsDead", true);
		}else{
			_AnimEnemy.SetBool("EnemyIsDead", true);
		}
		

        //playerAudio.clip = deathClip;
        //playerAudio.Play ();

    }
     
	public void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "enemy"){
			Debug.Log("OnCollisionEnter2D : enemy");
			if(_MonTurn){
				_AnimMon.SetBool("StartAttack", false);
				TakeDamage(warrior.Strength ,enemy);
				_AnimMon.SetBool("EndAttack", true);
			}else{
				_AnimEnemy.SetBool("EnemyStartAttack", false);
				TakeDamage(enemy.Strength ,warrior);
				_AnimEnemy.SetBool("EnemyEndAttack", true);
			}
		}else{
			Debug.Log("OnCollisionEnter2D : "+collision.gameObject.name);
		}
		
	}
	
	public void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.name == "enemy"){
			Debug.Log("OnTriggerEnter2D");
			if(_MonTurn){
				_AnimMon.SetBool("StartAttack", false);
				TakeDamage(warrior.Strength ,enemy);
				_AnimMon.SetBool("EndAttack", true);
			}else{
				_AnimEnemy.SetBool("EnemyStartAttack", false);
				TakeDamage(enemy.Strength ,warrior);
				_AnimEnemy.SetBool("EnemyEndAttack", true);
			}
		}else{
			Debug.Log("OnTriggerEnter2D : not enemy");
		}
	}
	
  
     void Start()
     {
		 Screen.orientation = ScreenOrientation.LandscapeLeft;
		 warrior = new RPGClass() { ClassName = "Warrior",CurrentHealthPoint = 50 ,HealthPoint = 50 , Strength = 12, Vitality = 12,Agility = 12 , Dexterity = 10, Intelligence = 8 };
		 enemy = new RPGClass() { ClassName = "Enemy",CurrentHealthPoint = 20, HealthPoint = 20 , Strength = 2, Vitality = 5,Agility = 11, Dexterity = 2, Intelligence = 2 };
		 
		_AnimMon.SetBool("EndAttack", false);
		_AnimMon.SetBool("StartAttack", false);
		_AnimMon.SetBool("MonTurn", true);
		_AnimEnemy.SetBool("EnemyEndAttack", false);
		_AnimEnemy.SetBool("EnemyStartAttack", false);
		_AnimEnemy.SetBool("EnemyTurn", false);
		
		if(warrior.Agility >= enemy.Agility){
			Debug.Log("Mon turn");
			_MonTurn = true;
			_EnemyTurn = false;
		}else{
			Debug.Log("Enemy turn");
			_MonTurn = false;
			_EnemyTurn = true;
		}
		 
     }
 }