using UnityEngine;
using UnityEngine.UI;

public class HeliSpeed : MonoBehaviour
{
    public Slider speedSlider; // Reference to the UI Slider
    public float maxSpeed = 55f; // Maximum speed of the helicopter
    private float currentSpeed = 0f; // Current speed of the helicopter

    void Start()
    {
        // Ensure the speed slider is assigned
        if (speedSlider == null)
        {
            Debug.LogWarning("Speed Slider reference is not set.");
            return;
        }

        // Set the slider's min and max values
        speedSlider.minValue = 0f; // Minimum speed
        speedSlider.maxValue = maxSpeed; // Maximum speed

        // Initialize the slider's value to 0 (stationary)
        speedSlider.value = 0f;

        // Add a listener to the slider to call the UpdateSpeed method when the value changes
        speedSlider.onValueChanged.AddListener(UpdateSpeed);
    }

    // Method to update the helicopter's speed
    public void UpdateSpeed(float value)
    {
        // Update the current speed based on the slider's value
        currentSpeed = value;
    }
}
