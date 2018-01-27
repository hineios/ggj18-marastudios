using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour {

    public GameObject Listener;
    public GameObject AudioSource;
    public AudioMixer Mixer;

    void SetLowpassCutoff(float c)
    {
        Mixer.SetFloat("LowpassCutoff", c);
    }
	
	// Update is called once per frame
	void Update () {
        float d = Mathf.Abs(Listener.transform.position.x - AudioSource.transform.position.x);

        SetLowpassCutoff(Mathf.Clamp(6000/d, 100, 3000));
	}
}
