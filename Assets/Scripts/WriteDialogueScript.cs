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

    public bool startSpotlightOff;

	// Use this for initialization
	void Start () {
       
       // if(lightsOut)
        

        ProcessDialogue();
        dialogueText.color = textColor;

        if(startSpotlightOff)
        if (spotlight != null)
            spotlight.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        textTimer -= Time.deltaTime;

        if (textTimer <= 0) {

            if (actualtoWrite.Length > textIndex)
            {
                if (spotlight != null){
                    spotlight.gameObject.SetActive(true);
                    dialogueText.text += actualtoWrite[textIndex].ToString();
                    textIndex++;
                    textTimer = addTextCooldown;

                }
            }
            else endedDialogue = true;
        }
     


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
        
    }

    public bool endedCurrentDialogue()
    {
        return endedDialogue;
    }
}
