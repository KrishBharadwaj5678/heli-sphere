using UnityEngine;

public class HeliSwitcher : MonoBehaviour
{
    public GameObject[] dragonModels; // Array to hold references to your dragon models
    private int currentIndex = 0;

    void Start()
    {
        // Initialize by showing the first dragon model and hiding others
        UpdateDragonModels();
    }

    public void ShowNextModel()
    {
        currentIndex = (currentIndex + 1) % dragonModels.Length;
        UpdateDragonModels();
    }

    public void ShowPreviousModel()
    {
        currentIndex = (currentIndex - 1 + dragonModels.Length) % dragonModels.Length;
        UpdateDragonModels();
    }

    private void UpdateDragonModels()
    {
        for (int i = 0; i < dragonModels.Length; i++)
        {
            dragonModels[i].SetActive(i == currentIndex);
        }
    }
}
