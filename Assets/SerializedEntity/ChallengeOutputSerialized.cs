using UnityEngine;
using System.Collections;
using System;

public class ChallengeOutputSerialized : SerializedEntity {

	public static readonly string ETAPA1 = "ETAPA1";
	public static readonly string ETAPA2 = "ETAPA2";
	public static readonly string ETAPA3 = "ETAPA3";
	public static readonly string ETAPA4 = "ETAPA4";

	public int Asserts { get; set; }
	public long AssertsPercentage { get; set; }
	public string ChallengeExcercise { get; set; }
	public long Duration { get; set; }
	public string Etapa { get; set; }
	public string EtapaChallenge { get; set; }
	public string Minigame { get; set; }
	public SchoolSerialized SchoolSerialized { get; set; }
	public StudentSerialized StudentSerialized { get; set; }
	public bool Summarized { get; set; }
	public DateTime Timestamp { get; set; }
	public bool WeekSummarized { get; set; }

	public ChallengeOutputSerialized () {}
	
	public ChallengeOutputSerialized (int asserts, long assertsPercentage, string challengeExcercise, long duration, string etapa, string etapaChallenge, string minigame, SchoolSerialized schoolSerialized, StudentSerialized studentSerialized, bool summarized, DateTime timestamp, bool weekSummarized)
	{
		this.Asserts = asserts;
		this.AssertsPercentage = assertsPercentage;
		this.ChallengeExcercise = challengeExcercise;
		this.Duration = duration;
		this.Etapa = etapa;
		this.EtapaChallenge = etapaChallenge;
		this.Minigame = minigame;
		this.SchoolSerialized = schoolSerialized;
		this.StudentSerialized = studentSerialized;
		this.Summarized = summarized;
		this.Timestamp = timestamp;
		this.WeekSummarized = weekSummarized;
	}

	public ChallengeOutputSerialized (ChallengeOutput co)
	{
		this.Asserts = co.Asserts;
		this.AssertsPercentage = co.AssertsPercentage;
		this.ChallengeExcercise = co.ChallengeExercise;
		this.Duration = co.Duration;
		this.Etapa = co.Etapa;
		this.EtapaChallenge = co.EtapaChallenge;
		this.Minigame = co.Minigame;
		this.Summarized = co.Summarized;
		this.Timestamp = co.Timestamp;
		this.WeekSummarized = co.WeekSummarized;

		if (co.School != null){
			SchoolSerialized ss = new SchoolSerializedDAO ().LoadByObjectId (co.School.ObjectId);
			if (ss != null) {
				this.SchoolSerialized = ss;
			} else {
//				Debug.Log ("Serialized: There is no relationship saved");
			}
		}

		if (co.Student != null) {
			StudentSerialized ss = new StudentSerializedDAO ().LoadByObjectId (co.Student.ObjectId);
			if (ss != null) {
				this.StudentSerialized = ss;
			} else {
//				Debug.Log ("Serialized: There is no relationship saved");
			}
		}
	}

	public override string ToString ()
	{
		return string.Format (base.ToString () + "[ChallengeOutputSerialized: Asserts={0}, AssertsPercentage={1}, ChallengeExcercise={2}, Duration={3}, Etapa={4}, EtapaChallenge={5}, Minigame={6}, Summarized={7}, Timestamp={8}, WeekSummarized={9}]", Asserts, AssertsPercentage, ChallengeExcercise, Duration, Etapa, EtapaChallenge, Minigame, Summarized, Timestamp, WeekSummarized);
	}
	
	
}
