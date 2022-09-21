using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    public static PlayerController player;
    
    private List<Lamp> lamps;

    public static float time = 0f;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (_playerController != null)
        {
            player = _playerController;
        }
        else
        {
            player = FindObjectOfType<PlayerController>();
        }
        
        lamps = FindObjectsOfType<Lamp>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
