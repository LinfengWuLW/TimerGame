using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTimer : MonoBehaviour
{
	float roundStartDelayTime = 3;

	float roundStartTime;
	int waitTime;
	bool roundStarted;

	public Text targetTime;
	public Text playerMessage;

	// Use this for initialization
	void Start()
	{
		print("Press the spacebar once you think the allotted time is up.");
		Invoke("SetNewRandomTime", roundStartDelayTime);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		if (Input.GetKeyDown(KeyCode.Space) && roundStarted)
		{
			InputReceived();
		}

		
	}

	void InputReceived()
	{
		roundStarted = false;
		float playerWaitTime = Mathf.Round( Time.time - roundStartTime );
		float error = Mathf.Abs(waitTime - playerWaitTime);

		print("You waited for " + playerWaitTime + " seconds. That's " + error + " seconds off. " + GenerateMessage(error));

		if (System.DateTime.Now.Month == 12 && System.DateTime.Now.Day == 25)
		{
			playerMessage.text = "Five says Happy Birthday!";
		}
		else
		{
			playerMessage.text = "You waited for " + playerWaitTime + " seconds. That's " + error + " seconds off. " + GenerateMessage(error);
		}
			Invoke("SetNewRandomTime", roundStartDelayTime);
	}

	string GenerateMessage(float error)
	{
		string message = "";
		if (error < .5f)
		{
			message = "Outstanding!";
		}
		else if (error < 1.5f)
		{
			message = "Exceeds Expectations.";
		}
		else if (error < 2.5f)
		{
			message = "Acceptable.";
		}
		else if (error < 3.5f)
		{
			message = "Poor.";
		}
		else
		{
			message = "Dreadful.";
		}

		return message;
	}

	void SetNewRandomTime()
	{
		waitTime = Random.Range(5, 21);
		roundStartTime = Time.time;
		roundStarted = true;

		print("Target time:" + waitTime + " seconds.");
		targetTime.text = "Target time:" + waitTime + " seconds.";
		playerMessage.text = " ";
	}
}
