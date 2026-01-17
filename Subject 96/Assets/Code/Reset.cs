using UnityEngine;
using UnityEngine.SceneManagement;
    public class Reset : MonoBehaviour
{
   
    void Start()
    {
        
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneLoad();
        }
    }

    private void SceneLoad()
    {
        SceneManager.LoadScene("PLAYROOM");
    }
}
