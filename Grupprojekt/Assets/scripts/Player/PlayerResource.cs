using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerResource : MonoBehaviour
{
    private float cooldownHook;
    private bool hookOnCd = false;

    public Text textHook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool UseHook(float amount)
    {
        if (hookOnCd)
        {
            return false;
        }
        else
        {
            hookOnCd = true;
            cooldownHook = amount;
            return true;
        }
        
       
    }

    void Update()
    {
        if (hookOnCd)
        {
            if (cooldownHook > 0)
            {
                cooldownHook -= 1 * Time.deltaTime;
            }
            else
            {
                hookOnCd = false;
            }

            if (cooldownHook < 0)
            {
                cooldownHook = 0;
            }

            textHook.text = "Hook: " + cooldownHook.ToString("0.00");
        }
    }

   
}
