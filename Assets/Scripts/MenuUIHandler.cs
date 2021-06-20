using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    [SerializeField] private InputField inputName;
    [SerializeField] private Text BestScoreMenuText;

    private void Awake()
    {
        if (MainMainManager.Instance != null)
        {
            Debug.Log("INININ");
            BestScoreMenuText.text = "Best Score - " + MainMainManager.Instance.BestName + " - " + MainMainManager.Instance.BestScore;
        }
    }
        
    

    public void ExitGame()
    {
        MainMainManager.Instance.SaveRecord();
        Debug.Log("BestScore is: " + MainMainManager.Instance.BestScore + "" +
            "BestName is:" + MainMainManager.Instance.BestName);
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    public void StartGame()
    {
        
        MainMainManager.Instance.Name = inputName.text;
        SceneManager.LoadScene(1);
    }

}
