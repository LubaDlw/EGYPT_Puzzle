using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    public GameObject levelComplete;
    public GameObject riddleCanvas;
    [SerializeField]
    private float speed;
   

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
            levelComplete.SetActive(true);
            Debug.Log("is colliding");
            
        }
        else if (other.CompareTag("Riddle"))
        {
            riddleCanvas.SetActive(true);
            Debug.Log("Player collided with Riddle object");
        }

    }
}
