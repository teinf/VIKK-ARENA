using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickParticles : MonoBehaviour
{
    public GameObject ps;
    private Vector3 mousePosition;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0; // nie wiem czemu ustawia z na -20
            GameObject particle = Instantiate(ps, mousePosition, Quaternion.identity);
        }
    }
}
