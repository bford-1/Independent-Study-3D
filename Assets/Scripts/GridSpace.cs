using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    public int x_cord;
    public int y_cord;
    public GameObject indicator;

    // Make private eventually
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        indicator.SetActive(false);
        InvokeRepeating("FlashIndicator", 0, 0.7f);
    }

    void FlashIndicator()
    {
        if (active)
        {
            if (indicator.activeSelf)
            {
                indicator.SetActive(false);
            }
            else
            {
                indicator.SetActive(true);
            }
        } else
        {
            indicator.SetActive(false);
        }
    }

    public void setIndicator(bool indicator)
    {
        active = indicator;
    }
}
