using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour {

  

   public Camera humanCam;
    public Camera alienCam;

   public RawImage transImage;
    public Material camMaterial;

    // Use this for initialization
    void Start () {
        humanCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        transImage.material.mainTexture = humanCam.targetTexture;


        camMaterial = transImage.material;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            Transition();
        }
	}

    public void Transition()
    {
        camMaterial.SetFloat("_Clipping", 0.4f);
    }
}
