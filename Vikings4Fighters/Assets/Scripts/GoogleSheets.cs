using UnityEngine;
using System.Collections;
using UnityEditor;
using Google2u;


public class GoogleSheets : MonoBehaviour {

	static string skillFolderPath = "Assets/Prefabs/Skills/";
	static string workpiecesFolderPath = "Assets/Prefabs/Workpieces/";
	static string heroesFolderPath = "Assets/Prefabs/Heroes/";
	static string enemiesFolderPath = "Assets/Prefabs/Enemies/";

	[MenuItem("GoogleSheets/Download Skills")]
	static void DawnloadSkills () {
		foreach (string skillName in Skills.Instance.rowNames) {
			if (string.IsNullOrEmpty(skillName) || skillName == "None")
				continue;
			CreateSkill (skillName);
		}
	}

	[MenuItem("GoogleSheets/Download Characters")]
	static void DawnloadCharacters () {
		foreach (string characterName in Characters.Instance.rowNames) {
			if (string.IsNullOrEmpty(characterName))
				continue;
			CreateCharacter (characterName);
		}
	}


	static void CreateSkill(string skillName){
		string pathToSkill = skillFolderPath + skillName + ".prefab";
		SkillsRow skillRow = Skills.Instance.GetRow (skillName);
		Skill skillComponent = null;
		bool isNewSkill = false;

		GameObject skill = AssetDatabase.LoadAssetAtPath<GameObject>(pathToSkill);
		if (skill == null) {
			skill = new GameObject (skillName);
			isNewSkill = true;
		}

		if(skill.GetComponent<Skill> () == null)
			skill.AddComponent<Skill> ();
		
		skillComponent = skill.GetComponent<Skill> ();
		skillComponent.SkillName = skillRow._name;
		skillComponent.damageModifier = skillRow._damageModifier;
		skillComponent.accuracyModifier = skillRow._accuracyModifier;
		skillComponent.critDamageModifier = skillRow._critDamageModifier;
		skillComponent.critChanceModifier = skillRow._critChanceModifier;
		skillComponent.CanUseInPositions = skillRow._canUse_positions.ToArray();
		skillComponent.CanToGetTarget = skillRow._canHit_positions.ToArray();
		skillComponent.SetAddedEffect(skillRow._addEffect);
		skillComponent.SetSkillTarget(skillRow._myTargets);
		skillComponent.targetsQuantity = skillRow._targetsQuantity;

		if (isNewSkill) {
			PrefabUtility.CreatePrefab (pathToSkill, skill);
			DestroyImmediate (skill);
		}
	}


	static void CreateCharacter(string characterName){
		CharactersRow characterRow = Characters.Instance.GetRow (characterName);
		Character characterComponent = null;
		bool isNewCharacter = false;
		string folderPath = "";

		//find path to character prefab
		if(characterRow._essence == Character.Essences.Hero.ToString())
			folderPath = heroesFolderPath + characterName + ".prefab";
		else
			folderPath = enemiesFolderPath + characterName + ".prefab";

		GameObject characterPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(folderPath);
		if (characterPrefab == null) {
			string pathToModel = workpiecesFolderPath + characterRow._characterModel + ".prefab";
			characterPrefab = AssetDatabase.LoadAssetAtPath<GameObject> (pathToModel);
			if (characterPrefab == null) {
				Debug.Log (characterRow._characterModel + " нету в папке Workpieces");
				return;
			}
			isNewCharacter = true;
		}
		GameObject character = Instantiate (characterPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		character.name = characterName;

		if(character.GetComponent<Character> () == null)
			character.AddComponent<Character> ();

		characterComponent = character.GetComponent<Character> ();
		characterComponent.CharacterName = characterRow._name;
		characterComponent.Damage = new Damage(characterRow._damageMin, characterRow._damageMax);
		characterComponent.Health = new Health (characterRow._health, characterRow._health);
		characterComponent.CriticalChance = (int)characterRow._critChance;
		characterComponent.CriticalModifare = characterRow._critDamage;
		characterComponent.Initiative = new Initiative(characterRow._initiative);
		characterComponent.SetEssence(characterRow._essence);
		characterComponent.Role = new CharacterRole(characterRow._role);
		character.tag = characterComponent.myEssences.ToString();

		characterComponent.personalCanvas = character.GetComponentInChildren<PersonalCanvas> ();
		characterComponent.activeEffect = character.GetComponentInChildren<ParticleSystem> ();

		if (characterComponent.myEssences == Character.Essences.Hero) {
			if (character.GetComponent<HeroSkillsManager> () == null)
				character.AddComponent<HeroSkillsManager> ();
		} else {
			if (character.GetComponent<EnemiesSkillsManager> () == null)
				character.AddComponent<EnemiesSkillsManager> ();
		}

		string[] skillNames = new string[] {
			characterRow._skill_1,
			characterRow._skill_2,
			characterRow._skill_3,
			characterRow._skill_4};

		SkillsManager skillManager = character.GetComponent<SkillsManager> ();
		for (int i = 0; i < skillNames.Length; i++) {
			if (skillNames [i] == "None" || string.IsNullOrEmpty (skillNames [i]))
				continue;

			string pathToskill = skillFolderPath + skillNames [i] + ".prefab";
			GameObject skill = AssetDatabase.LoadAssetAtPath<GameObject> (pathToskill);
			if (skill == null) {
				Debug.Log (skillNames [i] + " не найдено в папке Skills");
				continue;
			}
				
			GameObject newSkill = Instantiate (skill, Vector3.zero, Quaternion.identity) as GameObject;
			newSkill.transform.parent = character.transform;

			if (skillManager.Skills [i] != null) {
				DestroyImmediate (skillManager.Skills [i].gameObject);
			}
			skillManager.Skills [i] = newSkill.GetComponent<Skill> ();
		}
		if (isNewCharacter) {
			PrefabUtility.CreatePrefab (folderPath, character);
		} else {
			PrefabUtility.ReplacePrefab (character, characterPrefab);
		}
		DestroyImmediate (character);
	}
		
		
}
