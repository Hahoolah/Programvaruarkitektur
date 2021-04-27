using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckRemoval : MonoBehaviour
{
    private bool destroyTruck = false;
    float countMax = 3;
    float count = 0;
    MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (destroyTruck)
        {
            if (count < countMax)
            {
                count = count + Time.deltaTime;
            }
            else
            {
                Debug.Log("Destroy");
                Destroy(this.gameObject);
            }

        }
    }

    public void SetDestroyTruck(bool destroyTruckFlag)
    {
        Debug.Log("Removing truck");
        destroyTruck = destroyTruckFlag;
        StartCoroutine(DoAThingOverTime(countMax));
    }


    IEnumerator DoAThingOverTime(float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            Color c = renderer.material.color;
            c.a = c.a - 0.0001f;
            renderer.material.color = c;
            yield return null;

        }

    }
}


