﻿using System.Collections;
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

    private float tempTexValue;

    private bool started;
    private bool start;
    private float valueTemp;

    // Use this for initialization
    void Start () {
        test =  new RenderTexture(Screen.width, Screen.height, 24);
        humanCam.targetTexture = test;
        transImage.material.mainTexture = humanCam.targetTexture;
        camMaterial = transImage.material;
        isAlien = false;
        Transition();
        grow = true;
        transitioning = false;
        newShaderValue = camMaterial.GetFloat("_Clipping");

        start = false;
        valueTemp = 0.3f;

        camMaterial.SetFloat("_Clipping", 0.3f);
    }
	
    public void startShader() { if(!started)start = true; }

	// Update is called once per frame
	void Update () {
        if (start)
        {
            valueTemp -= Time.deltaTime * 0.5f;
            camMaterial.SetFloat("_Clipping", valueTemp);
            if (valueTemp < 0.05f) { started = true; start = false; }
        }
        if(started)
        {
            shaderValue = camMaterial.GetFloat("_Clipping");
            if ((Input.GetKeyDown("e") || Input.GetButtonDown("Fire1")) && !transitioning)
            {
                //Transition();
                transitioning = true;
            }

            if (isAlien)
            {
                human.transform.position = new Vector3(alien.transform.position.x, alien.transform.position.y - 37, alien.transform.position.z);
            }
            else
            {
                alien.transform.position = new Vector3(human.transform.position.x, human.transform.position.y + 37, human.transform.position.z);
            }

            if (transitioning)
            {
                newShaderValue = shaderValue;
                if (grow && shaderValue > -0.05f)
                {
                    newShaderValue -= Time.deltaTime * 0.5f;
                    camMaterial.SetFloat("_Clipping", newShaderValue);
                }
                if (grow && shaderValue <= -0.05)
                {
                    grow = false;
                    Transition();
                }
                if (!grow && shaderValue < tempTexValue)
                {
                    newShaderValue += Time.deltaTime * 0.5f;
                    camMaterial.SetFloat("_Clipping", newShaderValue);
                }
                if (!grow && shaderValue >= tempTexValue)
                {
                    grow = true;
                    transitioning = false;
                }

            }
            else
            {
                camMaterial.SetFloat("_Clipping", Mathf.PingPong(Time.time * 0.04f, 0.04f) + 0.03f);
                tempTexValue = camMaterial.GetFloat("_Clipping");
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

            alien.GetComponent<PlayerController>().canPan = false;
            human.GetComponent<PlayerController>().canPan = true;
            alien.GetComponentInChildren<TexturePanController>().enabled = false;
            human.GetComponentInChildren<TexturePanController>().enabled = true;

            humanCam.targetTexture = null;
            alienCam.targetTexture = test;
            alienCam.cullingMask = alienCamLayer;
            humanCam.cullingMask = alienCamLayer;
            transImage.material.mainTexture = alienCam.targetTexture;
            camMaterial = transImage.material;

            isAlien = !isAlien;
        } else
        {

            alien.GetComponent<Rigidbody>().detectCollisions = true;
            alien.GetComponent<Rigidbody>().velocity = human.GetComponent<Rigidbody>().velocity;
            human.GetComponent<Rigidbody>().detectCollisions = false;

            human.GetComponent<PlayerController>().canPan = false;
            alien.GetComponent<PlayerController>().canPan = true;
            human.GetComponentInChildren<TexturePanController>().enabled = false;
            alien.GetComponentInChildren<TexturePanController>().enabled = true;

            alienCam.targetTexture = null;
            humanCam.targetTexture = test;
            humanCam.cullingMask = humanCamLayer;
            alienCam.cullingMask = humanCamLayer;
            transImage.material.mainTexture = humanCam.targetTexture;
            camMaterial = transImage.material;

            isAlien = !isAlien;
        }
        
    }
}
