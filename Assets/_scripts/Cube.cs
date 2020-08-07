using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cube : MonoBehaviour {
	
	public Camera[] cameras;
	public GUIStyle labelStyle;
    public GUIStyle buttonStyle;
    public GUIStyle textStyle;
	private float horizontalSlider = 5;
	private float rotationSpeed = 0;
	private int rotationCounter = 0;
	private bool shuffleLocked = false;
	private bool rotationLocked = false;
    private int step = 0;

	void OnGUI()
	{
        if (0 <= step && step <= 21)
        {
            GUI.Label(new Rect((Screen.width) - 400, 30 + 30, 100, 100), "1. Solve Bottom Layer", textStyle);
            GUI.Label(new Rect((Screen.width) - 400, 70 + 30, 100, 100), "Move the Bottom Right piece out.", textStyle);
            GUI.Label(new Rect((Screen.width) - 400, 110 + 30, 100, 100), "Move the bottom right piece away.", textStyle);
            GUI.Label(new Rect((Screen.width) - 400, 150 + 30, 100, 100), "Turn the Right Face back", textStyle);
            GUI.Label(new Rect((Screen.width) - 400, 190 + 30, 100, 100), "Turn the Top Layer back", textStyle);

        }
        if (21 < step && step <= 23)
        GUI.Label(new Rect((Screen.width) - 400, 30 + 30, 100, 100), "2. Put Every Piece In Correct Spot", textStyle);
        if (24 <= step && step <= 32)
        {
            GUI.Label(new Rect((Screen.width) - 400, 30 + 30, 100, 100), "3. Solve Top Layer", textStyle);
            GUI.Label(new Rect((Screen.width) - 400, 70 + 30, 100, 100), "Move the Bottom Right piece out", textStyle);
            GUI.Label(new Rect((Screen.width) - 400, 110 + 30, 100, 100), "Move the bottom right piece away", textStyle);
            GUI.Label(new Rect((Screen.width) - 400, 150 + 30, 100, 100), "Turn the Right Face back", textStyle);
            GUI.Label(new Rect((Screen.width) - 400, 190 + 30, 100, 100), "Turn the Top Layer back", textStyle);
            GUI.Label(new Rect((Screen.width) - 400, 230 + 30, 100, 100), "Don't rotate the whole cube!", textStyle);
        }
            if (32   < step)
            GUI.Label(new Rect((Screen.width) - 400, 30 + 30, 100, 100), "Solved!", textStyle);
        if (GUI.Button(new Rect(Screen.width - 80, Screen.height - 150, 50, 30), "Next", buttonStyle) && !this.shuffleLocked)

            Application.LoadLevel(4);

        if (GUI.Button(new Rect(Screen.width - 80, Screen.height - 150 + 40, 50, 30), "Shuffle", buttonStyle) && !this.shuffleLocked)
			StartCoroutine(FixedShuffle());
        


        if(GUI.Button(new Rect(Screen.width - 80, Screen.height - 150 + 80, 50, 30), "Reset", buttonStyle) && !this.shuffleLocked)

            Application.LoadLevel(3);

        if (GUI.Button(new Rect(Screen.width - 80, Screen.height - 150 + 120, 50, 30), "Quit", buttonStyle) && !this.shuffleLocked)
            Application.Quit();

            GUI.Label(new Rect((Screen.width / 2) - 150, 10, 100, 30), "Rotation Speed: Normal", labelStyle);
		horizontalSlider = Mathf.Round (GUI.HorizontalSlider (new Rect ((Screen.width / 2) - 150, 50, 300, 300), horizontalSlider, 1, 10));
        horizontalSlider = 0.5f;
        // Converte o intervalo de [1, 10] para [0.1,0.3]
        // Formula
        // NewValue = (((OldValue - OldMin) * (NewMax - NewMin)) / (OldMax - OldMin)) + NewMin
        rotationSpeed = 0.005f;
	}
    void doTutorial(int counter) {
        //if (Input.GetKeyDown(KeyCode.U) && !this.rotationLocked)
        //    StartCoroutine(RotateFace("TopFace", 'y', 90));

        //if (Input.GetKeyDown(KeyCode.I) && !this.rotationLocked)
        //    StartCoroutine(RotateFace("TopFace", 'y', -90));
        //if (Input.GetKeyDown(KeyCode.R) && !this.rotationLocked)
        //    StartCoroutine(RotateFace("FrontFace", 'z', -90));

        //if (Input.GetKeyDown(KeyCode.T) && !this.rotationLocked)
        //    StartCoroutine(RotateFace("FrontFace", 'z', 90));
        if (counter == 1)
        {
            StartCoroutine(RotateFace("FrontFace", 'z', -90));
        }
        else if (counter == 2)
        {
            StartCoroutine(RotateFace("TopFace", 'y', 90f));
        }
        else if (counter == 3)
        {
            StartCoroutine(RotateFace("FrontFace", 'z', 90));
        }
        else if (counter == 4)
        {
            StartCoroutine(RotateFace("TopFace", 'y', -90f));
        }
        else if (counter == 5)
        {
            StartCoroutine(Algorithm(1));
        }
        else if (counter == 6)
        {
            StartCoroutine(RotateCube('y', 90));
        }
        else if (counter == 7)
        {
            StartCoroutine(RotateFace("FrontFace", 'z', -90));
        }
        else if (counter == 8)
        {
            StartCoroutine(RotateFace("TopFace", 'y', 90f));
        }
        else if (counter == 9)
        {
            StartCoroutine(RotateFace("FrontFace", 'z', 90));
        }
        else if (counter == 10)
        {
            StartCoroutine(RotateFace("TopFace", 'y', -90f));
        }
        else if (counter == 11)
        {
            StartCoroutine(RotateCube('y', -90));
        }
        else if (counter == 12)
        {
            StartCoroutine(RotateFace("TopFace", 'y', 90f));
        }
        else if (counter == 13)
        {
            StartCoroutine(RotateFace("TopFace", 'y', 90f));
        }
        else if (counter == 14)
        {
            StartCoroutine(RotateCube('y', -90));
        }
        else if (counter == 15)
        {
            StartCoroutine(Algorithm(1));
        }
        else if (counter == 16)
        {
            StartCoroutine(RotateCube('y', -180));
        }
        else if (counter == 17)
        {
            StartCoroutine(RotateFace("TopFace", 'y', 180f));
        }
        else if (counter == 18)
        {
            StartCoroutine(Algorithm(1));
        }
        else if (counter == 19)
        {
            StartCoroutine(RotateFace("TopFace", 'y', 90f));
        }
        else if (counter == 20)
        {
            StartCoroutine(RotateCube('y', 90));
        }
        else if (counter == 21)
        {
            StartCoroutine(Algorithm(1));
        }
        else if (counter == 22)
        {
            StartCoroutine(RotateFace("TopFace", 'y', 90f));
        }
        else if (counter == 23)
        {
            StartCoroutine(RotateFace("TopFace", 'y', 90f));
        }
        else if (counter == 24) {
            StartCoroutine(RotateCube('x', 180));
        }
        else if (counter == 25)
        {
            StartCoroutine(Algorithm(1));
        }
        else if (counter == 26)
        {
            StartCoroutine(Algorithm(1));
        }
        else if (counter == 27)
        {
            StartCoroutine(Algorithm(1));
        }
        else if (counter == 28)
        {
            StartCoroutine(Algorithm(1));
        }
        else if (counter == 29)
        {
            StartCoroutine(RotateFace("BottomFace", 'y', 90f));
        }
        else if (counter == 30)
        {
            StartCoroutine(Algorithm(1));
        }
        else if (counter == 31)
        {
            StartCoroutine(Algorithm(3));
        }
        else if (counter == 32)
        {
            StartCoroutine(RotateCube('x', 180));
        }
        else if (counter == 33)
        {
            Application.LoadLevel(4);
        }





    }
    IEnumerator FixedShuffle()
    {
        this.shuffleLocked = true;
        //DUfUFRdbFBb
        int[] arr = new int[]{3,1,4,1,5,9,2,6,5,7,6};
        int i = 0;
        while (i < 11)
        {
          
            if (!this.rotationLocked)
            {
                switch (arr[i])
                {
                    case 0:
                        StartCoroutine(RotateFace("TopFace", 'y', 90f));
                        break;
                    case 1:
                        StartCoroutine(RotateFace("TopFace", 'y', -90f));
                        break;
                    case 2:
                        StartCoroutine(RotateFace("BottomFace", 'y', -90f));
                        break;
                    case 3:
                        StartCoroutine(RotateFace("BottomFace", 'y', 90f));
                        break;
                    case 4:
                        StartCoroutine(RotateFace("LeftFace", 'x', -90f));
                        break;
                    case 5:
                        StartCoroutine(RotateFace("LeftFace", 'x', 90f));
                        break;
                    case 6:
                        StartCoroutine(RotateFace("RightFace", 'x', -90f));
                        break;
                    case 7:
                        StartCoroutine(RotateFace("RightFace", 'x', 90f));
                        break;
                    case 8:
                        StartCoroutine(RotateFace("FrontFace", 'z', -90f));
                        break;
                    case 9:
                        StartCoroutine(RotateFace("FrontFace", 'z', 90f));
                        break;
                    case 10:
                        StartCoroutine(RotateFace("BackFace", 'z', -90f));
                        break;
                    case 11:
                        StartCoroutine(RotateFace("BackFace", 'z', 90f));
                        break;
                }
                i++;
            }
            else
                yield return null;
        }
        this.shuffleLocked = false;
    }
    IEnumerator Algorithm(int num)
    {   //if (Input.GetKeyDown(KeyCode.U) && !this.rotationLocked)
        //    StartCoroutine(RotateFace("TopFace", 'y', 90));

        //if (Input.GetKeyDown(KeyCode.I) && !this.rotationLocked)
        //    StartCoroutine(RotateFace("TopFace", 'y', -90));
        //if (Input.GetKeyDown(KeyCode.R) && !this.rotationLocked)
        //    StartCoroutine(RotateFace("FrontFace", 'z', -90));

        //if (Input.GetKeyDown(KeyCode.T) && !this.rotationLocked)
        //    StartCoroutine(RotateFace("FrontFace", 'z', 90));
        this.shuffleLocked = true;
        int[] arr;
        if (num == 1) {
            arr = new int[] { 8, 0, 9, 1 };
        } else if (num == 2) {
            arr = new int[] { 0, 8, 1, 10, 0, 9, 1, 11 };
        } else {
            arr = new int[] { 8, 0, 9 };
        }

        int i = 0;
        while (i < arr.Length)
        {
            if (!this.rotationLocked)
            {
                switch (arr[i])
                {
                    case 0:
                        StartCoroutine(RotateFace("TopFace", 'y', 90f));
                        break;
                    case 1:
                        StartCoroutine(RotateFace("TopFace", 'y', -90f));
                        break;
                    case 2:
                        StartCoroutine(RotateFace("BottomFace", 'y', -90f));
                        break;
                    case 3:
                        StartCoroutine(RotateFace("BottomFace", 'y', 90f));
                        break;
                    case 4:
                        StartCoroutine(RotateFace("LeftFace", 'x', -90f));
                        break;
                    case 5:
                        StartCoroutine(RotateFace("LeftFace", 'x', 90f));
                        break;
                    case 6:
                        StartCoroutine(RotateFace("RightFace", 'x', -90f));
                        break;
                    case 7:
                        StartCoroutine(RotateFace("RightFace", 'x', 90f));
                        break;
                    case 8:
                        StartCoroutine(RotateFace("FrontFace", 'z', -90f));
                        break;
                    case 9:
                        StartCoroutine(RotateFace("FrontFace", 'z', 90f));
                        break;
                    case 10:
                        StartCoroutine(RotateFace("BackFace", 'z', -90f));
                        break;
                    case 11:
                        StartCoroutine(RotateFace("BackFace", 'z', 90f));
                        break;
                }
                i++;
            }
            else
                yield return null;
        }
        this.shuffleLocked = false;
    }

    // Update is called once per frame
    void Update ()
	{
        if (Input.GetMouseButtonDown(0) && !this.rotationLocked)
        {
            doTutorial(step);
            step++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
			SelectCamera ("Camera1");
		
		if(Input.GetKeyDown(KeyCode.Alpha2))
			SelectCamera ("Camera2");
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectCamera ("Camera3");

        if (Input.GetKeyDown(KeyCode.X) && !this.rotationLocked)
			StartCoroutine(RotateCube('x', 90));
		
		//if(Input.GetKeyDown (KeyCode.C) && !this.rotationLocked)
		//	StartCoroutine(RotateCube('x', -90));
		
		if(Input.GetKeyDown (KeyCode.Y) && !this.rotationLocked)
			StartCoroutine (RotateCube ('y', 90));
		
		//if(GetKeyDown (KeyCode.Y) && !this.rotationLocked)
		//	StartCoroutine (RotateCube ('y', -90));
		
		if(Input.GetKeyDown (KeyCode.Z) && !this.rotationLocked)
			StartCoroutine (RotateCube ('z', 90));
		
		//if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.Z) && !this.rotationLocked)
		//	StartCoroutine (RotateCube ('z', -90));
		
		if(Input.GetKeyDown(KeyCode.U) && !this.rotationLocked)
			StartCoroutine(RotateFace ("TopFace", 'y', 90));
		
		if(Input.GetKeyDown(KeyCode.I) && !this.rotationLocked)
			StartCoroutine(RotateFace ("TopFace", 'y', -90));
		
		if(Input.GetKeyDown(KeyCode.B) && !this.rotationLocked)
			StartCoroutine(RotateFace ("BottomFace", 'y', 90));
		
		if(Input.GetKeyDown(KeyCode.N) && !this.rotationLocked)
			StartCoroutine(RotateFace ("BottomFace", 'y', -90)); 
		
		if(Input.GetKeyDown(KeyCode.F) && !this.rotationLocked)
			StartCoroutine(RotateFace ("LeftFace", 'x', -90));
		
		if(Input.GetKeyDown(KeyCode.G) && !this.rotationLocked)
			StartCoroutine(RotateFace ("LeftFace", 'x', 90));
		
		//if(Input.GetKeyDown(KeyCode.R) && !this.rotationLocked)
		//	StartCoroutine(RotateFace ("RightFace", 'x', -90));
		
		//if(Input.GetKeyDown(KeyCode.T) && !this.rotationLocked)
		//	StartCoroutine(RotateFace ("RightFace", 'x', 90));
		
		if(Input.GetKeyDown(KeyCode.R) && !this.rotationLocked)
			StartCoroutine(RotateFace ("FrontFace", 'z', -90));
		
		if(Input.GetKeyDown(KeyCode.T) && !this.rotationLocked)
			StartCoroutine(RotateFace ("FrontFace", 'z', 90));

        if (Input.GetKeyDown(KeyCode.L) && !this.rotationLocked)
            StartCoroutine(RotateFace("BackFace", 'z', -90));

        if (Input.GetKeyDown(KeyCode.Semicolon) && !this.rotationLocked)
            StartCoroutine(RotateFace("BackFace", 'z', 90));
    }

	public void DoRotate(string faceTag, char axisName, float angle)
	{
		GameObject face = GameObject.FindGameObjectWithTag(faceTag);
		GameObject[] slices = GameObject.FindGameObjectsWithTag("Slice");

		foreach(GameObject slice in slices)
		{
				switch(axisName) 
				{
				case 'x':
						if(Mathf.RoundToInt (slice.transform.position.x) == Mathf.RoundToInt (face.transform.position.x))
								slice.transform.parent = face.transform;
						break;
				case 'y':
						if(Mathf.RoundToInt (slice.transform.position.y) == Mathf.RoundToInt (face.transform.position.y))
								slice.transform.parent = face.transform;
						break;
				case 'z':
						if(Mathf.RoundToInt (slice.transform.position.z) == Mathf.RoundToInt (face.transform.position.z))
								slice.transform.parent = face.transform;
						break;
				}
		}

		Quaternion rotation;
		switch(axisName)
		{
		case 'x':
				rotation = Quaternion.Euler(angle, 0, 0);
				break;
		case 'y':
				rotation = Quaternion.Euler(0, angle, 0);
				break;
		case 'z':
				rotation = Quaternion.Euler(0, 0, angle);
				break;
		default:
				rotation = Quaternion.Euler(0, 0, 0);
				break;
		}
		face.transform.rotation = rotation;
	}

	public void AnimateRotate(string faceTag, char axisName, float angle)
	{
		StartCoroutine (RotateFace(faceTag, axisName, angle));
	}
	
	IEnumerator ShuffleCube()
	{
		this.shuffleLocked = true;
		int i = 0;
		while(i < 25)
		{
			if(!this.rotationLocked)
			{
				switch(Random.Range(0, 11))
				{
					case 0:
						StartCoroutine(RotateFace ("TopFace", 'y', 90f));
						break;
					case 1:
						StartCoroutine(RotateFace ("TopFace", 'y', -90f));
						break;
					case 2:
						StartCoroutine(RotateFace ("BottomFace", 'y', -90f));
						break;
					case 3:
						StartCoroutine(RotateFace ("BottomFace", 'y', 90f));
						break;
					case 4:
						StartCoroutine(RotateFace ("LeftFace", 'x', -90f));
						break;
					case 5:
						StartCoroutine(RotateFace ("LeftFace", 'x', 90f));
						break;
					case 6:
						StartCoroutine(RotateFace ("RightFace", 'x', -90f));
						break;
					case 7:
						StartCoroutine(RotateFace ("RightFace", 'x', 90f));
						break;
					case 8:
						StartCoroutine(RotateFace ("FrontFace", 'z', -90f));
						break;
					case 9:
						StartCoroutine(RotateFace ("FrontFace", 'z', 90f));
						break;
					case 10:
						StartCoroutine(RotateFace ("BackFace", 'z', -90f));
						break;
					case 11:
						StartCoroutine(RotateFace ("BackFace", 'z', 90f));
						break;
					}
					i++;
			}
			else
				yield return null;
		}
		this.shuffleLocked = false;
	}
	
	IEnumerator RotateFace(string faceTag, char axisName, float angle)
	{	
		GameObject face = GameObject.FindGameObjectWithTag(faceTag);
		GameObject[] slices = GameObject.FindGameObjectsWithTag("Slice");
		
		if(!this.shuffleLocked)
			this.rotationCounter++;
		
		this.rotationLocked = true;
		
		foreach(GameObject slice in slices)
		{
			switch(axisName)
			{
				case 'x':
					if(Mathf.RoundToInt (slice.transform.position.x) == Mathf.RoundToInt (face.transform.position.x))
						slice.transform.parent = face.transform;
					break;
				case 'y':
					if(Mathf.RoundToInt (slice.transform.position.y) == Mathf.RoundToInt (face.transform.position.y))
						slice.transform.parent = face.transform;
					break;
				case 'z':
					if(Mathf.RoundToInt (slice.transform.position.z) == Mathf.RoundToInt (face.transform.position.z))
						slice.transform.parent = face.transform;
					break;
			}
		}
		
		float i = 0.0f;
		while(i < 1.0f)
		{
			i += rotationSpeed;
			Quaternion rotation;
			switch(axisName)
			{
				case 'x':
					rotation = Quaternion.Euler(angle, 0, 0);
					break;
				case 'y':
					rotation = Quaternion.Euler(0, angle, 0);
					break;
				case 'z':
					rotation = Quaternion.Euler(0, 0, angle);
					break;
				default:
					rotation = Quaternion.Euler(0, 0, 0);
					break;
			}
			face.transform.rotation = Quaternion.Lerp(face.transform.rotation, rotation, i);
			yield return null;
		}
		
		foreach(GameObject slice in slices)
		{
			switch(axisName)
			{
				case 'x':
					if(Mathf.RoundToInt (slice.transform.position.x) == Mathf.RoundToInt (face.transform.position.x))
						slice.transform.parent = this.gameObject.transform;
					break;
				case 'y':
					if(Mathf.RoundToInt (slice.transform.position.y) == Mathf.RoundToInt (face.transform.position.y))
						slice.transform.parent = this.gameObject.transform;
					break;
				case 'z':
					if(Mathf.RoundToInt (slice.transform.position.z) == Mathf.RoundToInt (face.transform.position.z))
						slice.transform.parent = this.gameObject.transform;
					break;
			}
		}
		
		face.transform.rotation = Quaternion.Euler (0, 0, 0);
		this.rotationLocked = false;
	}
	
	IEnumerator RotateCube(char axis, float axisValue)
	{
		GameObject innerPoint = GameObject.FindGameObjectWithTag("InnerPoint");
		GameObject[] slices = GameObject.FindGameObjectsWithTag("Slice");
		
		this.rotationLocked = true;
		
		foreach(GameObject slice in slices)
			slice.transform.parent = innerPoint.transform;
			
		float i = 0.0f;
		Quaternion rotation;
		while(i < 1.0f)
		{
			i += 0.1f;
			switch(axis)
			{
				case 'x':
					rotation = Quaternion.Euler (axisValue, 0, 0);
					break;
				case 'y':
					rotation = Quaternion.Euler (0, axisValue, 0);
					break;
				case 'z':
					rotation = Quaternion.Euler (0, 0, axisValue);
					break;
				default:
					rotation = Quaternion.Euler (0, 0, 0);
					break;
			}
			innerPoint.transform.rotation = Quaternion.Lerp (innerPoint.transform.rotation, rotation, i);
			yield return null;
		}
		
		foreach(GameObject slice in slices)
			slice.transform.parent = this.gameObject.transform;
		
		innerPoint.transform.rotation = Quaternion.Euler (0, 0, 0);
		
		this.rotationLocked = false;
	}
	
	private void SelectCamera(string cameraTag)
	{
		foreach(Camera camera in this.cameras)
		{
			if(camera.tag == cameraTag)
				camera.gameObject.SetActive(true);
			else
				camera.gameObject.SetActive(false);
		}
	}
}
