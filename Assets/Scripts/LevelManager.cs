using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    [SerializeField] private Player player;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private MineSpawner mineSpawner;

    private void Awake()
    {
        StartGame();
    }

    private void LoseGame()
    {
        uIManager.SetActiveLoseWindow();
        enemySpawner.StopSpawn();
        player.OnDied -= LoseGame;
    }

    private void StartGame()
    {
        uIManager.SetActivePlayWindow();
        enemySpawner.SetPlayerPosition(player.transform);
        mineSpawner.SetPlayerPosition(player.transform);
        player.OnDied += LoseGame;
    }
}
