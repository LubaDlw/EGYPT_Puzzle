using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    public GameObject levelDisplayPanel;
    public TextMeshProUGUI levelText;
    public float displayDuration = 3f;

    private void Start()
    {
        levelDisplayPanel.SetActive(true);
        // Get the current scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Display the level number
        levelText.text = "Level " + (currentSceneIndex + 1);

        // Show the panel for a few seconds
        StartCoroutine(HideLevelDisplay());
    }

    private IEnumerator HideLevelDisplay()
    {
        yield return new WaitForSeconds(displayDuration);
        levelDisplayPanel.SetActive(false);
    }
}
