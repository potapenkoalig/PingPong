using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] float size;
    [SerializeField] ScoreCtrl score;
    [SerializeField] bool i_am_top;

    public float velocity;

    float half_size;

    float limit_left, limit_right;

    float temp_pos;

    public void SetLimits(float left, float right)
    {
        limit_left = left;
        limit_right = right;
    }

    public bool CheckBlock(float ball_pos_x, float half_scale)
    {
        return ball_pos_x - half_scale < transform.position.x + this.half_size &&
            ball_pos_x + half_scale > transform.position.x - this.half_size;
    }

    public void Score()
    {
        if (i_am_top)
            score.ScoreTopPlayer();
        else
            score.ScoreDownPlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        half_size = size * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        temp_pos = transform.position.x + velocity * Time.deltaTime;

        if (temp_pos + half_size > limit_right)
        {
            temp_pos = limit_right - half_size;
        }
        else if (temp_pos - half_size < limit_left)
        {
            temp_pos = limit_left + half_size;
        }

        transform.position = new Vector2(temp_pos, transform.position.y);
    }
}
