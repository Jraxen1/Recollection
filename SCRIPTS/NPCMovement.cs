using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
	public Transform[] waypoints;

	int cPos = -1;

	Transform target;

	public float speed;

	public float footSpeed;

	public float fadeSpeed;

	public GameObject leftFoot;
	public GameObject rightFoot;

	public Transform lFootReference;
	public Transform rFootReference;

	bool isMoving;

	public float waitTime;
	public float waitVariance;

	bool lFadeOut;
	bool rFadeOut;
    // Start is called before the first frame update
    void Start()
    {
		MoveOn();
    }

    // Update is called once per frame
    void Update()
    {
		if (isMoving)
		{
			transform.position += transform.forward*speed;
			if (Vector3.Distance(transform.position, target.position) <= 2f)
			{
				StopMove();
			}
		}
		else
		{
			//print("stopped");
		}

		/*if (lFadeOut)
		{
			Color color = leftFoot.GetComponent<MeshRenderer>().material.color;
			color.a -= fadeSpeed;
			leftFoot.GetComponent<MeshRenderer>().material.color = color;
		}

		if (rFadeOut)
		{
			Color color = rightFoot.GetComponent<MeshRenderer>().material.color;
			color.a -= fadeSpeed;
			rightFoot.GetComponent<MeshRenderer>().material.color = color;
		}*/
    }

    public void MoveOn()
	{


        if(cPos >= waypoints.Length-1)
		{
			cPos = -1;
		}
		
		cPos++;
		target = waypoints[cPos];
		isMoving = true;
		Vector3 lookPos = target.position - transform.position;
		lookPos.y = 0;
		var rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = rotation;

		leftFoot.transform.position = lFootReference.position;
		rightFoot.transform.position = rFootReference.position;
		leftFoot.transform.rotation = lFootReference.rotation;
		rightFoot.transform.rotation = rFootReference.rotation;

		//this.gameObject.transform.parent.transform.rotation = rotation;

		StartCoroutine("startFeet");

	}

    public void StopMove()
	{
		float finWait = waitTime + Random.Range(-waitVariance, waitVariance);
		isMoving = false;
		StopCoroutine("leftFootM");
		StopCoroutine("rightFootM");
		//Color color = leftFoot.GetComponent<MeshRenderer>().material.color;
		//color.a = 255;
		//leftFoot.GetComponent<MeshRenderer>().material.color = color;
		//rightFoot.GetComponent<MeshRenderer>().material.color = color;
		print("stop");
		leftFoot.transform.position = lFootReference.position;
		rightFoot.transform.position = rFootReference.position;
		leftFoot.transform.rotation = lFootReference.rotation;
		rightFoot.transform.rotation = rFootReference.rotation;
		print("starting pause");
		StartCoroutine("pause",finWait);
	}

	public IEnumerator pause(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		print("moving on");
		MoveOn();

	}

    public IEnumerator startFeet()
	{
		StartCoroutine("leftFootM");
		yield return new WaitForSeconds(footSpeed);
		StartCoroutine("rightFootM");
	}

	public IEnumerator leftFootM()
	{
		//leftFoot.SetActive(false);
		
		StartCoroutine("fadeLeftFoot");
		yield return new WaitForSeconds(footSpeed);
		leftFoot.transform.position = lFootReference.position;
		leftFoot.transform.rotation = lFootReference.rotation;
		
		//lFadeOut = false;
		//leftFoot.SetActive(true);
		
		yield return new WaitForSeconds(footSpeed);
		StopCoroutine("fadeLeftFoot");
		Color color = leftFoot.GetComponent<MeshRenderer>().material.color;
		color.a = 255;
		leftFoot.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
		StartCoroutine("leftFootM");

	}

    public IEnumerator rightFootM()
	{
		//rightFoot.SetActive(false);
		
		
		StartCoroutine("fadeRightFoot");
		yield return new WaitForSeconds(footSpeed);
		rightFoot.transform.position = rFootReference.position;
		rightFoot.transform.rotation = rFootReference.rotation;

		
		//rightFoot.SetActive(true);
		//lFadeOut = false;
		yield return new WaitForSeconds(footSpeed);
		StopCoroutine("fadeRightFoot");
		Color color = rightFoot.GetComponent<MeshRenderer>().material.color;
		color.a = 255;
		rightFoot.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
		StartCoroutine("rightFootM");
	}

	public IEnumerator fadeRightFoot()
	{
		
		Color color = rightFoot.GetComponent<MeshRenderer>().material.color;
		while (color.a > 0)
		{
			//color.a -= fadeSpeed;
			rightFoot.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
		}
		yield return new WaitForSeconds(0.01f);
	}

    public IEnumerator fadeLeftFoot()
	{
		
		Color color = leftFoot.GetComponent<MeshRenderer>().material.color;

        while(color.a > 0)
		{
			//color.a -= fadeSpeed;
			leftFoot.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
		}
		yield return new WaitForSeconds(0.01f);
	}



}
