using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] float slowMoSpeed = 0.5f;
    [SerializeField] float timeForSlowMo = 3f;

    private float gameSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void StartSlowMo()
    {
        StartCoroutine(SlowMo(slowMoSpeed));
    }

    private IEnumerator SlowMo(float speed)
    {
        gameSpeed = speed;

        yield return new WaitForSeconds(timeForSlowMo);

        gameSpeed = 1f;
    }

    public void ResetEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<EnemyController>().IsDead())
            {
                enemy.GetComponent<EnemyController>().Reset();
            }
        }
    }
}
