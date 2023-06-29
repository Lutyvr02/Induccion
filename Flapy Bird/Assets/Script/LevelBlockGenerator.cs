using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlockGenerator : MonoBehaviour
{
    public LevelBlock levelBlock;
    public LevelBlock lastLevelBlock;
    public LevelBlock CurrentLevelBlock;
    public EnemyMovement blockPipe;
    public float blockGenerationTime=2;
    // Start is called before the first frame update
    void Start()
    {
        AddNewBlock();
        InvokeRepeating("GenerateNewBlockPipe", 0, blockGenerationTime);
    }

    // Update is called once per frame
    void Update()
    {
        float xcam = Camera.main.transform.position.x;
        float xold = lastLevelBlock.exitPoint.position.x;

        if (xcam > xold + lastLevelBlock.width / 2)
        {
            RemoveOldBlock();
        }
    }

    public void AddNewBlock()
    {
        LevelBlock block = (LevelBlock)Instantiate(levelBlock);
        block.transform.SetParent(this.transform, false);

        Vector3 blockPosition = Vector3.zero;

        blockPosition = new Vector3(lastLevelBlock.exitPoint.position.x + block.width / 2,
            lastLevelBlock.exitPoint.position.y, lastLevelBlock.exitPoint.position.z);
        block.transform.position = blockPosition;

        CurrentLevelBlock = block;

    }

    public void RemoveOldBlock()
    {
        lastLevelBlock.transform.position = new Vector3
            (lastLevelBlock.transform.position.x +2 * lastLevelBlock.width,
            lastLevelBlock.transform.position.y,
            lastLevelBlock.transform.position.z);

        LevelBlock temp = lastLevelBlock;
        lastLevelBlock = CurrentLevelBlock;
        CurrentLevelBlock = temp;
        //AddNewBlock();
    }

    public void GenerateNewBlockPipe()
    {
        float distanceToGenerate = levelBlock.width/5;
        float randomy = Random.Range(2, 7);
        EnemyMovement pipeblock = (EnemyMovement)Instantiate(blockPipe);

        float randomV = Random.Range(4, 10);

        Vector3 pipePosition = Vector3.zero;

        pipePosition = new Vector3(
        Camera.main.transform.position.x + distanceToGenerate, randomy, 0);

        pipeblock.speed = randomV;

        pipeblock.transform.position = pipePosition;
    }

}
