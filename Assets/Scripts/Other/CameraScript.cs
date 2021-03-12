using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    [HideInInspector]
    public Vector3 minScreenBounds, maxScreenBounds;

    public static CameraScript instance;

    private Vector3 shaker;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        minScreenBounds = -screenBounds;
        maxScreenBounds = screenBounds;
        //Musiałem tak zrobić, ponieważ ekran nie skalował się poprawnie

        //Debug.Log(minScreenBounds);
        //Debug.Log(maxScreenBounds);
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 startPos = transform.localPosition;

        float timePast = 0f;

        while (timePast < duration)
        {
            transform.localPosition = new Vector3(Random.Range(-1f, 1f) * magnitude, Random.Range(-1f, 1f) * magnitude, startPos.z);

            timePast += Time.deltaTime;

            yield return null; // Czeka na kolejną klatkę
        }

        transform.localPosition = startPos;

    }
}
