using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject playMenu;
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private Button restart;

    private void Start()
    {
        SetActivePlayWindow();
        restart.onClick.AddListener(ResetScene);
    }

    public void SetActiveLoseWindow()
    {
        playMenu.SetActive(false);
        loseMenu.SetActive(true);
        text.text = timer.GetElapsedTime();
        timer.ResetTimer();
        
    }

    public void SetActivePlayWindow()
    {
        playMenu.SetActive(true);
        loseMenu.SetActive(false);
        timer.StartTimer();
    }

    public void ResetScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}
