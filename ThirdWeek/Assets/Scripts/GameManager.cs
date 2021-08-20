using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("More than one GameManager!");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject endTextPanel;
    public void Win()
    {
        endTextPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        Debug.Log("game over");
        endTextPanel.GetComponentInChildren<Text>().text = "Не ок";
        endTextPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
