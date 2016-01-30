using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public float percent;

    public ArenaBullSpawner bullSpawner;

    public GameObject enemy;

    public float enemyAmount;

    public ArenaPlayer mTargetPlayer;

    // Use this for initialization
    void Start () {

        if (mTargetPlayer == null)
        {
            mTargetPlayer = FindObjectOfType<ArenaPlayer>();
        }

        if (bullSpawner == null)
        {
            bullSpawner = FindObjectOfType<ArenaBullSpawner>();
        }

        enemyAmount = Mathf.Round(mTargetPlayer.GetComponent<ArenaPlayer>().tomatoCount * (percent / 100));

        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject spawnGate = null;
            if (bullSpawner.mBullExits.Count > 0)
            {
                spawnGate = bullSpawner.mBullExits[Mathf.FloorToInt(Random.Range(0, bullSpawner.mBullExits.Count))].gameObject;
            }

            if (spawnGate != null)
            {
                Instantiate(enemy, spawnGate.transform.position, Quaternion.identity);
            }
        }

        // foreach()
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
