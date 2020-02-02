using UnityEngine;

public class SurfControl : MonoBehaviour
{
    [SerializeField] private float thrust = 10.0f;
    [SerializeField] private ForceMode forwardForceMode = ForceMode.Impulse;
    [SerializeField] private float rotationForce = 25.0f;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private bool showDebug = false;
    [SerializeField] BoolValue isBoosted=null;
    [SerializeField] float forceBonusValue = 10;
    private InputManager inputManager;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float volumeModifier;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
    }

    void FixedUpdate()
    {
        Vector2 directions = inputManager.getAxesValues();
        this.MoveForward(directions.y);
        this.RotateSurf(directions);
    }

    private void MoveForward(float yAxisValue)
    {

        float forwardForce = isBoosted.value
            ? thrust * yAxisValue + forceBonusValue
            : thrust * yAxisValue;
        rigidBody.AddForce(transform.forward * forwardForce, forwardForceMode);
        if (showDebug)
        {
            Debug.Log("forwardForce: " + forwardForce + "forward: " + transform.forward);
        }
        audioSource.volume = rigidBody.velocity.magnitude / 30 * volumeModifier;
    }

    private void RotateSurf(Vector2 directions)
    {
        Vector3 localEulerAngles = transform.localEulerAngles;
        localEulerAngles.y += directions.x * rotationForce;
        Quaternion eulerRot = Quaternion.Euler(localEulerAngles);
        transform.rotation = Quaternion.Slerp(transform.rotation, eulerRot, Time.deltaTime * 10);
        if (showDebug)
        {
            Debug.Log("eulerRot: " + eulerRot + ", directions.x: " + directions.x);
        }
    }
}
