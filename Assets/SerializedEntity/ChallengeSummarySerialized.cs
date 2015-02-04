using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class ChallengeSummarySerialized : SerializedEntity {
	public static readonly string MOTOCAT = "MOTOCAT";
	public static readonly string BIRD = "BIRD";

	public static readonly string ETAPA1 = "ETAPA1";
	public static readonly string ETAPA2 = "ETAPA2";
	public static readonly string ETAPA3 = "ETAPA3";
	public static readonly string ETAPA4 = "ETAPA4";

	//Etapa1
	public static readonly string E1_A = "A";
	public static readonly string E1_B = "B";
	public static readonly string E1_C = "C";
	public static readonly string E1_D = "D";
	public static readonly string E1_E = "E";
	public static readonly string E1_F = "F";
	public static readonly string E1_G = "G";
	public static readonly string E1_H = "H";

	//Etapa2
	public static readonly string E2_I = "I";
	public static readonly string E2_J = "J";
	public static readonly string E2_K = "K";
	public static readonly string E2_L = "L";

	public static readonly string E2_C = "C";
	public static readonly string E2_D = "D";
	public static readonly string E2_E = "E";
	public static readonly string E2_F = "F";
	public static readonly string E2_G = "G";
	public static readonly string E2_H = "H";

	//Etapa3
	public static readonly string E3_D = "D";
	public static readonly string E3_E = "E";
	public static readonly string E3_F = "F";
	public static readonly string E3_G = "G";
	public static readonly string E3_H = "H";
	public static readonly string E3_L = "L";
	public static readonly string E3_M = "M";
	public static readonly string E3_N = "N";

	//Etapa4
	public static readonly string E4_G = "G";
	public static readonly string E4_H = "H";
	public static readonly string E4_M = "M";
	public static readonly string E4_N = "N";


	public int Asserts { get; set; }
	public float AssertsPercentage { get; set; }
	public string Etapa { get; set; }
	public string EtapaChallenge { get; set; }
	public string Minigame { get; set; }
	public SchoolSerialized SchoolSerialized { get; set; }
	public StudentSerialized StudentSerialized { get; set; }
	public int TimesPlayed { get; set; }
	public long TotalTime { get; set; }

	public ChallengeSummarySerialized () {}
	
	public ChallengeSummarySerialized (int asserts, float assertsPercentage, string etapa, string etapaChallenge, string minigame, SchoolSerialized schoolSerialized, StudentSerialized studentSerialized, int timesPlayed, long totalTime)
	{
		this.Asserts = asserts;
		this.AssertsPercentage = assertsPercentage;
		this.Etapa = etapa;
		this.EtapaChallenge = etapaChallenge;
		this.Minigame = minigame;
		this.SchoolSerialized = schoolSerialized;
		this.StudentSerialized = studentSerialized;
		this.TimesPlayed = timesPlayed;
		this.TotalTime = totalTime;
	}

	public ChallengeSummarySerialized (ChallengeSummary cs)
	{
		this.Asserts = cs.Asserts;
		this.AssertsPercentage = cs.AssertsPercentage;
		this.Etapa = cs.Etapa;
		this.EtapaChallenge = cs.EtapaChallenge;
		this.Minigame = cs.Minigame;
		this.TimesPlayed = cs.TimesPlayed;
		this.TotalTime = cs.TotalTime;

		if (cs.School != null){
			SchoolSerialized ss = new SchoolSerializedDAO ().LoadByObjectId (cs.School.ObjectId);
			if (ss != null) {
				this.SchoolSerialized = ss;
			} else {
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}

		if (cs.Student != null) {
			StudentSerialized ss = new StudentSerializedDAO ().LoadByObjectId (cs.Student.ObjectId);
			if (ss != null) {
				this.StudentSerialized = ss;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}
	}

	public override string ToString ()
	{
		return string.Format (base.ToString () + "[ChallengeSummarySerialized: Asserts={0}, AssertsPercentage={1}, Etapa={2}, EtapaChallenge={3}, Minigame={4}, TimesPlayed={5}, TotalTime={6}]", Asserts, AssertsPercentage, Etapa, EtapaChallenge, Minigame, TimesPlayed, TotalTime);
	}
	

}
