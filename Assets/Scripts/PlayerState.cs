using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    private static float _landedPosTimer;
    private static float _delay;
    private static float _fuel;
    private static bool _isGrounded;
    private static bool _isLanded;
    private static bool _isUndocked;
    private static bool _isDoubleDocked;
    private static Rigidbody _rb;
    private static BoxCollider _coll;

    private void Start()
    {
        _landedPosTimer = 3f;
        _isUndocked = true;
        _isDoubleDocked = gameObject.name == "PlayerDouble";
        _rb = GetComponent<Rigidbody>();
        _coll = GetComponent<BoxCollider>();
        if(_isDoubleDocked)
        {
            _rb.mass = 2;
            _fuel = 20;
            _isUndocked = false;
        }
        else
        {
            Undock();
            _fuel = 10;
            GameObject.Find("Part").SetActive(false);
        }
        
    }
    private void  Update()
    {
        _isGrounded = Physics.Raycast(transform.position-(_isUndocked ? 0 : -2) * -transform.up, -transform.up,  1.1f);
        if (_isLanded && _isGrounded)
            _landedPosTimer -= Time.deltaTime;
        else
            _landedPosTimer = 3f;
        if (_landedPosTimer <= 0)
        {
            Debug.Log("YouWin");
            _landedPosTimer = 0;
        }
        //Сделать обработчик сцен и отправить туда vvv
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public static void Undock()
    {
        _coll.size = PlayerCollision.GetUndockedSize();
        _coll.center = PlayerCollision.GetUndockedCenter();
        _rb.mass = 1;
        _isUndocked = true;
        PlayerMovement.SetTurn(90);
        _delay = 0.8f;
    }

    public static bool IsUndocked()
    {
        return _isUndocked;
    }
    public static bool IsDoubleDocked()
    {
        return _isDoubleDocked;
    }
    public static void SetLanded(bool isLanded)
    {
        _isLanded=isLanded;
    }
    public static bool IsGrounded()
    {
        return _isGrounded;
    }
    public static bool IsLanded()
    {
        return _isLanded;
    }
    public static float GetFuel()
    {
        return _fuel;
    }
    public static float GetDelay()
    {
        return _delay;
    }
    public static float GetTimer()
    {
        return _landedPosTimer;
    }
    public static void CountDelay(float time)
    {
        _delay -= time;
    }
    public static void DrainFuel(float amount)
    {
        _fuel -= amount;
        Fuel.SetFuel(_fuel);
    }
    
}
