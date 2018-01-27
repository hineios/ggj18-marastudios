using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class ManageDialoguesScript : MonoBehaviour
{

  
    [Serializable]
    public struct Dialogue
    {
        public string Actor;
        public string dialog;
    }
    public Dialogue[] dialoguesList;

    private List<WriteDialogueScript> dialogueScripts;


    public float changeTextCooldown;

    private float actualCountDown;

    private WriteDialogueScript target;

    private int index = 0;
    // Use this for initialization
    void Start()
    {

        TurnLightingOff();

        actualCountDown = changeTextCooldown;

        index = 0;

        dialogueScripts = new List<WriteDialogueScript>();

        foreach (var g in GameObject.FindGameObjectsWithTag("Talk"))
        {
            dialogueScripts.Add(g.GetComponent<WriteDialogueScript>());
        }



    }

    // Update is called once per frame
    void Update()
    {

        if (getTargetEndedSpeaking())
        {
            actualCountDown -= Time.deltaTime;

            if (actualCountDown <= 0)
            {
                if (index == 3)
                    TurnLightingOn();

                AdvanceDialogue();

                actualCountDown = changeTextCooldown;
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

    }

    public void TurnLightingOff()
    {
        RenderSettings.ambientIntensity = 0;
        RenderSettings.reflectionIntensity = 0;
    }

    public void TurnLightingOn()
    {
       var d = GameObject.FindGameObjectsWithTag("ToDestroy");
        foreach (var o in d)
            Destroy(o);
        RenderSettings.ambientIntensity = 1;
        RenderSettings.reflectionIntensity = 1;

        PlayMovie();
    }

    private bool getTargetEndedSpeaking()
    {
        if (target != null)
        {
            return target.endedCurrentDialogue();
        } return true;
    }


    private void AdvanceDialogue()
    {

        if (index < dialoguesList.Length)
        {

            var Name = dialoguesList[index].Actor;

            var dialog = dialoguesList[index].dialog;

            target = dialogueScripts.Find(x => x.gameObject.name == Name);

            target.setDialogueToWrite(dialog);

         

            index++;

           
        }

            
       
    }


    void PlayMovie()
    {
        GameObject.Find("Screen").GetComponent<VideoPlayer>().Play();
    }
}
