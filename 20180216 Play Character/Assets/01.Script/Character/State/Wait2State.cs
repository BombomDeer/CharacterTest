using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait2State : State
{
	override public void Start()
	{

		string AnimationString;
		Dictionary<int, string> CorespondingAnimaiton = new Dictionary<int, string>();
		CorespondingAnimaiton.Add(2, "idle3");
		CorespondingAnimaiton.Add(3, "idle4");
		CorespondingAnimaiton.Add(4, "kick");

		int i;

		i = Random.Range(2, 4);

		_character.PlayAnimation(CorespondingAnimaiton[i], () =>
		{
			_character.ChangeState(Character.eState.IDLE);
		});
	}
}
