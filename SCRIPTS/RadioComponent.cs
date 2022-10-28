using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioComponent : MonoBehaviour
{
	public bool isMainMenu;
	public AudioClip[] songs;
	public AudioSource source;

	public int songNumber;

	bool isPausing;

    // Start is called before the first frame update
    void Start()
    {
		if (isMainMenu)
		{
			songNumber = 2;
			source.clip = songs[songNumber];
			source.Play();
		}
		else
		{
			songNumber = Random.Range(0, songs.Length);
			source.clip = songs[songNumber];
			source.Play();
		}
		
    }

    // Update is called once per frame
    void Update()
    {
		if (!source.isPlaying && !isPausing)
		{
			isPausing = true;
			StartCoroutine("NextSong");
		}
    }

    IEnumerator NextSong()
	{
		yield return new WaitForSeconds(4);
		int random = Random.Range(0, songs.Length);
		while (random == songNumber)
		{
			random = Random.Range(0, songs.Length);
		}
		songNumber = random;
		source.clip = songs[songNumber];
		source.Play();
		isPausing = false;

	}
}
