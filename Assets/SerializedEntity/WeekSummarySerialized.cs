using UnityEngine;
using System.Collections;
using System;

public class WeekSummarySerialized : SerializedEntity {

	public int Asserts { get; set; }
	public float AssertsPercentage { get; set; }
	public string Etapa { get; set; }
	public string EtapaChallenge { get; set; }
	public string Minigame { get; set; }
	public SchoolSerialized SchoolSerialized { get; set; }
	public StudentSerialized StudentSerialized { get; set; }
	public int TimesPlayed { get; set; }
	public long TotalTime { get; set; }
	public long Week { get; set; }

	public WeekSummarySerialized () {}

	public WeekSummarySerialized (int asserts, float assertsPercentage, string etapa, string etapaChallenge, string minigame, SchoolSerialized schoolSerialized, StudentSerialized studentSerialized, int timesPlayed, long totalTime, long week)
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
		this.Week = week;
	}
	
	public WeekSummarySerialized (WeekSummary ws)
	{
		this.Asserts = ws.Asserts;
		this.AssertsPercentage = ws.AssertsPercentage;
		this.Etapa = ws.Etapa;
		this.EtapaChallenge = ws.EtapaChallenge;
		this.Minigame = ws.Minigame;
		this.TimesPlayed = ws.TimesPlayed;
		this.TotalTime = ws.TotalTime;
		this.Week = ws.Week;

		if (ws.School != null){
			SchoolSerialized ss = new SchoolSerializedDAO ().LoadByObjectId (ws.School.ObjectId);
			if (ss != null){
				this.SchoolSerialized = ss;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}
		
		if (ws.Student != null) {
			StudentSerialized ss = new StudentSerializedDAO ().LoadByObjectId (ws.Student.ObjectId);
			if (ss != null){
				this.StudentSerialized = ss;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}
	}
	
	public override string ToString ()
	{
		return string.Format ("[WeekSummarySerialized: Asserts={0}, AssertsPercentage={1}, Etapa={2}, EtapaChallenge={3}, Minigame={4}, SchoolSerialized={5}, StudentSerialized={6}, TimesPlayed={7}, TotalTime={8}, Week={9}]", Asserts, AssertsPercentage, Etapa, EtapaChallenge, Minigame, SchoolSerialized, StudentSerialized, TimesPlayed, TotalTime, Week);
	}
	

}
