using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResource : MonoBehaviour
{
    private float mana;
    // Start is called before the first frame update
    void Start()
    {
        mana = 100;
    }

    public bool DrainMana(float amount)
    {
        if (amount <= mana)
        {
            mana -= amount;
            return true;
        }
        else if (amount > mana)
        {
            return false;
        }

        return false;
    }

    void FixedUpdate()
    {
        mana += 1 * Time.deltaTime;
    }
}
