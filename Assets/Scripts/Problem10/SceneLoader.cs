using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string mainMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Quit();
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void Quit()
    {
        if (SceneManager.GetActiveScene().name != mainMenu)
            LoadScene(mainMenu);
        else
            Application.Quit();
    }
}
