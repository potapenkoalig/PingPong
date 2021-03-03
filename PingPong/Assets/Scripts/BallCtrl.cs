using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCtrl : MonoBehaviour
{
    [SerializeField] float min_velocity = 1.5f;
    [SerializeField] float max_velocity = 5.0f;

    [SerializeField] float min_scale = 0.2f;
    [SerializeField] float max_scale = 0.5f;

    [SerializeField] PlayerCtrl top_player, down_player;

    [SerializeField] Image image_in_settings;

    Vector2 init_pos;
    Vector2 velocity;
    float half_scale;

    float limit_left, limit_right, limit_top, limit_down;

    Color color = Color.white;

    public Color Color
    {
        get
        {
            return color;
        }
        set
        {
            color = value;
            SpriteRenderer rend = GetComponent<SpriteRenderer>();
            rend.color = color;
            image_in_settings.color = color;
        }
    }

    public void SetRedColor(float value)
    {
        Color = new Color(value, color.g, color.b);
    }
    public void SetGreenColor(float value)
    {
        Color = new Color(color.r, value, color.b);
    }
    public void SetBlueColor(float value)
    {
        Color = new Color(color.r, color.g, value);
    }

    public void SaveColor()
    {
        FileSaveLoad.ballColor = Color;
        FileSaveLoad.SaveFile();
    }

    public void SetLimits(float left, float right, float top, float down)
    {
        limit_left  = left;
        limit_right = right;
        limit_top   = top;
        limit_down  = down;
    }

    float GetRandomSign()
    {
        return ((Random.value > 0.5f) ? -1.0f : 1.0f);
    }

    public void Restart()
    {
        velocity = new Vector2(Random.Range(min_velocity, max_velocity) * GetRandomSign(), 
            Random.Range(min_velocity, max_velocity) * GetRandomSign());

        transform.position = init_pos;

        float scale = Random.Range(min_scale, max_scale);
        transform.localScale = new Vector3(scale, scale, 1.0f);
        half_scale = scale * 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        init_pos = transform.position;
        Restart();
    }

    bool CheckArenaLeftWall()
    {
        return transform.position.x - half_scale < limit_left;
    }

    bool CheckArenaRightWall()
    {
        return transform.position.x + half_scale > limit_right;
    }

    bool CheckGoalTop()
    {
        return transform.position.y + half_scale > limit_top;
    }

    bool CheckGoalDown()
    {
        return transform.position.y - half_scale < limit_down;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)velocity * Time.deltaTime;

        if (CheckArenaLeftWall())
        {
            transform.position = new Vector2(limit_left + half_scale, transform.position.y);
            velocity = new Vector2(-velocity.x, velocity.y);
        }

        else if (CheckArenaRightWall())
        {
            transform.position = new Vector2(limit_right - half_scale, transform.position.y);
            velocity = new Vector2(-velocity.x, velocity.y);
        }

        if (CheckGoalTop())
        {
            if (top_player.CheckBlock(transform.position.x, half_scale))
            {
                velocity = new Vector2(velocity.x, -velocity.y);
            }
            else
            {
                down_player.Score();
                Restart();
            }
        }
        else if (CheckGoalDown())
        {
            if (down_player.CheckBlock(transform.position.x, half_scale))
            {
                velocity = new Vector2(velocity.x, -velocity.y);
            }
            else
            {
                top_player.Score();
                Restart();
            }
        }
    }
}
