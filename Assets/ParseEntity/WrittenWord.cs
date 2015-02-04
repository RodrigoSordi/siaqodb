using UnityEngine;
using System.Collections;
using System;
using Parse;

[ParseClassName("WrittenWord")]
public class WrittenWord : ParseObject {
	
	[ParseFieldName("diagnosis_level")]
	public string DiagnosisLevel { 
		get { return GetProperty<string>("DiagnosisLevel");} 
		set { SetProperty<string>(value, "DiagnosisLevel");}
	}
	[ParseFieldName("expected")]
	public string Expected { 
		get { return GetProperty<string>("Expected");} 
		set { SetProperty<string>(value, "Expected");}
	}
	[ParseFieldName("gesture")]
	public string Gesture { 
		get { return GetProperty<string>("Gesture");} 
		set { SetProperty<string>(value, "Gesture");}
	}
	[ParseFieldName("input")]
	public string Input { 
		get { return GetProperty<string>("Input");}
		set { SetProperty<string>(value, "Input");}
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
	[ParseFieldName("student")]
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
	}
	[ParseFieldName("written_at")]
	public long WrittenAt { 
		get { return GetProperty<long>("WrittenAt");} 
		set { SetProperty<long>(value, "WrittenAt");}
	}
	
	public WrittenWord () {}
	
	public WrittenWord (ParseObject po) {
		this.ObjectId = po.ObjectId;
		
		if (po.ContainsKey ("diagnosis_level"))this.DiagnosisLevel = po.Get<string>("diagnosis_level");
		if (po.ContainsKey ("expected"))this.Expected = po.Get<string>("expected");
		if (po.ContainsKey ("gesture"))this.Gesture = po.Get<string>("gesture");
		if (po.ContainsKey ("input"))this.Input = po.Get<string>("input");
		if (po.ContainsKey ("written_at"))this.WrittenAt = po.Get<long>("written_at");

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
	
	public WrittenWord (string diagnosisLevel, string expected, string gesture, string input, School school, Student student, int writtenAt)
	{
		this.DiagnosisLevel = diagnosisLevel;
		this.Expected = expected;
		this.Gesture = gesture;
		this.Input = input;
		this.School = school;
		this.Student = student;
		this.WrittenAt = writtenAt;
	}

	public WrittenWord (WrittenWordSerialized wws) {
		if (wws != null) {
			this.ObjectId = wws.ObjectId;

			this.DiagnosisLevel = wws.DiagnosisLevel;
			this.Expected = wws.Expected;
			this.Gesture = wws.Gesture;
			this.Input = wws.Input;
			this.WrittenAt = wws.WrittenAt;

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
		return string.Format ("[WrittenWord: DiagnosisLevel={0}, Expected={1}, Gesture={2}, Input={3}, School={4}, Student={5}, WrittenAt={6}]", DiagnosisLevel , Expected, Gesture, Input, School, Student, WrittenAt);
	}
	
}
