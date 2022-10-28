using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public bool inInstructions = false;

	public GameObject instructionsObject;
	public GameObject mainObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
	{
		print("startGame");
		SceneManager.LoadScene(1);
	}

    public void Instructions()
	{
		print("instructions");
		inInstructions = true;
		mainObject.SetActive(false);
		instructionsObject.SetActive(true);

	}

    public void BackToMain()
	{
		inInstructions = false;
		instructionsObject.SetActive(false);
		mainObject.SetActive(true);

	}

    public void QuitGame()
	{
		Application.Quit();
		print("quitGame");
	}
}
