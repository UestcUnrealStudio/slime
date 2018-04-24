using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUnit : MonoBehaviour {
    public List<float> skillTimes;


    public float[] currentSkillTimes;

    private bool isStart = false;
    public void SetStart(bool isStart)
    {
        this.isStart = isStart;
    }
    public bool GetStart()
    {
        return isStart;
    }
    // Use this for initialization
	void Start () {
        currentSkillTimes = new float[skillTimes.Count];
        InitSkillTimes();
        isStart = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isStart)
        {
            for (int i = 0; i < currentSkillTimes.Length; i++)
            {
                if (currentSkillTimes[i] < skillTimes[i])
                {
                    currentSkillTimes[i] += Time.deltaTime;
                }
            }
        }
	}

    void InitSkillTimes()
    {
        for (int i = 0; i < skillTimes.Count; i++)
        {
            currentSkillTimes[i] = skillTimes[i];
        }
    }

    public void ReSetCurrentSkillTime(int index)
    {
        currentSkillTimes[index] = 0;
    }

    public float GetCurrentSkillTime(int index)
    {
        return currentSkillTimes[index];
    }

    public bool IsSkillReady(int index)
    {
        if (currentSkillTimes[index] >= skillTimes[index])
        {
            return true;
        }
        return false;
    }
}
