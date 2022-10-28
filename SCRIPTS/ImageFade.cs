using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageFade : MonoBehaviour
{
	public Image img;
    

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(FadeImage(true));
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerFade(bool fadeOut, int levelGo)
	{
		if (fadeOut)
		{
			StartCoroutine(FadeImageGo(false, levelGo));
		}
	}

	IEnumerator FadeImage(bool fadeAway)
	{
		// fade from opaque to transparent
		if (fadeAway)
		{
			// loop over 1 second backwards
			for (float i = 1; i >= 0; i -= Time.deltaTime*0.60f)
			{
				// set color with i as alpha
				img.color = new Color(1, 1, 1, i);
				yield return null;
			}
		}
		// fade from transparent to opaque
		else
		{
			// loop over 1 second
			for (float i = 0; i <= 1; i += Time.deltaTime)
			{
				// set color with i as alpha
				img.color = new Color(1, 1, 1, i);
				yield return null;
			}
		}
	}

	IEnumerator FadeImageGo(bool fadeAway, int level)
	{
		// fade from opaque to transparent
		if (fadeAway)
		{
			// loop over 1 second backwards
			for (float i = 1; i >= 0; i -= Time.deltaTime * 0.60f)
			{
				// set color with i as alpha
				img.color = new Color(1, 1, 1, i);
				yield return null;
			}
		}
		// fade from transparent to opaque
		else
		{
			// loop over 1 second
			for (float i = 0; i <= 1; i += Time.deltaTime)
			{
				// set color with i as alpha
				img.color = new Color(1, 1, 1, i);
				yield return null;

			}
			SceneManager.LoadScene(level + 1);
		}
	}
}
