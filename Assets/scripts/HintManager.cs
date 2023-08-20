using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintManager : MonoBehaviour
{
    public int stars = 0;
    public TextMeshProUGUI starsCount;
    public float displayTime = 5f;

    public GameObject hint;
    public GameObject hintActual;
    public GameObject hintButton;

    public bool isDisplaying = false;

    private void Start()
    {
        Button buttonComponent = hintButton.GetComponent<Button>();

        buttonComponent.onClick.AddListener(ShowHint);
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("It works!");

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            stars++;
            starsCount.text = stars.ToString();

            if (stars >= 1) // checks if the player has at least 1 star collected
            {
                hint.SetActive(true); // brings up the hint panel and not the hint itself, place this under the gameobject used for showing the riddle popup to make it so that it only shows up there
            }
            else
            {
                hint.SetActive(false);
            }
        }
    }

    public void ShowHint()
    {
        StartCoroutine(ShowHintCoroutine()); //This calls on the coroutine I set up below, allowing it to be accessed via buttopn press since IEnumerator's aren't visible on the inspector
    }

    public IEnumerator ShowHintCoroutine() //handles the logic for displaying the hint text
    {
        stars -= 1;

        isDisplaying = true;
        DisplayText();
        yield return new WaitForSeconds(displayTime);
        HideText();
        isDisplaying = false;
    }

    private void DisplayText()
    {
        hintActual.SetActive(true);
    }

    private void HideText()
    {
        hintActual.SetActive(false);
    }
}