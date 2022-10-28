using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryManager : MonoBehaviour
{

	public GameObject[] memoryObjects;
	public bool[] hasMemory;

	public GameObject recollectText;


    // Start is called before the first frame update
    void Start()
    {
		hasMemory = new bool[memoryObjects.Length];


		CheckPrefs();

		UpdateMemories();

		if (PlayerPrefs.GetInt("memoryTrigger", 0) == 1)
		{
			StartCoroutine("RememberMemory");
		}

	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.U))
		{
			PlayerPrefs.DeleteAll();
		}
    }

    public void CheckPrefs()
	{
        if(PlayerPrefs.GetInt("Memories",0) == 0)
		{
			for (int i = 0; i < hasMemory.Length; i++)
			{
				hasMemory[i] = false;
			}
		}
		

		if (PlayerPrefs.GetInt("Memories", 0) == 1)
		{
			hasMemory[0] = true;
			
		}

        if(PlayerPrefs.GetInt("Memories", 0) == 2)
		{
			hasMemory[0] = true;
			hasMemory[1] = true;
			

		}
		if (PlayerPrefs.GetInt("Memories", 0) == 3)
		{
			hasMemory[0] = true;
			hasMemory[1] = true;
			hasMemory[2] = true;
			

		}



	}

    IEnumerator RememberMemory()
	{
		recollectText.SetActive(true);
        yield return new WaitForSeconds(3);
		recollectText.SetActive(false);
		PlayerPrefs.SetInt("memoryTrigger", 0);

	}

    public void UpdateMemories()
	{
        for(int i = 0; i < memoryObjects.Length; i++)
		{
            if(hasMemory[i])
			{
				memoryObjects[i].GetComponent<MemoryObject>().EnableMemory();
			}
		}
	}
}
