using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateFood : MonoBehaviour
{
    public RandomFoodType[] randomFoodTypes;
    protected List<Vector2> playersPos;

    public void createFoods()
    {
        //设置所有子对象失活，后更具失活对象清除
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        Bounds bounds = this.GetComponent<BoxCollider2D>().bounds;

        //随机数总和
        float totalValue = 0f;
        for (int i = 0; i < randomFoodTypes.Length; i++)
        {
            totalValue += randomFoodTypes[i].Probability;
        }
        ;
        //玩家对象
        playersPos = new List<Vector2>();
        GameObject[] playersObj = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < playersObj.Length; i++)
        {
            playersPos.Add(new Vector2(Mathf.Floor(playersObj[i].transform.position.x), Mathf.Floor(playersObj[i].transform.position.y)));
        }

        for (int i = 0; i < Mathf.Round(bounds.max.y * 2); i++)
        {
            for (int j = 0; j < Mathf.Round(bounds.max.x * 2); j++)
            {
                Vector2 newPos = new Vector2(Mathf.Round(bounds.min.x) + j + 1, Mathf.Round(bounds.min.y) + i + 1);
                //遇到玩家对象跳过
                bool thisPlayer = false;
                for (int z = 0; z < playersPos.Count; z++)
                {
                    if (playersPos[z].x == newPos.x && playersPos[z].y == newPos.y)
                    {
                        playersPos.RemoveAt(z);
                        thisPlayer = true;
                    }
                }
                if (thisPlayer) continue;

                //随机化生成对象
                float r = UnityEngine.Random.Range(0.0f, totalValue);
                GameObject obj = null;
                float cumulativeValue = 0f;

                for (int g = 0; g < randomFoodTypes.Length; g++)
                {
                    cumulativeValue += randomFoodTypes[g].Probability;
                    if (r <= cumulativeValue)
                    {
                        obj = GameObject.Instantiate(randomFoodTypes[g].FoodType);
                        break;
                    }
                }

                obj.name = $"Food_{i}{j}";

                obj.transform.SetParent(this.transform, true);
                obj.transform.position = new Vector3(newPos.x, newPos.y, 0.0f);
            }
        }

        //clear unActive child object
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf == false) Destroy(transform.GetChild(i).gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        createFoods();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) createFoods();
    }
}

[System.Serializable]
public class RandomFoodType
{
    public GameObject FoodType;
    [Range(0f, 1f)] public float Probability;
}
