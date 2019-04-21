using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int selectedCharacterIndex;
    enum CharactersIndex {
        PUG = 1,
    	TARTARUGA = 3,
        PATO = 2
    };

    void Start()
    {
        selectedCharacterIndex = (int)CharactersIndex.PUG;
    }

    void Update()
    {
        SelectCharacter();
    }

    //1 é o pug, 2 é o pato, 3 é a tartaruga
    void SelectCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedCharacterIndex = (int)CharactersIndex.PUG;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedCharacterIndex = (int)CharactersIndex.PATO;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedCharacterIndex = (int)CharactersIndex.TARTARUGA;
        }
    }
}
