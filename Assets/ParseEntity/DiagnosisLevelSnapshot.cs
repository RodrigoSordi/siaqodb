using UnityEngine;
using System.Collections;
using System;
using Parse;

[ParseClassName("DiagnosisLevelSnapshot")]
public class DiagnosisLevelSnapshot : ParseObject {
	
	[ParseFieldName("diagnosis_level")]
	public string DiagnosisLevel { 
		get { return GetProperty<string>("DiagnosisLevel");} 
		set { SetProperty<string>(value, "DiagnosisLevel");}
	}
	[ParseFieldName("school")]
	public School School { 
		get { return GetProperty<School> ("School");} 
		set { 
			if (value != null) {
				ParseObject.RegisterSubclass<School>();
				School school = ParseObject.CreateWithoutData<School>(value.ObjectId);
				SetProperty<School>(school, "School");
			}else{
				Debug.Log ("Relational objectId is null!");
			}
		}
	}
	[ParseFieldName("start_time")]
	public long StartTime { 
		get { return GetProperty<long>("StartTime");} 
		set { SetProperty<long>(value, "StartTime");} 
	}
	//This column was made wrong in data base
	[ParseFieldName("student")]
	public DiagnosisLevelSnapshot Student { 
		get { return GetProperty<DiagnosisLevelSnapshot> ("Student");} 
		set { 
			if (value != null) {
				ParseObject.RegisterSubclass<DiagnosisLevelSnapshot>();
				DiagnosisLevelSnapshot dls = ParseObject.CreateWithoutData<DiagnosisLevelSnapshot>(value.ObjectId);
				SetProperty<DiagnosisLevelSnapshot>(dls, "Student");
			}else{
				SetProperty<DiagnosisLevelSnapshot>(null, "Student");
				Debug.Log ("Relational objectId is null!");
			}
		}
	}
	//This will correct the wrong column
	/*[ParseFieldName("student_correct")]
	public Student Student {
		get { return GetProperty<Student> ("Student");} 
		set { 
			if (value != null) {
				ParseObject.RegisterSubclass<Student>();
				Student student = ParseObject.CreateWithoutData<Student>(value.ObjectId);
				SetProperty<Student>(student, "Student");
			}else{
				Debug.Log ("Relational objectId is null!");
			}
		}
	}*/
	
	public DiagnosisLevelSnapshot () {}
	
	public DiagnosisLevelSnapshot (ParseObject po) {
		this.ObjectId = po.ObjectId;

		if (po.ContainsKey ("diagnosis_level"))this.DiagnosisLevel = po.Get<string>("diagnosis_level");
		if (po.ContainsKey ("start_time"))this.StartTime = po.Get<long>("start_time");
		
		if(po.ContainsKey("school")){
			School s = new School();
			s.ObjectId = po.Get<ParseObject>("school").ObjectId;
			this.School = s;
		}
		
		if(po.ContainsKey("student")){
			DiagnosisLevelSnapshot dls = new DiagnosisLevelSnapshot();
			dls.ObjectId = po.Get<ParseObject>("student").ObjectId;
			this.Student = dls;
		}
			
			/*if(po.ContainsKey("student_correct")){
				Student s = new Student();
				s.ObjectId = po.Get<ParseObject>("student_correct").ObjectId;
				this.Student = s;
			}*/
	}
	
	public DiagnosisLevelSnapshot (string diagnosisLevel, School school, long startTime, Student student)
	{
		this.DiagnosisLevel = diagnosisLevel;
		this.School = school;
		this.StartTime = startTime;
		//this.Student = student;
	}

	public DiagnosisLevelSnapshot (DiagnosisLevelSnapshotSerialized dlss) {
		if (dlss != null) {
			this.ObjectId = dlss.ObjectId;

			this.DiagnosisLevel = dlss.DiagnosisLevel;
			this.StartTime = dlss.StartTime;

			School school = new School ();
			if (dlss.SchoolSerialized != null) 
				school.ObjectId = dlss.SchoolSerialized.ObjectId;
			this.School = school;

			DiagnosisLevelSnapshot student = new DiagnosisLevelSnapshot ();
			if (dlss.StudentSerialized != null) 
				student.ObjectId = dlss.StudentSerialized.ObjectId;
			this.Student = student;
		}
	}
	
	public override string ToString ()
	{
		return string.Format ("[DiagnosisLevelSnapshot: DiagnosisLevel={0}, School={1}, StartTime={2}, Student={3}]", DiagnosisLevel, School, StartTime, Student);
	}
	
}
