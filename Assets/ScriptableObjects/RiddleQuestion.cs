using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Riddle Question", menuName = "Riddle Question")]
public class RiddleQuestion : ScriptableObject
{

    public string question;
    public string[] answers = new string[4];
    public int correctAnswerIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
