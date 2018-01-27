using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour {

  

   public Camera humanCam;
    public Camera alienCam;
    public LayerMask humanCamLayer;
    public LayerMask alienCamLayer;
    public LayerMask baseCamLayer;

    public RawImage transImage;
   public Material camMaterial;

    public GameObject alien;
    public GameObject human;
    public bool isAlien;

    private bool transitioning, grow;
    public float shaderValue, newShaderValue;

    private RenderTexture test;

    // Use this for initialization
    void Start () {
        test =  new RenderTexture(Screen.width, Screen.height, 24);
        humanCam.targetTexture = test;
        transImage.material.mainTexture = humanCam.targetTexture;
        camMaterial = transImage.material;
        isAlien = true;
        grow = true;
        transitioning = false;
        newShaderValue = camMaterial.GetFloat("_Clipping");
    }
	
	// Update is called once per frame
	void Update () {
        shaderValue = camMaterial.GetFloat("_Clipping");
        if (Input.GetKeyDown("e") && !transitioning)
        {
            //Transition();
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
                newShaderValue += 3 * Time.deltaTime;
                camMaterial.SetFloat("_Clipping", newShaderValue);
            }
            if (grow && shaderValue >= 1.35f)
            {
                grow = false;
                Transition();
            }
            if(!grow && shaderValue > 0.75f)
            {
                newShaderValue -= 3 * Time.deltaTime;
                camMaterial.SetFloat("_Clipping", newShaderValue);
            }
            if (!grow && shaderValue <= 0.75f)
            {
                grow = true;
                transitioning = false;
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
            alienCam.cullingMask = alienCamLayer;
            humanCam.cullingMask = baseCamLayer;
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
            humanCam.cullingMask = humanCamLayer;
            alienCam.cullingMask = baseCamLayer;
            transImage.material.mainTexture = humanCam.targetTexture;
            camMaterial = transImage.material;


            //humanCam.depth = 0;
            //alienCam.depth = 1;
            isAlien = !isAlien;
        }
        
    }
}
