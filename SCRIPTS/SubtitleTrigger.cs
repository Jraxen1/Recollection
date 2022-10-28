using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleTrigger : MonoBehaviour
{
	bool hasBeenTriggered = false;

    void OnTriggerEnter(Collider other)
	{
        if(other.gameObject.tag == "Player" && !hasBeenTriggered)
		{
			GameObject.FindWithTag("Subtitles").GetComponent<SubtitleManager>().TriggerNextLine();
			hasBeenTriggered = true;
		}
		
	}
}
