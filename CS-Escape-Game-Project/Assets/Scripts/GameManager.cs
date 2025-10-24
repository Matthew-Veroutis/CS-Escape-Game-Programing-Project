using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float startTime = 60f; 
    private bool IsTimeUp = false;
    private string[] inventory = new string[10]; ///Only 10 item inventory
    private int itemCount = 0; 


    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (IsTimeUp) 
            return;

        if (startTime > 0)
        {
            startTime -= Time.deltaTime;
        }
        else
        {
            IsTimeUp = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckIsTimeUp() {
        return IsTimeUp;
    }

    public void SetTime(float Time) {
        this.startTime = Time;
    }

    public void AddTime(float Time) {
        this.startTime += Time;
    }

    public float GetTime() {
        return this.startTime;
    }

    public bool AddItem(string item)
    {
        if (itemCount < inventory.Length)
        {
            inventory[itemCount] = item;
            itemCount++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public string[] GetItems()
    {
        return inventory; 
    }

    public void ResetInventory() {
        inventory = new string[10];
    }
}
