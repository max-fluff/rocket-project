using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private PlayerState player;

    private void FixedUpdate()
    {
        if (player.IsGrounded && player.IsLanded)
        {
            GetComponent<TextMeshProUGUI>().enabled = true;
            GetComponent<TextMeshProUGUI>().text = player.LandedPosTimer.ToString("F1");
        }
        else
        {
            GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }
}
