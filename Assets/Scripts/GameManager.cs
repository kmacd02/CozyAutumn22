using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Lamp> lamps;

    public static float time = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        lamps = FindObjectsOfType<Lamp>().ToList();
        Debug.Log(lamps.Count);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
