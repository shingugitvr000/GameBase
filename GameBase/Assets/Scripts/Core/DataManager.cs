using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager
{
    Entity_ItemData entity_ItemData;

    public void Init()
    {
        //�Է��� �׻��� ScriptableObject�� ��ȯ�� �����͸� �ε��ϱ� ���ؼ� 
        entity_ItemData = (Entity_ItemData)Managers.Resource.Load<ScriptableObject>("ItemData");

        for (int i = 1; i < 5; i++)     //index�� 1�� ���� �ֱ� ����
        {
            Entity_ItemData.Param param = GetItemDataByIndex(i);           
            string jsonStr = JsonConvert.SerializeObject(param);
            Debug.Log(jsonStr);

        }
    }

    public Entity_ItemData.Param GetItemDataByIndex(int index)
    {
        Entity_ItemData.Param targetParam = entity_ItemData.sheets[0].list.Find(param => param.index == index);
        return targetParam;
    }
}
