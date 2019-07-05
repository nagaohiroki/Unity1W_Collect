using UnityEngine;
public class Cat : MonoBehaviour
{
	[SerializeField]
	GameObject mCameraHandle = null;
	[SerializeField]
	Rigidbody mRigid = null;
	void Update()
	{
		if(mCameraHandle != null)
		{
			mCameraHandle.transform.position = transform.position;
		}
		var vec = Vector3.zero;
		vec.x = Input.GetAxis("Horizontal");
		vec.y = Input.GetAxis("Vertical");
		if(mRigid != null)
		{
			mRigid.AddForce(vec, ForceMode.VelocityChange);
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			float newAngle = mRigid.rotation.eulerAngles.z + 90.0f;
			mRigid.MoveRotation(Quaternion.Euler(0.0f, 0.0f, newAngle));
		}
	}
	void OnCollisionEnter(Collision inColl)
	{
		if(inColl.gameObject.tag != "Mag")
		{
			return;
		}
		// くっつける
		inColl.transform.SetParent(transform);
	}
}
