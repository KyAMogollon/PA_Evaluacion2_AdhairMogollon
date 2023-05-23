using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreSO", menuName = "ScriptableObjects/ScoreSO", order = 2)]
public class ScoreSO : ScriptableObject
{
    [SerializeField] private float[] maxScore;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if(maxScore == null)
        {
            maxScore = new float[10];
        }
    }
    public void RegistryNewScore(float newScore)
    {
        bool isChanged = false;
        float[] newMaxScore = new float[10];
        for(int i = 0; i < 10; i++)
        {
            float savePrevious = maxScore[i];
            if (newScore > maxScore[i] && !isChanged)
            {
                newMaxScore[i] = newScore;
                i++;
                isChanged = true;
            }
            newMaxScore[i] = savePrevious;
        }
        maxScore = newMaxScore;
    }
}
