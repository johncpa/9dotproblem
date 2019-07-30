using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public UIController ui;
    public LineMakerScript lineMaker;
    public DotController[] dots;

    public GameObject winText;

    public HTTPController http;
    public DataCollector data;
    public TimerScript timer;

    private void Awake()
    {
        data = GameObject.Find("DataCollector").GetComponent<DataCollector>();
        http = GameObject.Find("Http").GetComponent<HTTPController>();
        timer = GameObject.Find("Timer").GetComponent<TimerScript>();
    }

    private void Start()
    {
        winText.SetActive(false);
        data.trySent = false;
    }

    public void checkDone()
    {
        int accepted = 0;
        foreach (DotController dot in dots)
        {
            if (dot.accepted)
            {
                accepted++;
            }
        }
        if (accepted == dots.Length)
        {
            //u win bro
            Debug.Log("u win!");
            winText.SetActive(true);
            ui.setNonInteractableButtons();
            timer.takeTime = false;
        }
        else
        {
            Debug.Log("no win :c");
            //4 lines but no win
        }
        data.add(lineMaker.myLines, http);
        data.trySent = true;
    }

}
