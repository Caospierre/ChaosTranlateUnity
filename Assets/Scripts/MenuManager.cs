using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuExtra : MonoBehaviour
{
    [SerializeField] private Button playButton;
    void Start()
    {
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(Play);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Play()
    {
        SceneManager.LoadScene("Level1");
    }
}
