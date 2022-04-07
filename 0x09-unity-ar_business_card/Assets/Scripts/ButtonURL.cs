using UnityEngine;


public class ButtonURL : MonoBehaviour
{
    public Transform mailButton;
    private GameObject mailText;
    
    private void Start()
    {
        mailText = mailButton.GetChild(0).gameObject;
    }
    
    public void Mail()
    {
        if (mailText.activeSelf)
            mailText.SetActive(false);
        else
            mailText.SetActive(true);
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/ADeperiers");
    }

    public void Linkedin()
    {
        Application.OpenURL("https://linkedin.com/in/deperiers-a-355510206");
    }

    public void Github()
    {
        Application.OpenURL("https://github.com/hollaze");
    }
}
