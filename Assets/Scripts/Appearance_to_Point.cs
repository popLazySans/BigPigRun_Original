using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance_to_Point : MonoBehaviour
{
	private Set_Appearance appearance;
	private Point point;
    // Start is called before the first frame update
    void Start()
    {
		appearance = GetComponent<Set_Appearance>();
		point = GetComponent<Point>();
		checkGender();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	public void checkGender()
	{
		if (appearance.gender == 1) { Man_Calculator(); }
		if (appearance.gender == 2) { Woman_Calculator(); }
	}
	public void Man_Calculator()
	{
		point.point_current = ((10f * appearance.height) + (6.25f * appearance.weight) - (5f * appearance.age) + 5f) * 1.2f;
	}
	public void Woman_Calculator()
	{
		point.point_current = ((10f * appearance.height) + (6.25f * appearance.weight) - (5f * appearance.age) - 161f) * 1.2f;
	}
}
