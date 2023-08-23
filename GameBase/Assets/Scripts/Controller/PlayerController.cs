using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class PlayerController : BaseController
{
    float EnvCollectDist { get; set; } = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindBox();
    }

    void FindBox()
    {
        float sqrCollectDist = EnvCollectDist * EnvCollectDist;

        List<BoxController> boxs = Managers.Object.Boxs.ToList();

        //foreach (var go in boxs) 
        //{ 
        //    BoxController box = go.GetComponent<BoxController>();

        //    Vector3 dir = box.transform.position - transform.position;
        //    if(dir.sqrMagnitude <= sqrCollectDist )
        //    {
        //        Managers.Object.Despawn(box);
        //    }        
        //}

        //Debug.Log($"Total Box ({boxs.Count})");

        var findBoxs = GameObject.Find("@Grid").GetComponent<GridController>().GatherObjects(transform.position, EnvCollectDist + 10.0f);

        foreach (var go in findBoxs)
        {            
            BoxController box = go.GetComponent<BoxController>();

            go.SetActive(true);

            Vector3 dir = box.transform.position - transform.position;
            if (dir.sqrMagnitude <= sqrCollectDist)
            {
                Managers.Object.Despawn(box);
            }
        }

        Debug.Log($"SearchBox {findBoxs.Count} : Total Box ({boxs.Count})");

    }
}
