using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour
{
    private AudioSource playerAudioSource;
    public AudioClip[] footstepsAudioClip;
    private const string instance = " (Instance)";
    private const string wood = "Wood", green_leafs = "Green_leafs", stone = "Stone";

    private string platformColor;


    void Start()
    {
        playerAudioSource = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        FootstepsAudioClip();
    }

    AudioClip FootstepsAudioClip()
    {
        try
        {
            switch (platformColor)
            {
                case wood + instance:
                    playerAudioSource.clip = footstepsAudioClip[0];
                    break;
                case green_leafs + instance:
                    playerAudioSource.clip = footstepsAudioClip[0];
                    break;
                case stone + instance:
                    playerAudioSource.clip = footstepsAudioClip[1];
                    break;
            }
        }
        catch (MissingComponentException mce)
        {
            Debug.Log(mce);
        }
        
        return (playerAudioSource.clip);
    }
    
    void PlayAudio()
    {
        playerAudioSource.PlayOneShot(FootstepsAudioClip());
    }

    // Detect which platform the player is actually touching
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        platformColor = hit.gameObject.GetComponent<MeshRenderer>().material.name;
    }
}
