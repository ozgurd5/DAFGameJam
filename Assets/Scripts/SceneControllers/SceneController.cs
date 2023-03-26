using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public CompletedNPC completedNpc;

    [Header("Don't Touch")]
    public Scene curretScene;

    private void Start()
    {
        curretScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (completedNpc.completedNPCNumber >= 2)
        {
            if (curretScene.name == "Level 1")
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (curretScene.name == "Level 2")
            {
                SceneManager.LoadScene("Level 3");
            }
            else if (curretScene.name == "Level 3")
            {
                SceneManager.LoadScene("Level 4");
            }
            else if (curretScene.name == "Level 4")
            {
                SceneManager.LoadScene("Level 5");
            }
            else if (curretScene.name == "Level 5")
            {
                SceneManager.LoadScene("Level 6");
            }
            else if (curretScene.name == "Level 6")
            {
                SceneManager.LoadScene("Level 7");
            }
            else if (curretScene.name == "Level 7")
            {
                SceneManager.LoadScene("Level 8");
            }
        }
    }
}
