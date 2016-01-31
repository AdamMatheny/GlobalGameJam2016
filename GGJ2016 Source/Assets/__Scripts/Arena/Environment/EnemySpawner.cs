using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public float percent;

    public ArenaBullSpawner bullSpawner;

    public GameObject enemy;

    public float enemyAmount;

    public ArenaPlayer mTargetPlayer;

	float mArenaSpawnTimer = 2f;
	public float mArenaSpawnTimerDefault = 2f;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("ArenaRound", PlayerPrefs.GetInt("ArenaRound") + 1);

        StartCoroutine(uheuhf());

		mArenaSpawnTimer = mArenaSpawnTimerDefault;
        /**/

        // foreach()
    }

    IEnumerator uheuhf()
    {


        if (mTargetPlayer == null)
        {
            mTargetPlayer = FindObjectOfType<ArenaPlayer>();
        }

        if (bullSpawner == null)
        {
            bullSpawner = FindObjectOfType<ArenaBullSpawner>();
        }
        yield return new WaitForSeconds(2.0f);


        //enemyAmount = Mathf.Round(mTargetPlayer.GetComponent<ArenaPlayer>().tomatoCount * (percent / 100)) + PlayerPrefs.GetInt("ArenaRound");

        enemyAmount = Mathf.Round(mTargetPlayer.GetComponent<ArenaPlayer>().tomatoCount * .25f);


		if(enemyAmount > 0)
		{
			SpawnAtGate();
			enemyAmount--;
		}

//        for (int i = 0; i < enemyAmount; i++)
//        {
//            GameObject spawnGate = null;
//            if (bullSpawner.mBullExits.Count > 0)
//            {
//                spawnGate = bullSpawner.mBullExits[Mathf.FloorToInt(Random.Range(0, bullSpawner.mBullExits.Count))].gameObject;
//            }
//
//            if (spawnGate != null)
//            {
//                Instantiate(enemy, spawnGate.transform.position, Quaternion.identity);
//            }
//        }

        //print("Ok");
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyAmount > 0)
        {
            mArenaSpawnTimer -= Time.deltaTime;
            if (mArenaSpawnTimer <= 0f)
            {
                SpawnAtGate();
                enemyAmount--;
                mArenaSpawnTimer = mArenaSpawnTimerDefault;
                if (mArenaSpawnTimerDefault > 0.1f)
                {
                    mArenaSpawnTimerDefault -= (0.1f + (PlayerPrefs.GetInt("ArenaRound") * 0.05f));
                }
            }
        }

        if (enemyAmount == 1)
        {

            mTargetPlayer.GetComponent<ArenaPlayer>().gameStarted = true;
        }

    }

	void SpawnAtGate()
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
}
