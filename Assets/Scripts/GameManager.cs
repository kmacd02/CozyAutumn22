using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    public static PlayerController player;
    
    [SerializeField] private FuelUI _fuelUI;
    public static FuelUI fuelUI;
    
    private List<Lamp> lamps;

    public static float time = 0f;
    [SerializeField] private ClockUI clock;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (_playerController != null) player = _playerController;
        else player = FindObjectOfType<PlayerController>();
        
        if (_fuelUI != null) fuelUI = _fuelUI;
        else fuelUI = FindObjectOfType<FuelUI>();

        lamps = FindObjectsOfType<Lamp>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
