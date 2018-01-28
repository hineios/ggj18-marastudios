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
        public AudioClip voice;
    }
    public Dialogue[] dialoguesList;

    private List<WriteDialogueScript> dialogueScripts;

    public string PlayerMovieAtDialog;

    public float changeTextCooldown;

    private float actualCountDown;

    private WriteDialogueScript target;

    private GameObject directLight;

    public float turnLightsIndex;

    private bool lightsoffOnce = false;

    private bool turningLightsOn = false;

    public float endConversationX;

    private bool playingMovie = false;

    public float movieDuration;

    private float actuaMovieDuration;

    private int index = 0;
    // Use this for initialization
    void Awake()
    {
     

        TurnLightingOff();

        actualCountDown = changeTextCooldown;

        actuaMovieDuration = movieDuration;

        index = 0;

        dialogueScripts = new List<WriteDialogueScript>();

        foreach (var g in GameObject.FindGameObjectsWithTag("Talk"))
        {
            dialogueScripts.Add(g.GetComponent<WriteDialogueScript>());
        }

        dialogueScripts.Add(GameObject.Find("Player_alien").GetComponent<WriteDialogueScript>());

    }

    // Update is called once per frame
    void Update()
    {

        if (playingMovie)
        {
            actualCountDown -= Time.deltaTime * 0.1f;

            if (actualCountDown <= 0)
                StopMovie();

            else return;

        } else

        if (getTargetEndedSpeaking())
        {
            actualCountDown -= Time.deltaTime;

            if (actualCountDown <= 0)
            {
               

                AdvanceDialogue();

                actualCountDown = changeTextCooldown;
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceDialogue();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (turningLightsOn)
        {
            TurningOnLights();
        }

        if (GameObject.Find("Player_alien").transform.position.x > endConversationX)
            EndedDialogue();
     
    }

    public void TurnLightingOff()
    {
    //    RenderSettings.ambientLight = new Color(1.0f, 1.0f, 1.0f);
        RenderSettings.ambientIntensity = 0;
        RenderSettings.reflectionIntensity = 0;
        directLight = GameObject.FindGameObjectWithTag("Activate");
        directLight.SetActive(false);
    }

    public void TurnLightingOn()
    {

       var d = GameObject.FindGameObjectsWithTag("ToDestroy");
        foreach (var o in d)
            Destroy(o);
        lightsoffOnce = true;
        turningLightsOn = true;
    //    RenderSettings.ambientLight = new Color(0.5f, 0.5f,0.5f);
       

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

            target = dialogueScripts.Find(x => x.name == Name);

            target.setDialogueToWrite(dialog);

            if (dialoguesList[index].voice != null)
            {
                target.GetComponentInChildren<AudioSource>().clip = dialoguesList[index].voice;
                target.GetComponentInChildren<AudioSource>().Play();
            }

            if (dialog == PlayerMovieAtDialog)
                PlayMovie();

            if (index == turnLightsIndex)
                TurnLightingOn();

            index++;

        } 
            
    }


    void PlayMovie()
    {
        playingMovie = true;
        GameObject.Find("Television").GetComponent<TelevisionMovement>().Move("Down");
    }

    void StopMovie()
    {
        GameObject.Find("Screen").GetComponent<VideoPlayer>().Stop();
        GameObject.Find("Television").GetComponent<TelevisionMovement>().Move("Up");
        playingMovie = false;
    }

    void TurningOnLights()
    {
        directLight.SetActive(true);
        RenderSettings.ambientIntensity += 0.01f;
        RenderSettings.reflectionIntensity += 0.01f;

        directLight.GetComponent<Light>().intensity += 0.005f;
      
        if (RenderSettings.ambientIntensity >= 1.0f)
        {
           // directLight.SetActive(true);
            turningLightsOn = false;
            //GameObject.Find("Player_alien").GetComponentInChildren<Light>().intensity = 0;
           // GameObject.Find("Chief").GetComponentInChildren<Light>().color = new Color(1, 1, 1);
        }
    }


    public void EndedDialogue()
    {
        foreach (var o in GameObject.FindGameObjectsWithTag("Destroythis"))
            Destroy(o);
        if (lightsoffOnce == false)
            TurnLightingOn();


        var audioSource = GameObject.FindGameObjectWithTag("ObjectiveSong").GetComponent<AudioSource>();

        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}
