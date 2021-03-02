using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _lastPos;
    private static float _force;
    [SerializeField] public PlayerState Player;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _force = 1000;
        Physics.gravity = new Vector3(0, -2F, 0); 
        _lastPos = _rb.position;
    }
    
    void FixedUpdate()
    {

        if(Player.Fuel > 0&&Player.Delay<=0)
        {
            if (Input.GetKey("space"))
            {
                _rb.AddRelativeForce(0, _force * Time.fixedDeltaTime, 0);
                Player.DrainFuel(4 * Time.deltaTime);
                if (Player.Fuel <= 10f && Player.IsUndocked == false)
                    Player.Undock();
            }

            if (Player.IsGrounded == false)
                _rb.AddTorque(-transform.forward * (Player.Turn * Input.GetAxis("Horizontal")));
        }
        else
            Player.CountDelay(Time.fixedDeltaTime);
        Player.Speed = (_rb.position - _lastPos).magnitude/Time.fixedDeltaTime;
        _lastPos = _rb.position;
    }
    
}
