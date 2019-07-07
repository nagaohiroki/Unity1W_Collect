using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class Player : MonoBehaviour
{
	[SerializeField]
	GameObject mCameraHandle = null;
	[SerializeField]
	Rigidbody mRigidbody = null;
	[SerializeField]
	Text mTelop = null;
	[SerializeField]
	GameObject mFriend = null;
	[SerializeField]
	GameObject mEnemy = null;
	bool mIsEnd;
	void Update()
	{
		if(mIsEnd)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
			return;
		}
		if(mCameraHandle)
		{
			mCameraHandle.transform.position = transform.position;
		}
		if(mRigidbody)
		{
			mRigidbody.AddTorque(0, 0, -Input.GetAxis("Horizontal") * 1.5f, ForceMode.VelocityChange);
		}
		Generate();
	}
	void Generate()
	{
		if(Time.frameCount % 60 == 0)
		{
			var prefab = Random.Range(0, 100) > 80 ? mEnemy : mFriend;
			var go = Instantiate(prefab);
			go.SetActive(true);
			var pos = mFriend.transform.position;
			go.transform.position = new Vector3(Random.Range(-pos.x, pos.x), pos.y, 0.0f);
		}
	}
	void OnCollisionEnter(Collision inColl)
	{
		if(mIsEnd)
		{
			return;
		}
		if(inColl.gameObject.tag == "Friend")
		{
			inColl.gameObject.transform.SetParent(transform);
			Destroy(inColl.gameObject.GetComponent<Rigidbody>());
		}
		if(inColl.gameObject.tag == "Enemy")
		{
			GameOver();
		}
	}
	void GameOver()
	{
		if(!mTelop)
		{
			return;
		}
		mTelop.gameObject.SetActive(true);
		int count = transform.childCount;
		string msg = "GameOver..";
		var msgList = new Dictionary<string, int>
		{
			{"Clear!", 5},
			{"Greate!!", 10},
			{"Congratulations!!!", 15},
			{"Perfect!!!!", 20},
		};
		foreach(var clearMsg in msgList)
		{
			if(count > clearMsg.Value)
			{
				msg = clearMsg.Key;
			}
		}
		mTelop.text = string.Format("{0}\nYou Rescue {1} Friends.", msg, count);
		mIsEnd = true;
	}
}
