using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputCtrl : MonoBehaviour
{
    [SerializeField] PlayerCtrl[] players;
    [SerializeField] float velocity;

    bool move_right, move_left;

    public bool MoveRight
    {
        get
        {
            return move_right;
        }
        set
        {
            move_right = value;
        }
    }

    public bool MoveLeft
    {
        get
        {
            return move_left;
        }
        set
        {
            move_left = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move_right &&
            move_left)
        {
            return;
        }

        if (move_right)
        {
            foreach(PlayerCtrl player in players)
            {
                player.velocity = velocity;
            }
        }
        else if (move_left)
        {
            foreach (PlayerCtrl player in players)
            {
                player.velocity = -velocity;
            }
        }
        else
        {
            foreach (PlayerCtrl player in players)
            {
                player.velocity = 0;
            }
        }
    }
}
