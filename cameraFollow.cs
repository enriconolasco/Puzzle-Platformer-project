using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    GameManager gm;
    GameObject[] characters = new GameObject[3];
    Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        //Find all gameobjects needed in the scene
        gm = FindObjectOfType<GameManager>();
        characters[0] = FindObjectOfType<PugController>().gameObject;
        characters[1] = FindObjectOfType<PatoController>().gameObject;
        characters[2] = FindObjectOfType<TartarugaController>().gameObject;

        offset = transform.position - characters[gm.selectedCharacterIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(characters[gm.selectedCharacterIndex - 1].transform.position.x + offset.x,
            characters[gm.selectedCharacterIndex - 1].transform.position.y + offset.y, -10); 
    }
}
