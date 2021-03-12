using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public float stoppingDistance;
    public float runAwayDistance;

    public int speed = 1;

    public bool handleDistance = false;
    void Update()
    {
        if(handleDistance)
        {
            if (Vector2.Distance(Player.instance.GetPosition(), transform.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.instance.GetPosition(), speed * Time.deltaTime);
            }
            else if ((Vector2.Distance(Player.instance.GetPosition(), transform.position) < stoppingDistance) && (Vector2.Distance(Player.instance.GetPosition(), transform.position) > runAwayDistance))
            {
                transform.position = this.transform.position;
            }
            // UCIECZKA
            else if ((Vector2.Distance(Player.instance.GetPosition(), transform.position) < runAwayDistance))
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.instance.GetPosition(), 2 * -speed * Time.deltaTime);
            }
        } else if(!handleDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.instance.GetPosition(), speed * Time.deltaTime);
        }
    }
}
