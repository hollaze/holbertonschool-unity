using UnityEngine;
using UnityEngine.Audio;

public class FootstepsAudio : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup[] _audioMixerGroups;
    private AudioSource _playerAudioSource;
    [SerializeField] private AudioClip[] _footstepsAudioClip;

    private const string _instance = " (Instance)";
    private const string _wood = "Wood", _green_leafs = "Green_leafs", _stone = "Stone";
    private string _platformColor;


    void Start()
    {
        _playerAudioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        FootstepsAudioClip();
        FootstepsLandingAudioClip();
    }

    AudioClip FootstepsAudioClip()
    {
        switch (_platformColor)
        {
            case _wood + _instance:
                _playerAudioSource.clip = _footstepsAudioClip[0];
                break;
            case _green_leafs + _instance:
                _playerAudioSource.clip = _footstepsAudioClip[0];
                break;
            case _stone + _instance:
                _playerAudioSource.clip = _footstepsAudioClip[1];
                break;
        }

        return (_playerAudioSource.clip);
    }

    AudioClip FootstepsLandingAudioClip()
    {
        switch (_platformColor)
        {
            case _wood + _instance:
                _playerAudioSource.clip = _footstepsAudioClip[2];
                break;
            case _green_leafs + _instance:
                _playerAudioSource.clip = _footstepsAudioClip[2];
                break;
            case _stone + _instance:
                _playerAudioSource.clip = _footstepsAudioClip[3];
                break;
        }
        return (_playerAudioSource.clip);
    }

    void PlayAudio()
    {
        if (PlayerController.m_ClipName == "Falling Flat Impact")
        {
            _playerAudioSource.outputAudioMixerGroup = _audioMixerGroups[1];
            _playerAudioSource.PlayOneShot(FootstepsLandingAudioClip());
        }
        else if (PlayerController.m_ClipName == "Running")
        {
            _playerAudioSource.outputAudioMixerGroup = _audioMixerGroups[0];
            _playerAudioSource.volume = Random.Range(0.6f, 1f);
            _playerAudioSource.PlayOneShot(FootstepsAudioClip());
        }
    }

    // Detect which platform the player is actually touching
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        try
        {
            _platformColor = hit.gameObject.GetComponent<MeshRenderer>().material.name;
        }
        catch (MissingComponentException)
        {
            // Empty
        }
    }
}
