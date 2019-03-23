using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
	[SerializeField] GameObject _characterPrefab;
	[SerializeField] List<GameObject> _wayPointList;

	// Start is called before the first frame update
	void Start()
    {
		//Generate();
		StartCoroutine(ExecGenerate());
		//GameObject obj = GameObject.Instantiate<GameObject>(_characterPrefab);
		//obj.transform.position = Vector3.zero;
		//obj.transform.rotation = Quaternion.identity;
		//obj.transform.localScale = Vector3.one;


		//Character character = obj.GetComponent<Character>();
		//character.SetWayPointList(_wayPointList);
	}

	IEnumerator ExecGenerate()
	{
		while(true)
		{
			Generate();
			yield return new WaitForSeconds(5.0f);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void Generate()
	{
		GameObject obj = GameObject.Instantiate<GameObject>(_characterPrefab);
		obj.transform.position = Vector3.zero;
		obj.transform.rotation = Quaternion.identity;
		obj.transform.localScale = Vector3.one;


		Character character = obj.GetComponent<Character>();
		character.SetWayPointList(_wayPointList);
	}
}
