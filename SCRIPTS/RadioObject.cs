using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadioObject : MonoBehaviour
{
	public GameObject radioCanvas;
	bool isRadioShowing = false;
	public GameObject infoText;
    public GameObject[] buttons;

	public ImageFade fade;

	public bool isMainRadio;

    // Start is called before the first frame update
    void Start()
    {
		radioCanvas.SetActive(false);
		infoText.SetActive(false);

		if (isMainRadio)
		{
			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i].SetActive(false);
			}

			if (PlayerPrefs.GetInt("Memories", 0) == 0)
			{
				buttons[0].SetActive(true);
			}
			else if (PlayerPrefs.GetInt("Memories", 0) == 1)
			{
				buttons[0].SetActive(true);
				buttons[1].SetActive(true);
			}
			else if (PlayerPrefs.GetInt("Memories", 0) >= 2)
			{
				buttons[0].SetActive(true);
				buttons[1].SetActive(true);
				buttons[2].SetActive(true);
			}
		}
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowRadio()
	{
		
		if (isMainRadio)
		{
			radioCanvas.SetActive(true);
		}
		else
		{
			GoLevel(0);
		}
	}

    public void GoLevel(int levelID)
	{
		radioCanvas.SetActive(false);
		fade.TriggerFade(true,levelID);
		
	}

    public void ShowInfoText()
	{
		infoText.SetActive(true);
	}

    public void QuitGame()
	{
		Application.Quit();
	}

    public void HideInfoText()
	{
		infoText.SetActive(false);
	}
}
