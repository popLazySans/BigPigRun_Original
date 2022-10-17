using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MaterialDatabase : MonoBehaviour
{
	[SerializeField] protected List<MaterialData> materialDataList = new List<MaterialData>();


	private void Awake()
	{
		PrepareDatas();
	}

	public abstract void PrepareDatas();
}
