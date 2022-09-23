using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    public static PlayerController player;
    
    [SerializeField] private FuelUI _fuelUI;
    public static FuelUI fuelUI;
    
    private List<Lamp> lamps;

    public static float time = 1920f;
    [SerializeField] private ClockUI clock;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (_playerController != null) player = _playerController;
        else player = FindObjectOfType<PlayerController>();
        
        if (_fuelUI != null) fuelUI = _fuelUI;
        else fuelUI = FindObjectOfType<FuelUI>();

        if(clock == null) clock = FindObjectOfType<ClockUI>();

        lamps = FindObjectsOfType<Lamp>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        clock.UpdateSprite((int) Mathf.Floor(time/240));

        if (time < 0)
        {
            SceneManager.LoadScene("TimeUp");
        }

        if (lamps.Count <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void updateLamps(Lamp l)
    {
        if (lamps.Contains(l))
        {
            Debug.Log("test");
            lamps.Remove(l);
        }
    }
}
