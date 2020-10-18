using UnityEngine;

public class Links : MonoBehaviour
{
    public void OpenWebsiteLink() {
        Application.OpenURL("https://pmcband.ca/");
    }

    public void OpenMusicLink() {
        Application.OpenURL("");
    }

    public void OpenInstagramLink() {
        Application.OpenURL("https://www.instagram.com/pmcband/");
    }
}
