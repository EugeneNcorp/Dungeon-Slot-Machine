using UnityEngine;
using System.Collections;


public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;
    
    public bool rowStopped;
    public string stoppedSlot;
    public string stoppedColor;

    void Start()
    {
        rowStopped = true;
        MachineControl.HandlePulled += StartRotating;
    }

    private void StartRotating()
    {
        stoppedSlot = "";
        stoppedColor = "";
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.025f;

        for (int i = 0; i < 30; i++)
        {
             if (transform.localPosition.y <= -2f)
             {
                 transform.localPosition = new Vector2(transform.localPosition.x, 2f);
             }
             transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - 0.8f);
                
                yield return new WaitForSeconds(timeInterval);
            
        }

        randomValue = Random.Range(20,30);

        switch ( randomValue % 3)
        {
            case 1:
                randomValue += 2;
                break;
            case 2:
                randomValue += 1;
                break;
        }

        for (int i = 0; i < randomValue; i++)
        {
            
             if (transform.localPosition.y <= -2f)
            {
                 transform.localPosition = new Vector2(transform.localPosition.x, 2f);
            }
            
             transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - 0.8f);

            if (i > Mathf.RoundToInt(randomValue * 0.25f))
            {
                timeInterval = 0.1f;
            }
            else if (i > Mathf.RoundToInt(randomValue * 0.5f))
            {
                timeInterval = 0.2f;
            }
            else if (i > Mathf.RoundToInt(randomValue * 0.75f))
            {
                timeInterval = 0.3f;
            }
            else if (i > Mathf.RoundToInt(randomValue * 0.95f))
            {
                timeInterval = 0.4f;
            }
            
            yield return new WaitForSeconds(timeInterval);
        }

        if (transform.localPosition.y == -2f)
        {
            stoppedSlot = "Diamond";
            stoppedColor = "Red";
        }
        else if (transform.localPosition.y == -1.2f)
        {
            stoppedSlot = "Bell";
            stoppedColor = "Black";
        }
        else if (transform.localPosition.y >= -0.4f && transform.localPosition.y < -0.39)
        {
            stoppedSlot = "Hearts";
            stoppedColor = "Red";
        }
        else if (transform.localPosition.y >= 0.4f && transform.localPosition.y < 0.41)
        {
            stoppedSlot = "Spades";
            stoppedColor = "Black";
        }
        else if (transform.localPosition.y == 1.2f)
        {
            stoppedSlot = "Crown";
            stoppedColor = "Red";
        }
        else if (transform.localPosition.y == 2f)
        {
            stoppedSlot = "Clubs";
            stoppedColor = "Black";
        }

        rowStopped = true;
        
    }
    
    
    private void OnDestroy()
    {
        MachineControl.HandlePulled -= StartRotating;
    }
}
