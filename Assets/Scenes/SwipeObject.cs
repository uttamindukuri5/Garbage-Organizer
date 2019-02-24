using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwipeObject : MonoBehaviour
{
    Vector2 startPos, endPos, direction;

    float touchTimeStart, touchTimeFinish, timeInterval;

    [SerializeField]
    float throwForceInXandY = 1f;

    [SerializeField]
    float throwForceInZ = 50f;

    private Vector3 trashPosition;
    bool touchGround = false;
    Rigidbody rb;
    public GameObject waterbottle;
    public GameObject burger;
    public GameObject PaperCrane;
    public GameObject matchbox;
    public GameObject cannedfood;
    public GameObject tape;
    public GameObject battery;
    public GameObject Donut; 
    public GameObject Ground;
    public GameObject currentTrash;
    public GameObject[] trashObject;
    public GameObject[] recycleObject;

    public int score;
    public Text scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        trashObject = GameObject.FindGameObjectsWithTag("Trash");
        recycleObject = GameObject.FindGameObjectsWithTag("Recycle");
    }

    // Update is called once per frame
    void Update()
    {
        if(touchGround == false)
        {
            int number2 = Random.Range(0, 2);
            if(number2 == 0)
            {
                int number = Random.Range(0, trashObject.Length);
                currentTrash = trashObject[number];
            }
            else
            {
                int number = Random.Range(0, recycleObject.Length);
                currentTrash = recycleObject[number];
            }
            trashPosition = new Vector3(10.02f, 7f, -7f);
            currentTrash.transform.position = trashPosition;
            rb = currentTrash.GetComponent<Rigidbody>();
            rb.isKinematic = true; 
            touchGround = true;
        }
        // Begin of the swipe
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }
       // End of the swipe
       if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;
            rb.isKinematic = false;
            rb.AddForce(- direction.x *  throwForceInXandY, - direction.y * throwForceInXandY, throwForceInZ / timeInterval); 

        }
        if(Ground.transform.position.y + 1.5 >= currentTrash.transform.position.y)
        {
            touchGround = false;
        }

        if((5.5f < currentTrash.transform.position.x) && (currentTrash.transform.position.x < 10.3f) && (3.8f < currentTrash.transform.position.y) && (currentTrash.transform.position.y < 5.4f) && (1.4f < currentTrash.transform.position.z) && (currentTrash.transform.position.z < 3.0f))
        {
            score++;
            touchGround = false;
        }
        if (((11.92f < currentTrash.transform.position.x) && (currentTrash.transform.position.x < 14.48f) && (3.82f < currentTrash.transform.position.y) && (currentTrash.transform.position.y < 5.42f) && (1.1f < currentTrash.transform.position.z) && (currentTrash.transform.position.z < 2.7f)))
        {
            score++;
            touchGround = false;
        }

        scoreLabel.text = "Score: " + score;
    }
}
