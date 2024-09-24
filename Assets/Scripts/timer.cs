using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public float countdown = 15f;

    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0)
        {
            TimesUp();
        }
    }

    void TimesUp()
    {
        Destroy(gameObject);
    }
}
