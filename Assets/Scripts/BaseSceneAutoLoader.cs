using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseSceneAutoLoader
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadBaseScene()
    {
        const string baseSceneName = "BaseScene";

        // ˆê“x‚¾‚¯ƒ[ƒh‚·‚é
        if (!SceneManager.GetSceneByName(baseSceneName).IsValid())
        {
            SceneManager.LoadScene(baseSceneName, LoadSceneMode.Additive);
        }
    }
}
