using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSkill : MonoBehaviour
{
    private Point pointManager;
    // Start is called before the first frame update
    void Start()
    {
        pointManager = GetComponent<Point>();
    }

    // Update is called once per frame
    void Update()
    {
        Ultimate();   
    }
    public void Ultimate()
    {
        if (SanA.lockPoint == 1)
        {
            pointManager.point_current = Point.point_origin;
            SanA.lockPoint = 0;
        }
    }
}
