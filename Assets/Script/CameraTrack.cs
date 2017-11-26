using UnityEngine;
using System.Collections;

public class CameraTrack : MonoBehaviour
{
	public GameObject _Plane;
	private float _OffsetX;

	private void Start()
	{
		_OffsetX = transform.position.x - _Plane.transform.position.x;
	}
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3(_Plane.transform.position.x + _OffsetX, transform.position.y, transform.position.z);
		transform.position = pos;
	}
}
