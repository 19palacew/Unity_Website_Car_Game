using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Move : MonoBehaviour
{
    public float offset;
    public float smoothing;
    public GameObject menu;
    private Vector3 firstpos;
    private Vector3 lastpos;
    private bool up;
    // Start is called before the first frame update
    void Start()
    {
        up = true;
        firstpos = transform.position;
        lastpos = transform.position - new Vector3(0,offset,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -.3f && up)
        {
            
            Instantiate(menu, GameObject.FindGameObjectWithTag("UI").transform);
            up = false;
            Time.timeScale = 0;
            Invoke("ResetButton", 5f);
        }
        if (up)
        {
            transform.position = Vector3.Lerp(firstpos, transform.position, smoothing * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(lastpos, transform.position, smoothing * Time.deltaTime);
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            up = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            up = true;
        }
    }

    private void ResetButton()
    {
        transform.position = firstpos;
        up = true;
    }
}
