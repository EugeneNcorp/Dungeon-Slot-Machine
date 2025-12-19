using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class MachineControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    [SerializeField] private Row[] rows;

    [SerializeField] private GameObject Handle1;
    [SerializeField] private GameObject Handle2;
    [SerializeField] private Player player;
    [SerializeField] private GameObject coin;

    private bool resultsChecked = false;

    void Update()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            resultsChecked = false;
        }

        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && !resultsChecked)
        {
            CheckResults();
            //Debug.Log($"Prize: {prizeValue}");

        }


    }

    private void OnMouseDown()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            if (player.moneyCount > 0)
            {
                StartCoroutine("PullHandle");
                player.AddMoney(-1);
            }

        }
    }

    private IEnumerator PullHandle()
    {
        //Rotate the handle
        for (int i = 0; i < 15; i += 5)
        {
            Handle1.SetActive(false);
            Handle2.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }

        HandlePulled();

        //Rotate the handle back
        for (int i = 0; i < 15; i += 5)
        {
            Handle2.SetActive(false);
            Handle1.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }

    
    //this method gives prizes
    private void CheckResults()
    {
        if (rows[0].stoppedSlot == "Diamond" && rows[1].stoppedSlot == "Diamond" && rows[2].stoppedSlot == "Diamond")
        {
            CreateCoin(10);
        }

        else if (rows[0].stoppedSlot == "Bell" && rows[1].stoppedSlot == "Bell" && rows[2].stoppedSlot == "Bell")
        {
            CreateCoin(10);
        }

        else if (rows[0].stoppedSlot == "Hearts" && rows[1].stoppedSlot == "Hearts" && rows[2].stoppedSlot == "Hearts")
        {
            CreateCoin(10);
        }

        else if (rows[0].stoppedSlot == "Diamond" && rows[1].stoppedSlot == "Diamond" &&
                 rows[2].stoppedSlot == "Diamond")
        {
            CreateCoin(10);
        }

        else if (rows[0].stoppedSlot == "Spades" && rows[1].stoppedSlot == "Spades" && rows[2].stoppedSlot == "Spades")
        {
            CreateCoin(10);
        }

        else if (rows[0].stoppedSlot == "Crown" && rows[1].stoppedSlot == "Crown" && rows[2].stoppedSlot == "Crown")
        {
            CreateCoin(10);
        }

        else if (rows[0].stoppedSlot == "Clubs" && rows[1].stoppedSlot == "Clubs" && rows[2].stoppedSlot == "Clubs")
        {
            CreateCoin(10);
        }

        else if (rows[0].stoppedColor == "Black" && rows[1].stoppedColor == "Black" && rows[2].stoppedColor == "Black")
        {
            CreateCoin(3);
        }
        else if (rows[0].stoppedColor == "Red" && rows[1].stoppedColor == "Red" && rows[2].stoppedColor == "Red")
        {
            CreateCoin(3);
        }
        else
        {
            CreateCoin(0);
        }

        resultsChecked = true;
    }

    private void CreateCoin(int value)
    {
        for (int i = 0; i < value; i++)
        {
            Instantiate(coin, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 15f), Quaternion.identity);
        }
        
    }

}
