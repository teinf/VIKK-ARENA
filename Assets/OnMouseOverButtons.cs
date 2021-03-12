using UnityEngine;

public class OnMouseOverButtons : MonoBehaviour
{
    public AudioSource ButtonHover;

    private void Awake()
    {
        ButtonHover.priority = 0;
    }

    private void OnMouseEnter()
    {
        ButtonHover.Play(0);
    }
}
