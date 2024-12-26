// using UnityEngine; // public class HelicopterController : MonoBehaviour // { // [SerializeField] private float speed; // private FixedJoystick fixedJoystick; // private Rigidbody rigidbody; // private void OnEnable() // { // fixedJoystick = FindObjectOfType<FixedJoystick>(); // rigidbody = gameObject.GetComponent<Rigidbody>(); // } // private void FixedUpdate() // { // float xVal = fixedJoystick.Horizontal; // float yVal = fixedJoystick.Vertical; // Vector3 movement = new Vector3(xVal, 0, yVal); // rigidbody.linearVelocity = movement * speed; // Corrected from linearVelocity to velocity // if (xVal != 0 || yVal != 0) // Corrected logical operator to handle movement correctly // { // transform.eulerAngles = new Vector3( // transform.eulerAngles.x, // Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, // transform.eulerAngles.z // ); // Corrected from eularAngles to eulerAngles // } // } // }

using UnityEngine;
using UnityEngine.UI;

public class HelicopterController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 20f; // Maximum speed
    [SerializeField] private Slider speedSlider; // Reference to the speed slider
    private FixedJoystick fixedJoystick;
    private Rigidbody rigidbody;
    private float currentSpeed = 1f; // Default speed set to 1

    private void OnEnable()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rigidbody = gameObject.GetComponent<Rigidbody>();

        // Ensure the slider is assigned and set its properties
        if (speedSlider != null)
        {
            speedSlider.minValue = 0f; // Minimum speed
            speedSlider.maxValue = maxSpeed; // Maximum speed
            speedSlider.value = currentSpeed; // Set initial value to 1

            // Add listener to update the speed when the slider value changes
            speedSlider.onValueChanged.AddListener(UpdateSpeed);
        }
        else
        {
            Debug.LogWarning("Speed Slider is not assigned in the inspector.");
        }
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;

        Vector3 movement = new Vector3(xVal, 0, yVal) * currentSpeed; // Use currentSpeed
        rigidbody.linearVelocity = movement; // Use velocity for movement (fixed update)

        if (xVal != 0 || yVal != 0)
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg,
                transform.eulerAngles.z
            );
        }
    }

    // Method to update the speed based on the slider value
    private void UpdateSpeed(float value)
    {
        currentSpeed = value; // Update the current speed
    }
}
