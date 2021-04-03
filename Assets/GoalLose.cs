using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoalLose : MonoBehaviour
{
    public GameObject blink, ballPosition;
    public Text txt;
    public Image img,img2;
    List<Rigidbody> ballList;
    // Start is called before the first frame update
    void Start()
    {
        ballList = new List<Rigidbody>();
        if (ballList.Count > 0)
        {
            blink = GameObject.Find("ParticleGoalLose");
            Debug.Log(blink.name + "telah ketemu");
            blink.SetActive(false);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());       
            img = GameObject.Find("Canvas/Lives 2").GetComponent<Image>();
            img.enabled = !img.enabled;
            txt = GameObject.Find("Canvas/Level").GetComponent<Text>();
            var ball = GameObject.FindGameObjectWithTag("Ball");
            if (txt.text == "Level 2, and you have 2 lives")
            {
                txt.text = "Level 1, you only have 1 lives left";
                //ball.transform.position = new Vector3(3.054f, 0.192f, -5.68f);
            }
            if (txt.text != "Level 1, you only have 1 lives left")
            {
                txt.text = "Game Over!";               
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        var ball = GameObject.FindGameObjectWithTag("Ball");       
        txt = GameObject.Find("Canvas/Level").GetComponent<Text>();
        if (txt.text == "Game Over!")
        {
            img = GameObject.Find("Canvas/Lives 2").GetComponent<Image>();
            img2 = GameObject.Find("Canvas/Lives 1").GetComponent<Image>();
            img2.enabled = !img2.enabled;
            img.enabled = !img.enabled;
            Application.Quit();
        }
        if (txt.text == "Level 1, you only have 1 lives left")
        {
            ball.transform.position = new Vector3(3.054f, 0.192f, -5.68f);
            txt.text = "1 nyawa lagi";
        }
        
    }
}
