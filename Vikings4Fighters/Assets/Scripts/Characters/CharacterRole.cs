using UnityEngine;
using System.Collections;

public class CharacterRole  {

	public enum Role { Tank, Damager, Support}
	public Role MyRole;
	float agro;

	public CharacterRole (string role){
		for (MyRole = CharacterRole.Role.Tank; MyRole <= CharacterRole.Role.Support; MyRole++)
			if (MyRole.ToString() == role)
				break;
	}


	public float GetAgro(){
		switch (MyRole) {
		case Role.Tank:
			agro = 1;
			break;
		case Role.Damager:
			agro = 1.5f;
			break;
		case Role.Support:
			agro = 2;
			break;
		}

		return agro;
	}
		
}
