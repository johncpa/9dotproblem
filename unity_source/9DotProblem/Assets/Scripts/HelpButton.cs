using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour {

    public GameObject wrapper;

	// Use this for initialization
	void Start () {
        wrapper.SetActive(false);

    }

    private void OnMouseOver()
    {
        wrapper.SetActive(true);
    }

    private void OnMouseExit()
    {
        wrapper.SetActive(false);
    }
}
