
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class CustomSceneManager : MonoBehaviour
{
    private const int PlaySceneIndex = 1;
    private const int MenuIndex = 0;
    public void Play()
    {
        DataManager.Instance.SaveName();
        SceneManager.LoadScene(PlaySceneIndex);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #endif
        Application.Quit();
    }
}