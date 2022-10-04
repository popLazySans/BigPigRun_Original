using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGSoundScript : MonoBehaviour {
	// Use this for initialization
	public int off;
	void Start () {
		
	}

    //Play Global
    private static BGSoundScript instance = null;
    public static BGSoundScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (IsGameObjectShouldDestroy())
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
		//important
			DontDestroyOnLoad (this.gameObject);

    }
    //Play Gobal End

    bool IsGameObjectShouldDestroy()
	{
        return instance != null && instance != this;

    }

    // Update is called once per frame
    void Update () {
		off = Link.off;
		if (off == 1) {
			this.gameObject.SetActive (false);
		} 
	}
}
