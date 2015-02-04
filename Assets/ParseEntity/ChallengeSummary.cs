using UnityEngine;
using System.Collections;
using System;
using Parse;

[ParseClassName("ChallengeSummary")]
public class ChallengeSummary : ParseObject {

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

	public ChallengeSummary () {}

	public ChallengeSummary (ParseObject po){
		this.ObjectId = po.ObjectId;

		if (po.ContainsKey("asserts"))this.Asserts = po.Get<int>("asserts");
		if (po.ContainsKey("asserts_percentage"))this.AssertsPercentage = po.Get<float>("asserts_percentage");
		if (po.ContainsKey("etapa"))this.Etapa = po.Get<string>("etapa");
		if (po.ContainsKey("etapa_challenge"))this.EtapaChallenge = po.Get<string>("etapa_challenge");
		if (po.ContainsKey("minigame"))this.Minigame = po.Get<string>("minigame");
		//School
		//Student
		if (po.ContainsKey("times_played"))this.TimesPlayed = po.Get<int>("times_played");
		if (po.ContainsKey("total_time"))this.TotalTime = po.Get<long>("total_time");

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

	public ChallengeSummary (ChallengeSummarySerialized css) {
		this.Asserts = css.Asserts;
		this.AssertsPercentage = css.AssertsPercentage;
		this.Etapa = css.Etapa;
		this.EtapaChallenge = css.EtapaChallenge;
		this.Minigame = css.Minigame;
		this.TimesPlayed = css.TimesPlayed;
		this.TotalTime = css.TotalTime;

		School s = new School ();
		if (css.SchoolSerialized != null)
			s.ObjectId = css.SchoolSerialized.ObjectId;
		this.School = s;
		
		Student st = new Student ();
		if (css.StudentSerialized != null)
			st.ObjectId = css.StudentSerialized.ObjectId;
		this.Student = st;
	}

	public ChallengeSummary (int asserts, float assertsPercentage, string etapa, string etapaChallenge, string minigame, School school, Student student, int timesPlayed, long totalTime)
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
	}
	

	public override string ToString ()
	{
		return string.Format ("[ChallengeSummary: Asserts={0}, AssertsPercentage={1}, Etapa={2}, EtapaChallenge={3}, Minigame={4}, School={5}, Student={6}, TimesPlayed={7}, TotalTime={8}]", Asserts, AssertsPercentage, Etapa, EtapaChallenge, Minigame, School, Student, TimesPlayed, TotalTime);
	}
	
}
