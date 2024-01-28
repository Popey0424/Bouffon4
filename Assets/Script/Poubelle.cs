using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Poubelle : MonoBehaviour
{
    public GameObject Garbage;
    bool active = false;
    GameObject note;

    void Update()
    {
        if (active)
        {
            Destroy(note);
          
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.gameObject.tag == "Note")
        {
            note = collision.gameObject;
           
        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }
}
