using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //Jesper Andersson
    //tutorial i used: https://www.youtube.com/watch?v=9A9yj8KnM8c
   public IEnumerator Shake (float duration, float magnitude)  //duration is time spent shaking, magnitude is strength of shake.
   {
        Vector3 originalPos = transform.localPosition; // create a temporary holder for the cameras original pos.
        float elapsed = 0.0f; 

        while (elapsed < duration) // as long as time elapsed is less than duration of shake
        {
            float x = Random.Range(-1f, 1f) * magnitude; //take a random x and y value and apply it to camera position.
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime; // add on time spent shaking to elapsed.
            yield return null; // necessary, check timestamp 3:47 in video tutorial https://www.youtube.com/watch?v=9A9yj8KnM8c.
                               // basically syncs up couroutine with frames, if we dont have this we wont see any camera shake.
        }

        transform.localPosition = originalPos; // reset camera pos to original pos once shaking is over
   }
}
