using UnityEngine;
using System.Collections;
using System;
using Parse;

[ParseClassName("Student")]
public class Student : ParseObject {
	
	[ParseFieldName("birth_date")]
	public long BirthDate { 
		get { return GetProperty<long>("BirthDate");} 
		set { SetProperty<long>(value, "BirthDate");}
	}
	[ParseFieldName("buildings_count")]
	public long BuildingsCount { 
		get { return GetProperty<long>("BuildingsCount");} 
		set { SetProperty<long>(value, "BuildingsCount");}
	}
	[ParseFieldName("coins")]
	public long Coins { 
		get { return GetProperty<long>("Coins");} 
		set { SetProperty<long>(value, "Coins");}
	}
	[ParseFieldName("diagnosis_level")]
	public string DiagnosisLevel { 
		get { return GetProperty<string>("DiagnosisLevel");} 
		set { SetProperty<string>(value, "DiagnosisLevel");} 
	}
	[ParseFieldName("gender")]
	public string Gender { 
		get { return GetProperty<string>("Gender");} 
		set { SetProperty<string>(value, "Gender");}
	}
	[ParseFieldName("guardian")]
	public string Guardian { 
		get { return GetProperty<string>("Guardian");} 
		set { SetProperty<string>(value, "Guardian");}
	}
	[ParseFieldName("name")]
	public string Name { 
		get { return GetProperty<string>("Name");} 
		set { SetProperty<string>(value, "Name");}
	}
	[ParseFieldName("picture")]
	public ParseFile Picture { 
		get { return GetProperty<ParseFile>("Picture");} 
		set { SetProperty<ParseFile>(value, "Picture");}
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
	[ParseFieldName("studentgroup")]
	public StudentGroup StudentGroup { 
		get { return GetProperty<StudentGroup> ("StudentGroup");} 
		set { 
			ParseObject.RegisterSubclass<StudentGroup>();
			StudentGroup sg = ParseObject.CreateWithoutData<StudentGroup>(value.ObjectId);
			SetProperty<StudentGroup>(sg, "StudentGroup");
			
			if(value.ObjectId == null){
				Debug.Log ("Relational objectId is null!");
			}
		}
	}
	[ParseFieldName("last_name")]
	public string LastName { 
		get { return GetProperty<string>("LastName");} 
		set { SetProperty<string>(value, "LastName");}
	}
	
	public Student () {}
	
	public Student (ParseObject po)
	{
		this.ObjectId = po.ObjectId;
		
		if(po.ContainsKey("birth_date"))this.BirthDate = po.Get<long> ("birth_date");
		if(po.ContainsKey("buildings_count"))this.BuildingsCount = po.Get<long> ("buildings_count");
		if(po.ContainsKey("coins"))this.Coins = po.Get<long> ("coins");
		if(po.ContainsKey("diagnosis_level"))this.DiagnosisLevel = po.Get<string> ("diagnosis_level");
		if(po.ContainsKey("gender"))this.Gender = po.Get<string> ("gender");
		if(po.ContainsKey("guardian"))this.Guardian = po.Get<string> ("guardian");
		if(po.ContainsKey("name"))this.Name = po.Get<string> ("name");
		if(po.ContainsKey("last_name"))this.LastName = po.Get<string> ("last_name");

		if (po.ContainsKey("picture"))
			this.Picture = po.Get<ParseFile>("picture");

		if(po.ContainsKey("school")) {
			School s = new School();
			s.ObjectId = po.Get<ParseObject>("school").ObjectId;
			this.School = s;
		}

		if(po.ContainsKey("studentgroup")) {
			StudentGroup sg = new StudentGroup();
			sg.ObjectId = po.Get<ParseObject>("studentgroup").ObjectId;
			this.StudentGroup = sg;
		}
	}
	
	public Student (long birthDate, long buildingsCount, long coins, string diagnosisLevel, string gender, string guardian, string name, School school, StudentGroup studentGroup, string lastName)
	{
		this.BirthDate = birthDate;
		this.BuildingsCount = buildingsCount;
		this.Coins = coins;
		this.DiagnosisLevel = diagnosisLevel;
		this.Gender = gender;
		this.Guardian = guardian;
		this.Name = name;
		this.School = school;
		this.StudentGroup = studentGroup;
		this.LastName = lastName;
	}

	public Student (StudentSerialized ss) {
		if (ss != null) {
			this.ObjectId = ss.ObjectId;

			this.BirthDate = ss.BirthDate;
			this.BuildingsCount = ss.BuildingsCount;
			this.Coins = ss.Coins;
			this.DiagnosisLevel = ss.DiagnosisLevel;
			this.Gender = ss.Gender;
			this.Guardian = ss.Guardian;
			this.Name = ss.Name;
			this.LastName = ss.LastName;

			School s = new School ();
			if (ss.SchoolSerialized  != null)
				s.ObjectId = ss.SchoolSerialized.ObjectId;
			this.School = s;

			StudentGroup sg = new StudentGroup ();
			if (ss.StudentGroupSerialized != null)
				sg.ObjectId = ss.StudentGroupSerialized.ObjectId;
			this.StudentGroup = sg;

			if (ss.Picture != null) {
				byte[] data = ss.Picture;
				this.Picture = new ParseFile("photo.jpg", data);
			}
		}
	}
	
	public override string ToString ()
	{
		return string.Format ("[Student: BirthDate={0}, BuildingsCount={1}, Coins={2}, DiagnosisLevel={3}, Gender={4}, Guardian={5}, Name={6}, School={7}, StudentGroup={8}, LastName={9}]", BirthDate, BuildingsCount, Coins, DiagnosisLevel, Gender, Guardian, Name, School, StudentGroup, LastName);
	}
	
}
