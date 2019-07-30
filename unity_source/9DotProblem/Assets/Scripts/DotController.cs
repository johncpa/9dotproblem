using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour {

    public Color normalColor;
    public Color acceptColor;

    public bool accepted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //this.GetComponent<SpriteRenderer>().color = normalColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this.GetComponent<SpriteRenderer>().color = acceptColor;
        //accepted = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.GetComponent<SpriteRenderer>().color = normalColor;
        accepted = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        this.GetComponent<SpriteRenderer>().color = acceptColor;
        accepted = true;
    }
}
