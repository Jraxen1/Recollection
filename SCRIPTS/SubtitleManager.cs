using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
	public string[] lines;
	public int cPos = 0;

	public TextMeshProUGUI subText;
	public TextMeshProUGUI subName;

	public float moveSpeed;

    // Line parse: "name,text"

    // Start is called before the first frame update
    void Start()
    {
		UpdateSubtitles(false);
    }

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKeyDown(KeyCode.K))
		{
			TriggerNextLine();
		}
        
    }

    public void UpdateSubtitles(bool isDone)
	{
		if (!isDone)
		{
			string[] currentLine = lines[cPos].Split(',');
			print(currentLine[0] + ":" + currentLine[1]);
			subText.text = currentLine[1];
			subName.text = currentLine[0];
			StopCoroutine("setTime");
			StartCoroutine(setTime(float.Parse(currentLine[2]),bool.Parse(currentLine[3])));
		}
		else if(isDone)
		{
			//print("tttt");
			subText.text = "";
			subName.text = "";
		}
		
		
	}

    public void OffSubtitles()
	{
		subText.text = "";
		subName.text = "";
	}

    public void TriggerNextLine()
	{
		cPos++;
        if(lines.Length <= cPos)
		{
			UpdateSubtitles(true);
		}
		else
		{
			UpdateSubtitles(false);
		}
		
	}

    public IEnumerator setTime(float seconds, bool goNext)
	{
		yield return new WaitForSeconds(moveSpeed);
		if (goNext)
		{
			TriggerNextLine();
		}
		else
		{
			OffSubtitles();
		}
		
	}
}
