using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject player;
	public Transform[] spawnLocations;
	bool setPos = false;

    // Start is called before the first frame update
    void Start()
    {
		setPos = false;
		print("_" + PlayerPrefs.GetInt("Memories"));

        
    }

    // Update is called once per frame
    void Update()
    {
		if (!setPos)
		{
			if (PlayerPrefs.GetInt("Memories", 0) == 0)
			{

			}
			else if (PlayerPrefs.GetInt("Memories") == 1)
			{
				player.transform.position = spawnLocations[0].position;
				player.transform.rotation = spawnLocations[0].rotation;
				setPos = true;
			}
		}
		
	}
}
