using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryObtainable : MonoBehaviour
{
	public int memoryID;
	public GameObject infoText;

	// Start is called before the first frame update
	void Start()
    {
		infoText.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ShowInfoText()
	{
		infoText.SetActive(true);
	}

	public void HideInfoText()
	{
		infoText.SetActive(false);
	}
}
