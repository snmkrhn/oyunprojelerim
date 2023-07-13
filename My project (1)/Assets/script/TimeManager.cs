using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Unity.VisualScripting;

public class TimeManager : MonoBehaviour
{
    public bool gameFinished = false;
    public bool gameOver = false;
    [SerializeField] private float levelFinishTime = 5f;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();
        
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(gameFinished==false && gameOver==false)
        {
            UpdateTheTimer();
        }

        print(Time.time);
        if (Time.timeSinceLevelLoad >= levelFinishTime && gameOver == false) 
        {
           
            gameFinished = true;
            winPanel.gameObject.SetActive(true);
            losePanel.gameObject.SetActive(false);
            UpdateObjectList("objects");
            UpdateObjectList("enemy");
            foreach (GameObject allObjects in destroyAfterGame)
                {
                Destroy(allObjects);
            }
        }
        if(gameOver==true)
        {
          
            winPanel.gameObject.SetActive(false);
            losePanel.gameObject.SetActive(true);
            UpdateObjectList("objects");
            UpdateObjectList("enemy");
            foreach ( GameObject allObjects in destroyAfterGame)
                {
                Destroy(allObjects);
            }


        }




    }
    private void UpdateObjectList(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
        

    }
    private void UpdateTheTimer()
    {
        timeText.text = "Time" +(int) Time.timeSinceLevelLoad;
    }

}
