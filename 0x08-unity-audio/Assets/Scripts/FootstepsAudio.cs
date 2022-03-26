using UnityEngine;
using UnityEngine.Audio;

public class FootstepsAudio : MonoBehaviour
{
    public AudioMixerGroup[] audioMixerGroups;
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
        FootstepsLandingAudioClip();
    }

    AudioClip FootstepsAudioClip()
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

        return (playerAudioSource.clip);
    }

    AudioClip FootstepsLandingAudioClip()
    {
        switch (platformColor)
        {
            case wood + instance:
                playerAudioSource.clip = footstepsAudioClip[2];
                break;
            case green_leafs + instance:
                playerAudioSource.clip = footstepsAudioClip[2];
                break;
            case stone + instance:
                playerAudioSource.clip = footstepsAudioClip[3];
                break;
        }
        return (playerAudioSource.clip);
    }

    void PlayAudio()
    {
        if (PlayerController.m_ClipName == "Falling Flat Impact")
        {
            playerAudioSource.outputAudioMixerGroup = audioMixerGroups[1];
            playerAudioSource.PlayOneShot(FootstepsLandingAudioClip());
        }
        else if (PlayerController.m_ClipName == "Running")
        {
            playerAudioSource.outputAudioMixerGroup = audioMixerGroups[0];
            playerAudioSource.volume = Random.Range(0.6f, 1f);
            playerAudioSource.PlayOneShot(FootstepsAudioClip());
        }
    }

    // Detect which platform the player is actually touching
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        try
        {
            platformColor = hit.gameObject.GetComponent<MeshRenderer>().material.name;
        }
        catch (MissingComponentException)
        {
            // Empty
        }
    }
}
