using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : BaseController
{
    public override bool Init()
    {
       base.Init();

        //

        return true;

    }

    public float Timer = 2.0f;

    public void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Timer = 2.0f;
            this.gameObject.SetActive(false);
        }
    }
}
