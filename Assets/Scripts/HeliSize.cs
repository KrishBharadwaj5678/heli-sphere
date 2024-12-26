using UnityEngine;
using UnityEngine.UI;

public class HeliSize : MonoBehaviour
{
    public Slider sizeSlider; // Reference to the UI Slider
    private Vector3 initialScale; // Initial scale of the dragon
    private bool isModelActive = false; // Flag to track if the model is active

    void Start()
    {
        // Store the initial scale
        initialScale = transform.localScale;

        // Ensure the slider is set up
        if (sizeSlider != null)
        {
            // Set the slider's min and max values
            sizeSlider.minValue = 0.5f; // Minimum scale factor
            sizeSlider.maxValue = 15f;   // Maximum scale factor

            // Initialize the slider's value to 1 (original size)
            sizeSlider.value = 1f;

            // Add a listener to the slider to call the UpdateSize method when the value changes
            sizeSlider.onValueChanged.AddListener(UpdateSize);
        }
        else
        {
            Debug.LogWarning("Size Slider is not assigned.");
        }
    }

    void OnEnable()
    {
        // Check if the model is active when switching back
        if (isModelActive)
        {
            transform.localScale = initialScale; // Reset the scale when reactivated
            sizeSlider.value = 1f; // Reset the slider value
        }
        isModelActive = true;
    }

    // Method to update the model's scale
    public void UpdateSize(float value)
    {
        // Scale the model uniformly based on the slider's value
        transform.localScale = initialScale * value;
    }

    // Optional: Method to handle when the model is deactivated
    void OnDisable()
    {
        isModelActive = false;
    }
}
