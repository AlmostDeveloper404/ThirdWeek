using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("More than one instance!");
            return;
        }
        instance = this;
    }

    #endregion

    public Text LivesText;
    public Text MoneyText;

    
    public void UpdateLives(int health)
    {
        LivesText.text = "Lives: "+health;
    }

    public void UpdateMoney(int currentMoney,int maxMoney)
    {
        MoneyText.text = currentMoney + " / " + maxMoney;
    }
}
