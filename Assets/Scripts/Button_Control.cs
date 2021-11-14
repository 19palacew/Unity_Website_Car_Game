using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Control : MonoBehaviour
{
    public GameObject menu;
    public float coolDown;
    public bool spawnObject;
    private bool active;
    private Animator aniController;
    private AnimatorClipInfo[] currentClipInfo;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
        active = true;
        aniController = transform.parent.GetComponent<Animator>();
        aniController.SetBool("Hit", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentClipInfo = aniController.GetCurrentAnimatorClipInfo(0);
        if (currentClipInfo[0].clip.name.Equals("ButtonDownIdle") && active)
        {
            if (spawnObject)
            {
                Instantiate(menu);
            }
            else
            {
                Instantiate(menu, GameObject.FindGameObjectWithTag("UI").transform);
            }
            active = false;
            Invoke("ResetButton", coolDown);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && active)
        {
            aniController.SetBool("Hit", true);
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void ResetButton()
    {
        aniController.SetBool("Hit", false);
        aniController.Play("ButtonUp");
        active = true;
        GetComponent<Renderer>().material.color = Color.red;
    }
}
