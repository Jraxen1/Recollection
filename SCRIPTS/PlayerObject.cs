using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObject : MonoBehaviour
{

	public bool inGrayRoom;

	public Transform camTransform;
	public Camera camera;

	public GameObject radio;

	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

	GameObject cMemory;

	public bool inUI;

	GameObject currentUI;
    

    // Start is called before the first frame update
    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		/*if (!inGrayRoom)
		{
			radio = GameObject.FindWithTag("Radio");
		}*/
		
	}

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!inUI)
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			else
			{
				currentUI.SetActive(false);
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				controller.m_MouseLook.XSensitivity = 2;
				controller.m_MouseLook.YSensitivity = 2;
			}
			
		}

		if (Input.GetMouseButtonDown(0) && !inUI)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		

		    
			
	}

    void FixedUpdate()
	{

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 20))
			/*if(hit.collider != null)
			{
				print(hit.collider.gameObject.name);
			}*/


			if (inGrayRoom)
			{
				if (hit.collider.gameObject.tag == "Radio")
				{
					radio.GetComponent<RadioObject>().ShowInfoText();
					//print("Looking at radio");

					if (Input.GetKeyDown(KeyCode.E))
					{
						print("UI");
						inUI = true;

						controller.m_MouseLook.XSensitivity = 0;
						controller.m_MouseLook.YSensitivity = 0;

						currentUI = hit.collider.gameObject.GetComponent<RadioObject>().radioCanvas;

						hit.collider.gameObject.GetComponent<RadioObject>().ShowRadio();
						Cursor.lockState = CursorLockMode.None;
						Cursor.visible = true;
					}
				}
				else
				{
					radio.GetComponent<RadioObject>().HideInfoText();
				}

                if(hit.collider.gameObject.tag == "MemoryObj")
				{

					if (Input.GetKeyDown(KeyCode.E))
					{
						hit.collider.gameObject.GetComponent<MemoryObject>().EnableCanvas();
						inUI = true;
						currentUI = hit.collider.gameObject.GetComponent<MemoryObject>().memoryCanvas;

						controller.m_MouseLook.XSensitivity = 0;
						controller.m_MouseLook.YSensitivity = 0;

						Cursor.lockState = CursorLockMode.None;
						Cursor.visible = true;
					}
					

				}
			}
			else
			{
				if (hit.collider.gameObject.tag == "Memory")
				{
					//radio.GetComponent<RadioObject>().ShowInfoText();
					//print("Looking at radio");

					cMemory = hit.collider.gameObject;
					cMemory.GetComponent<MemoryObtainable>().ShowInfoText();
					if (Input.GetKeyDown(KeyCode.E))
					{
						/*print("UI");
						inUI = true;

						controller.m_MouseLook.XSensitivity = 0;
						controller.m_MouseLook.YSensitivity = 0;

						//hit.collider.gameObject.GetComponent<RadioObject>().ShowRadio();
						Cursor.lockState = CursorLockMode.None;
						Cursor.visible = true;*/

						ObtainMemory(hit.collider.gameObject.GetComponent<MemoryObtainable>().memoryID);
					}
				}
				else if (cMemory != null)
				{
					cMemory.GetComponent<MemoryObtainable>().HideInfoText();
				}

				if (hit.collider.gameObject.tag == "Radio")
				{
					radio.GetComponent<RadioObject>().ShowInfoText();
					//print("Looking at radio");

					if (Input.GetKeyDown(KeyCode.E))
					{
						radio.GetComponent<RadioObject>().ShowRadio();
					}
				}
				else
				{
					radio.GetComponent<RadioObject>().HideInfoText();
				}
			}
	}

    public void ObtainMemory(int ID)
	{
		PlayerPrefs.SetInt("Memories", ID);
		PlayerPrefs.SetInt("memoryTrigger", 1);
		radio.GetComponent<RadioObject>().GoLevel(0);
	}
}
