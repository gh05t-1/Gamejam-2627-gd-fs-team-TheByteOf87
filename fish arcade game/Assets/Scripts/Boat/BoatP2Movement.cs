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
    [SerializeField] private AudioSource motorSound;
    private bool hasPlayedSound = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggleMovementP2 += ToggleMv;
        toggleMovementP2.Invoke(false);
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
            float hor;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                hor = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                hor = 1;
            }
            else
            {
                hor = 0;
            }
            float vert;
            if (Input.GetKey(KeyCode.DownArrow))
            {
                vert = -1;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                vert = 1;
            }
            else
            {
                vert = 0;
            }
            Vector3 mv = new Vector3(hor, 0, vert);
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
                if (hasPlayedSound == false)
                {
                    motorSound.Play();
                    hasPlayedSound = true;
                }
            }
            else
            {
                engineParticles.Stop();
                if (hasPlayedSound == true)
                {
                    motorSound.Stop();
                    hasPlayedSound = false;
                }
            }
        }
        else
        {
            engineParticles.Stop();
            if (hasPlayedSound == true)
            {
                motorSound.Stop();
                hasPlayedSound = false;
            }
        }

    }
}
