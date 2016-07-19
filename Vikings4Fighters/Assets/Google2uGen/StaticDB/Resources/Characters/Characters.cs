//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class CharactersRow : IGoogle2uRow
	{
		public string _name;
		public int _damageMin;
		public int _damageMax;
		public int _accuracy;
		public int _critDamage;
		public float _critChance;
		public string _essence;
		public string _role;
		public int _health;
		public int _initiative;
		public int _experience;
		public string _skill_1;
		public string _skill_2;
		public string _skill_3;
		public string _skill_4;
		public string _characterModel;
		public CharactersRow(string __ID, string __name, string __damageMin, string __damageMax, string __accuracy, string __critDamage, string __critChance, string __essence, string __role, string __health, string __initiative, string __experience, string __skill_1, string __skill_2, string __skill_3, string __skill_4, string __characterModel) 
		{
			_name = __name.Trim();
			{
			int res;
				if(int.TryParse(__damageMin, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_damageMin = res;
				else
					Debug.LogError("Failed To Convert _damageMin string: "+ __damageMin +" to int");
			}
			{
			int res;
				if(int.TryParse(__damageMax, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_damageMax = res;
				else
					Debug.LogError("Failed To Convert _damageMax string: "+ __damageMax +" to int");
			}
			{
			int res;
				if(int.TryParse(__accuracy, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_accuracy = res;
				else
					Debug.LogError("Failed To Convert _accuracy string: "+ __accuracy +" to int");
			}
			{
			int res;
				if(int.TryParse(__critDamage, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_critDamage = res;
				else
					Debug.LogError("Failed To Convert _critDamage string: "+ __critDamage +" to int");
			}
			{
			float res;
				if(float.TryParse(__critChance, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_critChance = res;
				else
					Debug.LogError("Failed To Convert _critChance string: "+ __critChance +" to float");
			}
			_essence = __essence.Trim();
			_role = __role.Trim();
			{
			int res;
				if(int.TryParse(__health, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_health = res;
				else
					Debug.LogError("Failed To Convert _health string: "+ __health +" to int");
			}
			{
			int res;
				if(int.TryParse(__initiative, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_initiative = res;
				else
					Debug.LogError("Failed To Convert _initiative string: "+ __initiative +" to int");
			}
			{
			int res;
				if(int.TryParse(__experience, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_experience = res;
				else
					Debug.LogError("Failed To Convert _experience string: "+ __experience +" to int");
			}
			_skill_1 = __skill_1.Trim();
			_skill_2 = __skill_2.Trim();
			_skill_3 = __skill_3.Trim();
			_skill_4 = __skill_4.Trim();
			_characterModel = __characterModel.Trim();
		}

		public int Length { get { return 16; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _name.ToString();
					break;
				case 1:
					ret = _damageMin.ToString();
					break;
				case 2:
					ret = _damageMax.ToString();
					break;
				case 3:
					ret = _accuracy.ToString();
					break;
				case 4:
					ret = _critDamage.ToString();
					break;
				case 5:
					ret = _critChance.ToString();
					break;
				case 6:
					ret = _essence.ToString();
					break;
				case 7:
					ret = _role.ToString();
					break;
				case 8:
					ret = _health.ToString();
					break;
				case 9:
					ret = _initiative.ToString();
					break;
				case 10:
					ret = _experience.ToString();
					break;
				case 11:
					ret = _skill_1.ToString();
					break;
				case 12:
					ret = _skill_2.ToString();
					break;
				case 13:
					ret = _skill_3.ToString();
					break;
				case 14:
					ret = _skill_4.ToString();
					break;
				case 15:
					ret = _characterModel.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "name":
					ret = _name.ToString();
					break;
				case "damageMin":
					ret = _damageMin.ToString();
					break;
				case "damageMax":
					ret = _damageMax.ToString();
					break;
				case "accuracy":
					ret = _accuracy.ToString();
					break;
				case "critDamage":
					ret = _critDamage.ToString();
					break;
				case "critChance":
					ret = _critChance.ToString();
					break;
				case "essence":
					ret = _essence.ToString();
					break;
				case "role":
					ret = _role.ToString();
					break;
				case "health":
					ret = _health.ToString();
					break;
				case "initiative":
					ret = _initiative.ToString();
					break;
				case "experience":
					ret = _experience.ToString();
					break;
				case "skill_1":
					ret = _skill_1.ToString();
					break;
				case "skill_2":
					ret = _skill_2.ToString();
					break;
				case "skill_3":
					ret = _skill_3.ToString();
					break;
				case "skill_4":
					ret = _skill_4.ToString();
					break;
				case "characterModel":
					ret = _characterModel.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "name" + " : " + _name.ToString() + "} ";
			ret += "{" + "damageMin" + " : " + _damageMin.ToString() + "} ";
			ret += "{" + "damageMax" + " : " + _damageMax.ToString() + "} ";
			ret += "{" + "accuracy" + " : " + _accuracy.ToString() + "} ";
			ret += "{" + "critDamage" + " : " + _critDamage.ToString() + "} ";
			ret += "{" + "critChance" + " : " + _critChance.ToString() + "} ";
			ret += "{" + "essence" + " : " + _essence.ToString() + "} ";
			ret += "{" + "role" + " : " + _role.ToString() + "} ";
			ret += "{" + "health" + " : " + _health.ToString() + "} ";
			ret += "{" + "initiative" + " : " + _initiative.ToString() + "} ";
			ret += "{" + "experience" + " : " + _experience.ToString() + "} ";
			ret += "{" + "skill_1" + " : " + _skill_1.ToString() + "} ";
			ret += "{" + "skill_2" + " : " + _skill_2.ToString() + "} ";
			ret += "{" + "skill_3" + " : " + _skill_3.ToString() + "} ";
			ret += "{" + "skill_4" + " : " + _skill_4.ToString() + "} ";
			ret += "{" + "characterModel" + " : " + _characterModel.ToString() + "} ";
			return ret;
		}
	}
	public sealed class Characters : IGoogle2uDB
	{
		public enum rowIds {
			Warrior, Thief, Shaman, Marauder
		};
		public string [] rowNames = {
			"Warrior", "Thief", "Shaman", "Marauder"
		};
		public System.Collections.Generic.List<CharactersRow> Rows = new System.Collections.Generic.List<CharactersRow>();

		public static Characters Instance
		{
			get { return NestedCharacters.instance; }
		}

		private class NestedCharacters
		{
			static NestedCharacters() { }
			internal static readonly Characters instance = new Characters();
		}

		private Characters()
		{
			Rows.Add( new CharactersRow("Warrior", "Warrior", "8", "12", "70", "2", "5", "Hero", "Tank", "30", "10", "0", "Skill_ThorStrike", "Skill_BigScope", "Skill_WildStrike", "Skill_StunStrike", "Warrior_model"));
			Rows.Add( new CharactersRow("Thief", "Thief", "8", "10", "70", "2", "10", "Hero", "Damager", "25", "15", "0", "Skill_Grapner", "Skill_Bleed", "Skill_ThrowDagger", "Skill_DaggerStrike", "Thief_model"));
			Rows.Add( new CharactersRow("Shaman", "Shaman", "6", "8", "70", "2", "5", "Hero", "Support", "20", "10", "0", "Skill_Healing", "Skill_HealthDance", "Skill_PainfulAnalysis", "Skill_Vigor", "Shaman_model"));
			Rows.Add( new CharactersRow("Marauder", "Marauder", "8", "10", "70", "2", "5", "Enemy", "Tank", "20", "10", "0", "Skill_WildStrike", "Skill_BigScope", "Skill_ThrowDagger", "None", "Marauder_model"));
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public CharactersRow GetRow(rowIds in_RowID)
		{
			CharactersRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public CharactersRow GetRow(string in_RowString)
		{
			CharactersRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
