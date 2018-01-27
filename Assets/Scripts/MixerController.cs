using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour {

    public const float LP_ACTIVE = 300f;
    public const float LP_INACTIVE = 22000f;
    public GameObject Listener;
    public GameObject AudioSource;
    public AudioMixer Mixer;
    public GameObject Transition;
    private TransitionController t;
    private bool HasLowPass = true;

    private void Awake()
    {
        t = Transition.GetComponent<TransitionController>();
    }

    void SetLowpassCutoff(bool b)
    {
        if(HasLowPass != b)
        {
            HasLowPass = !HasLowPass;
            if (HasLowPass)
            {
                Mixer.SetFloat("LowpassCutoff", LP_ACTIVE);
            }
            else
            {
                Mixer.SetFloat("LowpassCutoff", LP_INACTIVE);
            }
            
        }
            
    }

    void SetVolume(float c)
    {
        Mixer.SetFloat("Volume", c);
    }
	
	// Update is called once per frame
	void Update ()
    {
        SetLowpassCutoff(t.isAlien);
        float d = Mathf.Abs(Listener.transform.position.x - AudioSource.transform.position.x);

        SetVolume(Mathf.Clamp(-d , -40, 0));
	}
}
