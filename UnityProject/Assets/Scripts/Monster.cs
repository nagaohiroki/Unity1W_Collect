using UnityEngine;
public class Monster : MonoBehaviour
{
	[SerializeField]
	GameObject mCameraHandle = null;
	void Update()
	{
		var vec = Vector3.zero;
		vec.x = Input.GetAxis("Horizontal");
		vec.z = Input.GetAxis("Vertical");
		transform.position += vec.normalized * 0.5f;
		mCameraHandle.transform.position = transform.position;
	}
}
