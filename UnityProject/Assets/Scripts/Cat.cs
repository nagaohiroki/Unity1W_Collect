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
			mRigid.AddTorque(0.0f, 0.0f, -vec.x, ForceMode.VelocityChange);
			//var angle = mRigid.rotation.eulerAngles.z - vec.x;
			//var q = Quaternion.Euler(0.0f, 0.0f, angle);
			//mRigid.MoveRotation(q);
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			transform.localScale += Vector3.one;
		}
	}
	void OnCollisionEnter(Collision inColl)
	{
		if(inColl.gameObject.tag != "Mag")
		{
			return;
		}
		inColl.transform.SetParent(transform);
	}
}
