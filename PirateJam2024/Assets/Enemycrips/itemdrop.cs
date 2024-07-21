using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemdrop : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] itemList;
    private int itemNum;
    private int randNum;
    private Transform Epos;
    // Start is called before the first frame update
    void Start()
    {

        Epos = GetComponent<Transform>();
    }

    // Update is called once per frame
    public void DropItem()
    {
        randNum = Random.Range(0, 101);

            if (randNum >= 95) 
            {
                itemNum = 2;
                Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);


            }
            else if (randNum > 75 && randNum < 95) 
            {

                itemNum = 1;
                Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);

            }
            else if (randNum > 40 && randNum <= 75)
            {

                itemNum = 0;
                Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);
    }
    }
}
