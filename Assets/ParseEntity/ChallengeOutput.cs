using UnityEngine;
using System.Collections;
using System;
using Parse;

[ParseClassName("ChallengeOutput")]
public class ChallengeOutput : ParseObject {

	[ParseFieldName("asserts")]
	public int Asserts { 
		get { return GetProperty<int>("Asserts");} 
		set { SetProperty<int>(value, "Asserts");}
	}
	[ParseFieldName("asserts_percentage")]
	public long AssertsPercentage { 
		get { return GetProperty<long>("AssertsPercentage");} 
		set { SetProperty<long>(value, "AssertsPercentage");}
	}
	[ParseFieldName("challenge_excercise")]
	public string ChallengeExercise { 
		get { return GetProperty<string>("ChallengeExercise");} 
		set { SetProperty<string>(value, "ChallengeExercise");}
	}
	[ParseFieldName("duration")]
	public long Duration { 
		get { return GetProperty<long>("Duration");} 
		set { SetProperty<long>(value, "Duration");}
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
	[ParseFieldName("summarized")]
	public bool Summarized { 
		get { return GetProperty<bool>("Summarized");} 
		set { SetProperty<bool>(value, "Summarized");}
	}
	[ParseFieldName("timestamp")]
	public DateTime Timestamp { 
		get { return GetProperty<DateTime>("Timestamp");} 
		set { SetProperty<DateTime>(value, "Timestamp");}
	}
	[ParseFieldName("week_summarized")]
	public bool WeekSummarized { 
		get { return GetProperty<bool>("WeekSummarized");} 
		set { SetProperty<bool>(value, "WeekSummarized");}
	}

	public ChallengeOutput () {}

	public ChallengeOutput (ParseObject po) {
		this.ObjectId = po.ObjectId;

		if (po.ContainsKey("asserts"))this.Asserts = po.Get<int>("asserts");
		if (po.ContainsKey("asserts_percentage"))this.AssertsPercentage = po.Get<long>("asserts_percentage");
		if (po.ContainsKey("challenge_excercise"))this.ChallengeExercise = po.Get<string>("challenge_excercise");
		if (po.ContainsKey("duration"))this.Duration = po.Get<long>("duration");
		if (po.ContainsKey("etapa"))this.Etapa = po.Get<string>("etapa");
		if (po.ContainsKey("etapa_challenge"))this.EtapaChallenge = po.Get<string>("etapa_challenge");
		if (po.ContainsKey("minigame"))this.Minigame = po.Get<string>("minigame");
		//School
		//Student
		if (po.ContainsKey("summarized"))this.Summarized = po.Get<bool>("summarized");
		if (po.ContainsKey("timestamp"))this.Timestamp = po.Get<DateTime>("timestamp");
		if (po.ContainsKey("week_summarized"))this.WeekSummarized = po.Get<bool>("week_summarized");

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

	public ChallengeOutput (int asserts, long assertsPercentage, string challengeExercise, long duration, string etapa, string etapaChallenge, string minigame, School school, Student student, bool summarized, DateTime timestamp, bool weekSummarized)
	{
		this.Asserts = asserts;
		this.AssertsPercentage = assertsPercentage;
		this.ChallengeExercise = challengeExercise;
		this.Duration = duration;
		this.Etapa = etapa;
		this.EtapaChallenge = etapaChallenge;
		this.Minigame = minigame;
		this.School = school;
		this.Student = student;
		this.Summarized = summarized;
		this.Timestamp = timestamp;
		this.WeekSummarized = weekSummarized;
	}

	public ChallengeOutput (ChallengeOutputSerialized cos) {
		this.Asserts = cos.Asserts;
		this.AssertsPercentage = cos.AssertsPercentage;
		this.ChallengeExercise = cos.ChallengeExcercise;
		this.Duration = cos.Duration;
		this.Etapa = cos.Etapa;
		this.EtapaChallenge = cos.EtapaChallenge;
		this.Minigame = cos.Minigame;
		this.Summarized = cos.Summarized;
		this.Timestamp = cos.Timestamp;
		this.WeekSummarized = cos.WeekSummarized;
		
		School s = new School ();
		if (cos.SchoolSerialized != null)
			s.ObjectId = cos.SchoolSerialized.ObjectId;
		this.School = s;
		
		Student st = new Student ();
		if (cos.StudentSerialized != null)
			st.ObjectId = cos.StudentSerialized.ObjectId;
		this.Student = st;
	}

	public override string ToString ()
	{
		return string.Format ("[ChallengeOutput: Asserts={0}, AssertsPercentage={1}, ChallengeExercise={2}, Duration={3}, Etapa={4}, EtapaChallenge={5}, Minigame={6}, School={7}, Student={8}, Summarized={9}, Timestamp={10}, WeekSummarized={11}]", Asserts, AssertsPercentage, ChallengeExercise, Duration, Etapa, EtapaChallenge, Minigame, School, Student, Summarized, Timestamp, WeekSummarized);
	}
	
}
