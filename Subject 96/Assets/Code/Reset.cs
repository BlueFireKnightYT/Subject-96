using UnityEngine;
using UnityEngine.SceneManagement;
public class Reset : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            ResetScene();
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
