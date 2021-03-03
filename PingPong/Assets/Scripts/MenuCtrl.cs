using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCtrl : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    public void ActivateByIndex(int index)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        objects[index].SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
