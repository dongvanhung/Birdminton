using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpful_hubert : MonoBehaviour
{
    GameObject shuttle;
    audio_manager audio_manager;

    bool hitting = false;


    void Start()
    {
        audio_manager = GameObject.Find("audio_manager").GetComponent<audio_manager>();
        shuttle = GameObject.Find("shuttle");
    }
    
    void Update()
    {
        
    }

    public void hit_shuttle(Vector3 where)
    {
        shuttle.transform.position = transform.position;
        shuttle.GetComponent<shuttle>().enabled = true;
        shuttle.GetComponent<shuttle>().set_towards_left(true);
        shuttle.GetComponent<shuttle>().set_trajectory(
            shuttle.transform.position,
            where,
            15);
        audio_manager.Play("hit soft", 1);
        shuttle.GetComponent<TrailRenderer>().enabled = true;
        shuttle.GetComponent<TrailRenderer>().Clear();
        shuttle.transform.Find("mishit_line").gameObject.SetActive(false);
        shuttle.transform.Find("mishit_line").GetChild(0).gameObject.GetComponent<TrailRenderer>().Clear();
        transform.Find("hubert").GetComponent<Animator>().SetTrigger("serve");
    }
}