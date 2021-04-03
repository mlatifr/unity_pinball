using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour
{
    public GameObject blinkBall;
    float power,minPower=0f;
    public float maxPower=100f;
    public Slider powerSlider;
    List<Rigidbody> ballList;
    // Start is called before the first frame update
    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        ballList  = new List<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        
        powerSlider.value = power;
        if (ballList.Count > 0)
        {
           // Debug.Log("number of ball List= "+ballList.Count.ToString());
            powerSlider.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= maxPower)
                {
                    power += 50 * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach(Rigidbody r in ballList)
                {
                    r.AddForce(power * Vector3.forward);
                }
            }
        }
       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            blinkBall = GameObject.Find("ParticleSistemBlink");
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
            blinkBall.SetActive(false);
            
        }
    }
}
