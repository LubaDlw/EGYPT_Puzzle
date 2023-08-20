using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    public GameObject levelComplete;
    public GameObject riddleCanvas;
    public GameObject losePanel;
    public TextMeshProUGUI levelDone;
    [SerializeField]
    public  float speed;
    private bool riddleTriggered = false; //This helps make the collider only trigger once and no more
   

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        Debug.Log(myRB.velocity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FinishLine"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            levelDone.text = "Level " + (currentSceneIndex + 1) + "Complete";
            levelComplete.SetActive(true);
            Debug.Log("is colliding");
            
        }
        else if (other.CompareTag("Riddle") && !riddleTriggered)
        {
            riddleTriggered = true;
            riddleCanvas.SetActive(true);
            speed = 0; // to fix bug of player moving during riddle.
            Debug.Log("Player collided with Riddle object");
           

        }

    }
}
