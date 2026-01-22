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

    void ResetScene()
    {
        SceneManager.LoadScene("PLAYROOM");
    }
}
