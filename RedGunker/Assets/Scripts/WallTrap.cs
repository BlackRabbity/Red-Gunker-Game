using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrap : MonoBehaviour
{
    public GameObject wallTrap;
    private Animator wallTrapAnimator;
    private float timer = 0.0f;
    bool onTrap = false;

    private void Awake()
    {
        wallTrapAnimator = wallTrap.GetComponent<Animator>();
    }
    private void Update()
    {
        if(onTrap)
        {
            timer += Time.deltaTime;
            if (timer > 0.2)
            {
                wallTrapAnimator.Play("WallTrapAnimation");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onTrap = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        onTrap = false;
        timer = 0;
    }
}
