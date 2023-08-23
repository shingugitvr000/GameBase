using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }
    public static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);  //Scene �� ����ǵ� �ı� ���� �ʰ� 
            s_instance = go.GetComponent<Managers>();
        }
    }

    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    ObjectManager _object = new ObjectManager();
    UIManager _ui = new UIManager();
    GameManager _game = new GameManager();
    DataManager _data = new DataManager();
    SoundManager _sound = new SoundManager();

    public static UIManager UI { get { return Instance?._ui; } }
    public static PoolManager Pool { get { return Instance?._pool; } }
    public static ResourceManager Resource { get { return Instance?._resource; } }
    public static ObjectManager Object { get { return Instance?._object; } }
    public static GameManager Game { get { return Instance?._game; } }
    public static DataManager Data { get { return Instance?._data; } }
    public static SoundManager Sound { get {  return Instance?._sound; } }

}
