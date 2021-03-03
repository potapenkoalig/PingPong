using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaCtrl : MonoBehaviour
{
    [SerializeField] float width;
    [SerializeField] float height;

    [SerializeField] BallCtrl ball;
    [SerializeField] PlayerCtrl top_player, down_player;

    // Start is called before the first frame update
    void Start()
    {
        ball.SetLimits(transform.position.x - width * 0.5f,
            transform.position.x + width * 0.5f,
            transform.position.y + height * 0.5f,
            transform.position.y - height * 0.5f);

        top_player.SetLimits(transform.position.x - width * 0.5f,
            transform.position.x + width * 0.5f);

        down_player.SetLimits(transform.position.x - width * 0.5f,
            transform.position.x + width * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
