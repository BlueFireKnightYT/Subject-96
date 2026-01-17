using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Player.position;
    }
}
