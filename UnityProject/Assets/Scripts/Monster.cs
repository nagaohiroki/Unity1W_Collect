using UnityEngine;
public class Monster : MonoBehaviour
{
	[SerializeField]
	Rigidbody mRigidbody = null;
	void Update()
	{
		var vec = Vector3.zero;
		vec.x = Input.GetAxis("Horizontal");
		vec.z = Input.GetAxis("Vertical");
		transform.position += vec.normalized * 0.1f;
	//	if(mRigidbody != null)
	//	{
	//		mRigidbody.AddForce(vec, ForceMode.VelocityChange);
	//	}
	}
}
