using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class WriteDialogueScript : MonoBehaviour {

    public Text dialogueText;

    public string toWrite;

    private char[] actualtoWrite;

    public float addTextCooldown;

    private float textTimer;

    public Color textColor;

    public Light spotlight;

    private bool endedDialogue;

    private float originalSpotIntensity;

    public bool lightsOut;

    private int textIndex;
	// Use this for initialization
	void Start () {
       
       // if(lightsOut)
        

        ProcessDialogue();
        dialogueText.color = textColor;

        RenderSettings.ambientIntensity = 0;
        RenderSettings.reflectionIntensity = 0;
        if (spotlight != null)
            spotlight.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        textTimer -= Time.deltaTime;

        if (textTimer <= 0) {

            if (actualtoWrite.Length > textIndex)
            {
                spotlight.gameObject.SetActive(true);
                dialogueText.text += actualtoWrite[textIndex].ToString();
                textIndex++;
                textTimer = addTextCooldown;
                spotlight.intensity += 0.3f;

            }
            else endedDialogue = true;
        }
        else spotlight.intensity -= 0.01f;


    }

    public void setDialogueToWrite( string s)
    {
        toWrite = s;

        ProcessDialogue();
    }

    void ProcessDialogue()
    {
        dialogueText.text = "";
        textIndex = 0;
        textTimer = addTextCooldown;
        endedDialogue = false;
        actualtoWrite = toWrite.ToCharArray();
        spotlight.intensity = originalSpotIntensity;
    }

    public bool endedCurrentDialogue()
    {
        return endedDialogue;
    }
}
