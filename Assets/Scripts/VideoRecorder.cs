using UnityEngine;
using TMPro;
using System.IO;
using System.Collections;

public class VideoRecorder : MonoBehaviour
{
    public TMP_Text alertText; // Reference to TextMeshPro Text component
    public GameObject alertPanel; // Reference to a UI Panel for displaying alerts

    public void TakeScreenshot()
    {
        // Start the coroutine to handle the screenshot and delay for showing the alert box
        StartCoroutine(CaptureScreenshotWithDelay());
    }

    private IEnumerator CaptureScreenshotWithDelay()
    {
        // Disable the alert panel temporarily before capturing the screenshot
        if (alertPanel != null)
        {
            alertPanel.SetActive(false); // Hide the alert panel
        }

        // Determine the folder path based on the platform
        string folderPath;

        if (Application.isMobilePlatform)
        {
            // For Android and iOS, save to the Pictures folder
            folderPath = Path.Combine(Application.persistentDataPath, "Screenshots");
        }
        else
        {
            // For PC (Windows, macOS, Linux), save to a "Screenshots" folder in Documents
            folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "Screenshots");
        }

        // Ensure the folder exists
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Generate a file name for the screenshot
        string screenshotPath = Path.Combine(folderPath, $"screenshot_{System.DateTime.Now:yyyyMMdd_HHmmss}.png");

        // Capture the current frame as a screenshot
        ScreenCapture.CaptureScreenshot(screenshotPath);

        Debug.Log($"Screenshot saved: {screenshotPath}");

        // Wait for 1-2 seconds before showing the alert box
        yield return new WaitForSeconds(1f); // Adjust the time as needed (1-2 seconds)

        // Re-enable the alert panel and show the alert with the save path
        if (alertPanel != null)
        {
            alertPanel.SetActive(true); // Show the alert panel again
        }

        // Show the message indicating where the screenshot is saved
        ShowAlert($"Screenshot saved to:\n{screenshotPath}");

        // Wait for 3 seconds before hiding the alert panel again
        yield return new WaitForSeconds(3f);

        // Hide the alert panel automatically after the duration
        HideAlert();
    }

    public void ShowAlert(string message)
    {
        if (alertText != null && alertPanel != null)
        {
            alertText.text = message; // Set the alert message
            alertPanel.SetActive(true); // Show the alert panel
        }
    }

    public void HideAlert()
    {
        if (alertPanel != null)
        {
            alertPanel.SetActive(false); // Hide the alert panel after the duration
        }
    }
}
