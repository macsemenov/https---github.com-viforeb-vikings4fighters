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
	public class SkillsRow : IGoogle2uRow
	{
		public string _name;
		public float _damageModifier;
		public float _accuracyModifier;
		public float _critDamageModifier;
		public float _critChanceModifier;
		public System.Collections.Generic.List<bool> _canUse_positions = new System.Collections.Generic.List<bool>();
		public System.Collections.Generic.List<bool> _canHit_positions = new System.Collections.Generic.List<bool>();
		public string _addEffect;
		public string _myTargets;
		public int _targetsQuantity;
		public SkillsRow(string __ID, string __name, string __damageModifier, string __accuracyModifier, string __critDamageModifier, string __critChanceModifier, string __canUse_positions, string __canHit_positions, string __addEffect, string __myTargets, string __targetsQuantity) 
		{
			_name = __name.Trim();
			{
			float res;
				if(float.TryParse(__damageModifier, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_damageModifier = res;
				else
					Debug.LogError("Failed To Convert _damageModifier string: "+ __damageModifier +" to float");
			}
			{
			float res;
				if(float.TryParse(__accuracyModifier, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_accuracyModifier = res;
				else
					Debug.LogError("Failed To Convert _accuracyModifier string: "+ __accuracyModifier +" to float");
			}
			{
			float res;
				if(float.TryParse(__critDamageModifier, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_critDamageModifier = res;
				else
					Debug.LogError("Failed To Convert _critDamageModifier string: "+ __critDamageModifier +" to float");
			}
			{
			float res;
				if(float.TryParse(__critChanceModifier, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_critChanceModifier = res;
				else
					Debug.LogError("Failed To Convert _critChanceModifier string: "+ __critChanceModifier +" to float");
			}
			{
				bool res;
				string []result = __canUse_positions.Split("|".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					if(bool.TryParse(result[i], out res))
						_canUse_positions.Add(res);
					else
					{
						_canUse_positions.Add( false );
						Debug.LogError("Failed To Convert _canUse_positions string: "+ result[i] +" to bool");
					}
				}
			}
			{
				bool res;
				string []result = __canHit_positions.Split("|".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					if(bool.TryParse(result[i], out res))
						_canHit_positions.Add(res);
					else
					{
						_canHit_positions.Add( false );
						Debug.LogError("Failed To Convert _canHit_positions string: "+ result[i] +" to bool");
					}
				}
			}
			_addEffect = __addEffect.Trim();
			_myTargets = __myTargets.Trim();
			{
			int res;
				if(int.TryParse(__targetsQuantity, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_targetsQuantity = res;
				else
					Debug.LogError("Failed To Convert _targetsQuantity string: "+ __targetsQuantity +" to int");
			}
		}

		public int Length { get { return 10; } }

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
					ret = _damageModifier.ToString();
					break;
				case 2:
					ret = _accuracyModifier.ToString();
					break;
				case 3:
					ret = _critDamageModifier.ToString();
					break;
				case 4:
					ret = _critChanceModifier.ToString();
					break;
				case 5:
					ret = _canUse_positions.ToString();
					break;
				case 6:
					ret = _canHit_positions.ToString();
					break;
				case 7:
					ret = _addEffect.ToString();
					break;
				case 8:
					ret = _myTargets.ToString();
					break;
				case 9:
					ret = _targetsQuantity.ToString();
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
				case "damageModifier":
					ret = _damageModifier.ToString();
					break;
				case "accuracyModifier":
					ret = _accuracyModifier.ToString();
					break;
				case "critDamageModifier":
					ret = _critDamageModifier.ToString();
					break;
				case "critChanceModifier":
					ret = _critChanceModifier.ToString();
					break;
				case "canUse_positions":
					ret = _canUse_positions.ToString();
					break;
				case "canHit_positions":
					ret = _canHit_positions.ToString();
					break;
				case "addEffect":
					ret = _addEffect.ToString();
					break;
				case "myTargets":
					ret = _myTargets.ToString();
					break;
				case "targetsQuantity":
					ret = _targetsQuantity.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "name" + " : " + _name.ToString() + "} ";
			ret += "{" + "damageModifier" + " : " + _damageModifier.ToString() + "} ";
			ret += "{" + "accuracyModifier" + " : " + _accuracyModifier.ToString() + "} ";
			ret += "{" + "critDamageModifier" + " : " + _critDamageModifier.ToString() + "} ";
			ret += "{" + "critChanceModifier" + " : " + _critChanceModifier.ToString() + "} ";
			ret += "{" + "canUse_positions" + " : " + _canUse_positions.ToString() + "} ";
			ret += "{" + "canHit_positions" + " : " + _canHit_positions.ToString() + "} ";
			ret += "{" + "addEffect" + " : " + _addEffect.ToString() + "} ";
			ret += "{" + "myTargets" + " : " + _myTargets.ToString() + "} ";
			ret += "{" + "targetsQuantity" + " : " + _targetsQuantity.ToString() + "} ";
			return ret;
		}
	}
	public sealed class Skills : IGoogle2uDB
	{
		public enum rowIds {
			None, Skill_ThorStrike, Skill_BigScope, Skill_Bleed, Skill_DaggerStrike, Skill_Grapner, Skill_Healing, Skill_HealthDance, Skill_PainfulAnalysis, Skill_StunStrike, Skill_ThrowDagger, Skill_Vigor, Skill_WildStrike
		};
		public string [] rowNames = {
			"None", "Skill_ThorStrike", "Skill_BigScope", "Skill_Bleed", "Skill_DaggerStrike", "Skill_Grapner", "Skill_Healing", "Skill_HealthDance", "Skill_PainfulAnalysis", "Skill_StunStrike", "Skill_ThrowDagger", "Skill_Vigor", "Skill_WildStrike"
		};
		public System.Collections.Generic.List<SkillsRow> Rows = new System.Collections.Generic.List<SkillsRow>();

		public static Skills Instance
		{
			get { return NestedSkills.instance; }
		}

		private class NestedSkills
		{
			static NestedSkills() { }
			internal static readonly Skills instance = new Skills();
		}

		private Skills()
		{
			Rows.Add( new SkillsRow("None", "", "0", "0", "0", "0", "", "", "", "", "0"));
			Rows.Add( new SkillsRow("Skill_ThorStrike", "Thor Strike", "0,25", "100", "1", "0", "False | False | False | True", "True| True | True | True", "None", "Enemies", "4"));
			Rows.Add( new SkillsRow("Skill_BigScope", "Big Scope", "0,50", "0", "1", "0", "False | False | True | True", "True| True | False | False ", "None", "Enemies", "2"));
			Rows.Add( new SkillsRow("Skill_Bleed", "Bleed", "0.4", "0", "1", "0", "False | True | True | True", "True| True | True | False ", "Bleed", "Enemies", "1"));
			Rows.Add( new SkillsRow("Skill_DaggerStrike", "Dagger Strike", "1,00", "0", "1", "10", "False | False | False | True", "True| True | True | False ", "None", "Enemies", "1"));
			Rows.Add( new SkillsRow("Skill_Grapner", "Grapner", "0,00", "0", "1", "0", "True | True | True | True", "True| True | True | True", "Grapnel", "Enemies", "1"));
			Rows.Add( new SkillsRow("Skill_Healing", "Healing", "1,00", "100", "1", "2", "True | True | True | False", "True| True | True | True", "None", "Friends", "1"));
			Rows.Add( new SkillsRow("Skill_HealthDance", "Health Dance", "1,50", "100", "1", "5", "True | True | True | True", "True| True | True | True", "None", "Myself", "1"));
			Rows.Add( new SkillsRow("Skill_PainfulAnalysis", "Painful Analysis", "0,85", "0", "1", "0", "False | False | False | True", "True| True | False | False ", "None", "Enemies", "1"));
			Rows.Add( new SkillsRow("Skill_StunStrike", "Stun Strike", "0,00", "0", "1", "0", "False | False | False | True", "True| True | False | False ", "Stun", "Enemies", "1"));
			Rows.Add( new SkillsRow("Skill_ThrowDagger", "Throw Dagger", "0,90", "0", "1", "0", "True | True | False | False ", "False | False | False | True", "None", "Enemies", "1"));
			Rows.Add( new SkillsRow("Skill_Vigor", "Vigor", "0,40", "0", "1", "2", "True | True | False | False ", "True | True | True | True", "Vigor", "Friends", "1"));
			Rows.Add( new SkillsRow("Skill_WildStrike", "Wild Strike", "0,20", "0", "1", "5", "False | False | True | True", "True | True | False | False ", "None", "Enemies", "1"));
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
		public SkillsRow GetRow(rowIds in_RowID)
		{
			SkillsRow ret = null;
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
		public SkillsRow GetRow(string in_RowString)
		{
			SkillsRow ret = null;
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
