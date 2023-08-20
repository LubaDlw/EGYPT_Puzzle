using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintManager : MonoBehaviour
{
    public int stars;
    public TextMeshProUGUI starsCount;
    public float displayTime = 10f;

    public GameObject hint;
    public GameObject hintActual;

    public bool isDisplaying = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("called!");

        if (other.CompareTag("Star"))
        {
            Destroy(gameObject);
            stars++;
            starsCount.text = stars.ToString();

            if (stars > 5)
            {
                hint.SetActive(true);
            }

            else if (stars < 5)
            {
                hint.SetActive(false);
            }
        }
    }

    private IEnumerator ShowHint()
    {
        stars -= 5;

        isDisplaying = true;
        DisplayText();
        yield return new WaitForSeconds(displayTime);
        HideText();
        isDisplaying = false;
    }

    private void DisplayText()
    {
        hintActual.gameObject.SetActive(true);
    }

    private void HideText()
    {
        hintActual.gameObject.SetActive(false);
    }
}
