using UnityEngine.Animations;
using UnityEngine;

public class TargetFound : MonoBehaviour
{
    public GameObject linkedinButton;
    public GameObject emailButton;
    public GameObject twitterButton;
    public GameObject githubButton;

    public void TargetIsFound()
    {
        linkedinButton.GetComponent<Animator>().enabled = true;
        emailButton.GetComponent<Animator>().enabled = true;
        twitterButton.GetComponent<Animator>().enabled = true;
        githubButton.GetComponent<Animator>().enabled = true;
    }
}
