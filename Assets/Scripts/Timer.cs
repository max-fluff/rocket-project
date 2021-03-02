using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public PlayerState player;
    void Update()
    {
        if (player.IsGrounded && player.IsLanded)
        {
            GetComponent<Text>().enabled = true;
            GetComponent<Text>().text = player.LandedPosTimer.ToString("F1");
        }
        else
        {
            GetComponent<Text>().enabled = false;
        }
    }
}
