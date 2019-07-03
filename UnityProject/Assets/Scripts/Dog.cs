using UnityEngine;
public class Dog : MonoBehaviour
{
	[SerializeField]
	GameObject mMonster = null;
	[SerializeField]
	Rigidbody mRigidbody = null;
	void Update()
	{
		var vec = transform.position - mMonster.transform.position;
		if(vec.magnitude < 3.0f)
		{
			// mRigidbody.AddForce(vec.normalized, ForceMode.VelocityChange);
			transform.position += vec * 0.15f;
		}
	}
}
