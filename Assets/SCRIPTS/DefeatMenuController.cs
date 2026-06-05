using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenuController : MonoBehaviour
{
    [SerializeField] PlayMusic PlayMusic;

    void Start()
    {
        PlayMusic.playMenuMusic();
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
