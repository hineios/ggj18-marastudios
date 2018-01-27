using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour {

  

   public Camera humanCam;
    public Camera alienCam;

   public RawImage transImage;
   public Material camMaterial;

    public GameObject alien;
    public GameObject human;
    public bool isAlien;

    private bool transitioning, grow;
    private float shaderValue, newShaderValue;

    private RenderTexture test;

    // Use this for initialization
    void Start () {
        test =  new RenderTexture(Screen.width, Screen.height, 24);
        humanCam.targetTexture = test;
        transImage.material.mainTexture = humanCam.targetTexture;
        camMaterial = transImage.material;
        isAlien = true;
        transitioning = false;
        newShaderValue = camMaterial.GetFloat("_Clipping");
    }
	
	// Update is called once per frame
	void Update () {
        shaderValue = camMaterial.GetFloat("_Clipping");
        if (Input.GetKeyDown("e") && !transitioning)
        {
            Transition();
            transitioning = true;
        }

        if (isAlien)
        {
            human.transform.localPosition = alien.transform.localPosition;
        } else
        {
            alien.transform.localPosition = human.transform.localPosition;
        }

        if (transitioning)
        {
            if (grow && shaderValue < 1.35f)
            {
                newShaderValue += Time.deltaTime * 2;
            }
        }
	}

    public void Transition()
    {
        if (isAlien)
        {

            human.GetComponent<Rigidbody>().detectCollisions = true;
            human.GetComponent<Rigidbody>().velocity = alien.GetComponent<Rigidbody>().velocity;
            alien.GetComponent<Rigidbody>().detectCollisions = false;

            humanCam.targetTexture = null;
            alienCam.targetTexture = test;
            transImage.material.mainTexture = alienCam.targetTexture;
            camMaterial = transImage.material;

            isAlien = !isAlien;
        } else
        {

            alien.GetComponent<Rigidbody>().detectCollisions = true;
            alien.GetComponent<Rigidbody>().velocity = human.GetComponent<Rigidbody>().velocity;
            human.GetComponent<Rigidbody>().detectCollisions = false;

            alienCam.targetTexture = null;
            humanCam.targetTexture = test;
            transImage.material.mainTexture = humanCam.targetTexture;
            camMaterial = transImage.material;


            //humanCam.depth = 0;
            //alienCam.depth = 1;
            isAlien = !isAlien;
        }
        
    }
}
