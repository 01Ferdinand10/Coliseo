using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WorldConfig : MonoBehaviour
{
    private playerMovement player;
    private EnemyIosh enemyScript;
    private Spawn spawn;
    private Transition teleport;

    private int levelCounter = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyScript = FindAnyObjectByType<EnemyIosh>();
        player = FindAnyObjectByType<playerMovement>();
        spawn = FindAnyObjectByType<Spawn>();
        teleport = FindAnyObjectByType<Transition>();
        Ronda();
    }

    private void Ronda()
    {
        switch (levelCounter)
        {
            case 1:
                Debug.Log("Level 1 creation");
                spawn.Iniciar();
                break;
            
            case 2:
                Debug.Log("Level 2 creation");
                enemyScript.SetearEnemy(2, 3, 2, 2);
                spawn.ToogleDoor();
                spawn.ActivarSpawn(5, 1);
                break;

            case 3:
                Debug.Log("Level 3 creation");
                enemyScript.SetearEnemy(2, 4, 3, 10);
                spawn.ToogleDoor();
                spawn.ActivarSpawn(3, 0);
                break;
        }
    }

    public void LevelSum()
    {
        levelCounter++;

        if(levelCounter == 4)
        {
            StartCoroutine(LoadWinScene());
            return;
        }

        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(20f);
        teleport.Teletransportar();
        Ronda();
    }

    IEnumerator LoadWinScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("WinScene");
    }
}
