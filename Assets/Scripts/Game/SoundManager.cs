using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Button button;
    private bool ismuted=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MuteChannel()
    {
        if (ismuted == true)
        {
            myMixer.SetFloat("MasterVolume", Mathf.Log10(-80) * 20f);
            ismuted = false;
        }
        else
        {
            myMixer.SetFloat("MasterVolume", Mathf.Log10(0) * 20f);
            ismuted = true;
        }
    }
}
