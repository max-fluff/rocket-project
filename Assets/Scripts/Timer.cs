using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    void Update()
    {
        if (PlayerState.IsGrounded() && PlayerState.IsLanded())
        {
            GetComponent<Text>().enabled = true;
            GetComponent<Text>().text = PlayerState.GetTimer().ToString("F1");
        }
        else
        {
            GetComponent<Text>().enabled = false;
        }
    }
}
