using UnityEngine;
using UnityEngine.UI;

public class HeliPosition : MonoBehaviour
{
    public Slider yPositionSlider; // Reference to the UI Slider
    private float initialYPosition; // Initial Y position of the dragon

    void Start()
    {
        // Store the initial Y position
        initialYPosition = transform.position.y;

        // Set the slider's min and max values
        yPositionSlider.minValue = -5f; // Set your desired minimum value
        yPositionSlider.maxValue = 40f;  // Set your desired maximum value

        // Initialize the slider's value to zero
        yPositionSlider.value = 0f;

        // Add a listener to the slider to call the UpdateYPosition method when the value changes
        yPositionSlider.onValueChanged.AddListener(UpdateYPosition);
    }

    // Method to update the dragon's Y position
    public void UpdateYPosition(float value)
    {
        // Update the Y position while keeping X and Z positions unchanged
        transform.position = new Vector3(transform.position.x, initialYPosition + value, transform.position.z);
    }
}
