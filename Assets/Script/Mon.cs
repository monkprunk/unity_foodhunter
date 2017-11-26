using UnityEngine;
using System.Collections;

public class Mon : MonoBehaviour {
	
	private bool _MonTurn = false;
	private bool _EnemyTurn = false;

	// Use this for initialization
	void Start () {
		_MonTurn = GetComponent<Animator>().GetBool("MonTurn");
	}
	
	// Update is called once per frame
	void Update () {
		_MonTurn = GetComponent<Animator>().GetBool("MonTurn");
	}
	
	public void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Mon : OnCollisionEnter2D");
		if(_MonTurn){
			GetComponent<Animator>().SetBool("StartAttack", false);
			//TakeDamage(warrior.Strength ,warrior);
			GetComponent<Animator>().SetBool("EndAttack", true);
		}
		
	}
	
	public void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("OnTriggerEnter2D");
	}
}
