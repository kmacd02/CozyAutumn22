using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] musics;
    private AudioSource audio;
    
    [SerializeField] private PlayerController _playerController;
    public static PlayerController player;
    
    [SerializeField] private FuelUI _fuelUI;
    public static FuelUI fuelUI;
    
    private List<Lamp> lamps;
    private List<Lamp> counterLamps;

    private int musicType = 0;

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
        counterLamps = FindObjectsOfType<Lamp>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        clock.UpdateSprite((int) Mathf.Floor(time/240));

        if (player.health > 0)
        {
            bool inner = false;
            bool outer = false;
            
            foreach (Lamp l in lamps)
            {
                if (l.inOuterRadius) outer = true;
                if (l.inInnerRadius) inner = true;
            }

            if (inner)
            {
                musicType = 1;
            }else if (outer)
            {
                musicType = 0;
            }else
            {
                musicType = 2;
            }
        }
        else
        {
            musicType = 4;
        }

        for (int i = 1; i < musics.Length; i++)
        {
            if (i == musicType)
            {
                musics[i].volume = Mathf.Lerp(musics[i].volume, 1, Time.deltaTime * 0.1f);
            }
            else
            {
                musics[i].volume = Mathf.Lerp(musics[i].volume, 0, Time.deltaTime * 2f);
            }
        }

        if (time < 0)
        {
            SceneManager.LoadScene("TimeUp");
        }

        if (counterLamps.Count <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void updateLamps(Lamp l)
    {
        if (counterLamps.Contains(l))
        {
            counterLamps.Remove(l);
        }
    }
}
