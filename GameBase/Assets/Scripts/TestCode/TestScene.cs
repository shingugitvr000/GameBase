using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{
    // Start is called before the first frame update

    public int Count = 0;
    void Start()
    {
       Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
       {
           Debug.Log("key : " + key + " Count : " + count + " totalCount : " + totalCount);
           if(count == totalCount)
           {
               Managers.Game.Init();
           }
          
       });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            Count++;
            Managers.UI.ShowToast(Count.ToString());
        }
        if (Input.GetKeyUp(KeyCode.F3))
        {
            Managers.Object.Spawn<MonsterController>(new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)));
        }

        if (Input.GetKeyUp(KeyCode.F5))
        {
            Managers.Game.Gold += 1;
        }
    }
}
