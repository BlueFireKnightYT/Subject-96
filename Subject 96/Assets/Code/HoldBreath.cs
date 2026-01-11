using UnityEngine;

public class HoldBreath : MonoBehaviour
{
    float maxHoldBreathTime = 10f;
    float endTime;

    bool holdingBreath = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            holdingBreath = true;
            endTime = Time.time + maxHoldBreathTime;
            Debug.Log("Holding breath");
        }

        if (Time.time > endTime || Input.GetKeyUp(KeyCode.F))
        {
            holdingBreath = false;
            Debug.Log("Stopped holding breath");
        }
    }
}
