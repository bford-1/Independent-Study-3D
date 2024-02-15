using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    public int x_cord;
    public int y_cord;
    public GameObject Indicator;
    public GameObject Cam;
    public GameObject player;
    public GameObject spawnPoint;

    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        Indicator.SetActive(false);
        InvokeRepeating("FlashIndicator", 0, 0.7f);
    }

    void FlashIndicator()
    {
        if (active)
        {
            if (Indicator.activeSelf)
            {
                Indicator.SetActive(false);
            }
            else
            {
                Indicator.SetActive(true);
            }
        } else
        {
            Indicator.SetActive(false);
        }
    }

    public void setIndicator(bool indicator)
    {
        active = indicator;
    }

    public void setCamera(bool cameraStatus)
    {
        Cam.SetActive(cameraStatus);
    }

    public void spawnPlayer()
    {
        Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
    }
}
