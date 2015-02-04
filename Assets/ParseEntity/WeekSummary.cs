using UnityEngine;
using System.Collections;
using System;
using Parse;

[ParseClassName("WeekSummary")]
public class WeekSummary : ParseObject {

	[ParseFieldName("asserts")]
	public int Asserts { 
		get { return GetProperty<int>("Asserts");} 
		set { SetProperty<int>(value, "Asserts");}
	}
	[ParseFieldName("asserts_percentage")]
	public float AssertsPercentage { 
		get { return GetProperty<float>("AssertsPercentage");} 
		set { SetProperty<float>(value, "AssertsPercentage");}
	}
	[ParseFieldName("etapa")]
	public string Etapa { 
		get { return GetProperty<string>("Etapa");} 
		set { SetProperty<string>(value, "Etapa");}
	}
	[ParseFieldName("etapa_challenge")]
	public string EtapaChallenge { 
		get { return GetProperty<string>("EtapaChallenge");} 
		set { SetProperty<string>(value, "EtapaChallenge");}
	}
	[ParseFieldName("minigame")]
	public string Minigame { 
		get { return GetProperty<string>("Minigame");} 
		set { SetProperty<string>(value, "Minigame");}
	}
	[ParseFieldName("school")]
	public School School { 
		get { return GetProperty<School> ("School");} 
		set { 
			ParseObject.RegisterSubclass<School>();
			School school = ParseObject.CreateWithoutData<School>(value.ObjectId);
			SetProperty<School>(school, "School");
			
			if(value.ObjectId == null){
				Debug.Log ("Relational objectId is null!");
			}
		}
	}
	[ParseFieldName("student")]
	public Student Student { 
		get { return GetProperty<Student> ("Student");} 
		set { 
			ParseObject.RegisterSubclass<Student>();
			Student student = ParseObject.CreateWithoutData<Student>(value.ObjectId);
			SetProperty<Student>(student, "Student");
			
			if(value.ObjectId == null){
				Debug.Log ("Relational objectId is null!");
			}
		}
	}
	[ParseFieldName("times_played")]
	public int TimesPlayed { 
		get { return GetProperty<int>("TimesPlayed");} 
		set { SetProperty<int>(value, "TimesPlayed");}
	}
	[ParseFieldName("total_time")]
	public long TotalTime { 
		get { return GetProperty<long>("TotalTime");} 
		set { SetProperty<long>(value, "TotalTime");}
	}
	[ParseFieldName("week")]
	public long Week { 
		get { return GetProperty<long>("Week");} 
		set { SetProperty<long>(value, "Week");}
	}

	public WeekSummary () {}

	public WeekSummary (ParseObject po)
	{
		this.ObjectId = po.ObjectId;

		if (po.ContainsKey ("asserts")) this.Asserts = po.Get<int>("asserts");
		if (po.ContainsKey ("asserts_percentage")) this.AssertsPercentage = po.Get<float>("asserts_percentage");
		if (po.ContainsKey ("etapa")) this.Etapa = po.Get<string>("etapa");
		if (po.ContainsKey ("etapa_challenge")) this.EtapaChallenge = po.Get<string>("etapa_challenge");
		if (po.ContainsKey ("minigame")) this.Minigame = po.Get<string>("minigame");
		//School
		//Student
		if (po.ContainsKey ("times_played")) this.TimesPlayed = po.Get<int>("times_played");
		if (po.ContainsKey ("times_played")) this.TotalTime = po.Get<long>("times_played");
		if (po.ContainsKey ("week")) this.Week = po.Get<long>("week");

		if(po.ContainsKey("school")){
			School s = new School();
			s.ObjectId = po.Get<ParseObject>("school").ObjectId;
			this.School = s;
		}
			
		if(po.ContainsKey("student")){
			Student s = new Student();
			s.ObjectId = po.Get<ParseObject>("student").ObjectId;
			this.Student = s;
		}
	}

	public WeekSummary (int asserts, float assertsPercentage, string etapa, string etapaChallenge, string minigame, School school, Student student, int timesPlayed, long totalTime, long week)
	{
		this.Asserts = asserts;
		this.AssertsPercentage = assertsPercentage;
		this.Etapa = etapa;
		this.EtapaChallenge = etapaChallenge;
		this.Minigame = minigame;
		this.School = school;
		this.Student = student;
		this.TimesPlayed = timesPlayed;
		this.TotalTime = totalTime;
		this.Week = week;
	}

	public WeekSummary (WeekSummarySerialized wws) {
		if (wws != null) {
			this.ObjectId = wws.ObjectId;

			this.Asserts = wws.Asserts;
			this.AssertsPercentage = wws.AssertsPercentage;
			this.Etapa = wws.Etapa;
			this.EtapaChallenge = wws.EtapaChallenge;
			this.Minigame = wws.Minigame;
			this.TimesPlayed = wws.TimesPlayed;
			this.TotalTime = wws.TotalTime;
			this.Week = wws.Week;

			School school = new School ();
			if (wws.SchoolSerialized != null)
				school.ObjectId = wws.SchoolSerialized.ObjectId;
			this.School = school;
			
			Student student = new Student ();
			if (wws.StudentSerialized != null)
				student.ObjectId = wws.StudentSerialized.ObjectId;
			this.Student = student;
		}
	}

	public override string ToString ()
	{
		return string.Format ("[WeekSummary: Asserts={0}, AssertsPercentage={1}, Etapa={2}, EtapaChallenge={3}, Minigame={4}, School={5}, Student={6}, TimesPlayed={7}, TotalTime={8}, Week={9}]", Asserts, AssertsPercentage, Etapa, EtapaChallenge, Minigame, School, Student, TimesPlayed, TotalTime, Week);
	}
	
}
