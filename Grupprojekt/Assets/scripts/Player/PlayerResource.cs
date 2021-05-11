using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResource : MonoBehaviour
{
    private float mana;
    private float maxMana = 100;
    public Image manaBar;
    // Start is called before the first frame update
    void Start()
    {
        mana = 50;
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

    void Update()
    {
        mana += 1 * Time.deltaTime;
        manaBar.fillAmount = Mathf.Clamp(mana / maxMana, 0, 1f);
    }
}
