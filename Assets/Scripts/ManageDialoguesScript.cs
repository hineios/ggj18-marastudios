using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageDialoguesScript : MonoBehaviour {


    public List<string> dialogueList;

    public GameObject commanderCharacter;

    private WriteDialogueScript mainCharacterScript;

    public float changeTextCooldown;

    private float actualCountDown;

    private int index = 0;
	// Use this for initialization
	void Start () {

        RenderSettings.ambientIntensity = 0;
        RenderSettings.reflectionIntensity = 0;

        mainCharacterScript = commanderCharacter.GetComponent<WriteDialogueScript>();

        mainCharacterScript.setDialogueToWrite(dialogueList[0]);

        actualCountDown = changeTextCooldown;

        index = 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (mainCharacterScript.endedCurrentDialogue())
        {
            actualCountDown -= Time.deltaTime;

            if(actualCountDown <= 0)
            if (index < dialogueList.Count)
            {

                    if (index == 1)
                    {
                        RenderSettings.ambientIntensity = 1;
                        RenderSettings.reflectionIntensity = 1;
                    }

                    mainCharacterScript.setDialogueToWrite(dialogueList[index]);
                index++;
                    actualCountDown = changeTextCooldown;

            }

        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index < dialogueList.Count)
            {

                if(index == 1)
                {
                    RenderSettings.ambientIntensity = 1;
                    RenderSettings.reflectionIntensity = 1;
                }
                mainCharacterScript.setDialogueToWrite(dialogueList[index]);
                index++;

            }
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

        }

	}
}
