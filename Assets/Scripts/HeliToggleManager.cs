using UnityEngine;

public class HeliToggleManager : MonoBehaviour
{
    public GameObject scaleSlider;       // Reference to the scale slider GameObject
    public GameObject verticalSlider;    // Reference to the vertical adjustment slider GameObject
    public GameObject speedSlider;       // Reference to the speed slider GameObject
    public GameObject scalePanel;        // Reference to the scale panel (with sliders and image)
    public GameObject positionPanel;     // Reference to the position panel (with sliders and image)
    public GameObject speedPanel;        // Reference to the speed panel (with sliders and image)
    public GameObject targetPanel;       // Reference to the target panel

    private GameObject currentlyActivePanel; // Keeps track of the currently active panel

    void Start()
    {
        // Ensure all sliders and panels are inactive at the start
        SetAllInactive();
    }

    // Hide all sliders and panels
    private void SetAllInactive()
    {
        if (scaleSlider != null) scaleSlider.SetActive(false);
        if (verticalSlider != null) verticalSlider.SetActive(false);
        if (speedSlider != null) speedSlider.SetActive(false);
        if (scalePanel != null) scalePanel.SetActive(false);
        if (positionPanel != null) positionPanel.SetActive(false);
        if (speedPanel != null) speedPanel.SetActive(false);
        if (targetPanel != null) targetPanel.SetActive(false);

        currentlyActivePanel = null; // Reset the active panel tracker
    }

    // Toggle a specific panel
    private void TogglePanel(GameObject panel, GameObject slider = null)
    {
        if (panel == currentlyActivePanel)
        {
            // If the same panel is clicked again, hide it
            panel.SetActive(false);
            if (slider != null) slider.SetActive(false);
            currentlyActivePanel = null;
        }
        else
        {
            // Hide all other panels first
            SetAllInactive();

            // Show the selected panel
            panel.SetActive(true);
            if (slider != null) slider.SetActive(true);

            // Update the active panel tracker
            currentlyActivePanel = panel;
        }
    }

    // Method to toggle the scale slider and panel visibility
    public void ToggleScaleSlider()
    {
        TogglePanel(scalePanel, scaleSlider);
    }

    // Method to toggle the vertical adjustment slider and panel visibility
    public void TogglePositionSlider()
    {
        TogglePanel(positionPanel, verticalSlider);
    }

    // Method to toggle the speed slider and panel visibility
    public void ToggleSpeedSlider()
    {
        TogglePanel(speedPanel, speedSlider);
    }

    // Method to toggle and untoggle the target panel
    public void ToggleTargetPanel()
    {
        TogglePanel(targetPanel);
    }
}
