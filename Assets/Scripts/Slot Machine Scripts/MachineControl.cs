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
    // public Transform handle;

    private int prizeValue;

    private bool resultsChecked = false;
    
void Update()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            prizeValue = 0;
            resultsChecked = true;
        }
        
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && !resultsChecked)
        {
            CheckResults();
            Debug.Log($"Prize: {prizeValue}");

        }

        
    }
    private void OnMouseDown()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            StartCoroutine("PullHandle");
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

    private void CheckResults()
    {
        if (rows[0].stoppedSlot == "Diamond" && rows[2].stoppedSlot == "Diamond" && rows[3].stoppedSlot == "Diamond")
        {
            prizeValue = 200;
        }
        
        //Here must be all results
        else
        {
            prizeValue = 0;
        }

        resultsChecked = true;
    }

}
