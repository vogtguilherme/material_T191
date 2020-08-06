using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectObject : MonoBehaviour
{
    private AudioSource m_AudioSource = null;

    [SerializeField]
    private AudioClip m_AudioClip = null;

    [SerializeField] private AudioMixer m_AudioMixer = null;

    [SerializeField] private AudioMixerSnapshot normal = null;
    [SerializeField] private AudioMixerSnapshot paused = null;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = m_AudioClip;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if (m_AudioClip != null)
                m_AudioSource.Play();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused.TransitionTo(0.75f);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            normal.TransitionTo(0.5f);
        }
    }
}
