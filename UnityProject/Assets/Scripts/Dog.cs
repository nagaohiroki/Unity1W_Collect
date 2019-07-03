using UnityEngine;
public class Dog : MonoBehaviour
{
	[SerializeField]
	GameObject mMonster = null;
	void Update()
	{
		var vec = transform.position - mMonster.transform.position;
		vec.y = 0.0f;
		if(vec.magnitude < 3.0f)
		{
			transform.position += vec * 0.15f;
		}
	}
}
