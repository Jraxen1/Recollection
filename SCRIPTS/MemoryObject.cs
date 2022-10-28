using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryObject : MonoBehaviour
{

	public MeshRenderer renderer;
	public Material memoryMat;
	public MeshRenderer[] frameRenderer;
	public Material frameMat;
	public MeshRenderer[] altRenderers;
	public Material altColor;

	public GameObject eText;

	bool isEnabled;

	public GameObject memoryCanvas;
	// Start is called before the first frame update
	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableCanvas()
	{
		memoryCanvas.SetActive(true);
		
	}

    public void DisableCanvas()
	{
		memoryCanvas.SetActive(false);
	}

    public void EnableMemory()
	{
		renderer.material = memoryMat;
		eText.SetActive(true);
        for(int i = 0; i < frameRenderer.Length; i++)
		{
			frameRenderer[i].material = frameMat;
		}

		for (int i = 0; i < altRenderers.Length; i++)
		{
			altRenderers[i].material = altColor;
		}


	}
}
