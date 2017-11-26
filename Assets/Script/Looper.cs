using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour {
	public int _NumberObject;
	public string _TagName;

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == _TagName)
		{
			float width = collider.GetComponent<BoxCollider2D>().size.x * collider.transform.localScale.x;

			Vector3 pos = collider.transform.position;
			pos.x += width * _NumberObject;
			collider.transform.position = pos;
		}
	}
}
