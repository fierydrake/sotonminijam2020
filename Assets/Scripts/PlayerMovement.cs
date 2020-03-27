using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string upKey;
    public string downKey;
    public string leftKey;
    public string rightKey;
    public string interactKey;
    public List<string> moveSet;
    public float velocity = 50.0f;
    public GameObject player;

    private int moveCount = 0;
    private float depth = -2f;
    HashSet<GameObject> players = new HashSet<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        players.Add(CreatePlayer(-4.5f, -4.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            moveSet.Add("up");
            UpdateMovement();
            moveCount++;
        }
        if (Input.GetKeyDown("s"))
        {
            moveSet.Add("down");
            UpdateMovement();
            moveCount++;
        }
        if (Input.GetKeyDown("a"))
        {
            moveSet.Add("left");
            UpdateMovement();
            moveCount++;
        }
        if (Input.GetKeyDown("d"))
        {
            moveSet.Add("right");
            UpdateMovement();
            moveCount++;
        }
        if (Input.GetKeyDown("space"))
        {
            moveSet.Add("interact");
            UpdateMovement();
            moveCount++;
        }
        if (moveCount == 2){
            players.Add(CreatePlayer(-4.5f, -4.5f));
        }
        if (moveCount == 5){
            players.Add(CreatePlayer(-4.5f, -4.5f));
        }
    }

    void UpdateMovement() 
    {
        foreach (GameObject player in players)
        {
            // Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            float xPostition = player.transform.position.x;
            float yPostition = player.transform.position.y;
            switch(moveSet[moveCount - int.Parse(player.name)]){
                case "up":
                    yPostition++;
                    break;
                case "down":
                    yPostition--;
                    break;
                case "left":
                    xPostition--;
                    break;
                case "right":
                    xPostition++;
                    break;
                case "interact":
                    CheckInteraction();
                    break;
                default:
                    print("not valid input");
                    break;
            }
            player.transform.position = new Vector3(xPostition, yPostition, depth);

        }
    }

    GameObject CreatePlayer(float xCoord, float yCoord){
        GameObject newPlayer = Instantiate(player, new Vector3(xCoord, yCoord, depth), Quaternion.identity);
        newPlayer.name = moveCount.ToString();
        return newPlayer;
    }

    void CheckInteraction(){
        print("Interact?");
        
    }
}
