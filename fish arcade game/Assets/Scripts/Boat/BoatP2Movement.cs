using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BoatP2Movement : MonoBehaviour
{
    private bool canMove = false;
    public static UnityAction<bool> toggleMovementP2;
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotAmount;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float boatTiltXAmount;
    [SerializeField] private float boatTiltXSpeed;
    private float boatAngleTarg;
    private float boatTiltXTarg;
    private float boatTiltX;
    private float boatAngle;
    [SerializeField] private ParticleSystem engineParticles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggleMovementP2 += ToggleMv;
        toggleMovementP2.Invoke(true);
        rb = GetComponent<Rigidbody>();
    }

    private void ToggleMv(bool val)
    {
        canMove = val;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 mv = new Vector3(InputSystem.actions["MoveP2"].ReadValue<Vector2>().x, 0, InputSystem.actions["MoveP2"].ReadValue<Vector2>().y);
            boatAngleTarg = mv.x * rotAmount;
            boatTiltXTarg = mv.z * boatTiltXAmount;
            boatAngle = Mathf.LerpAngle(boatAngle, boatAngleTarg, rotSpeed);
            boatTiltX = Mathf.LerpAngle(boatTiltX, boatTiltXTarg, boatTiltXSpeed);
            float boatAngleFinal = boatAngle + transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, boatAngleFinal, transform.eulerAngles.z);
            rb.AddForce(transform.forward * -mv.z * speed, ForceMode.Force);
            transform.rotation = Quaternion.Euler(new Vector3(boatTiltX, boatAngleFinal, boatAngle * 10));
            if (mv.z > 0)
            {
                engineParticles.Play();
            }
            else
            {
                engineParticles.Stop();
            }
        }
        else
        {
            engineParticles.Stop();
        }

    }
}
