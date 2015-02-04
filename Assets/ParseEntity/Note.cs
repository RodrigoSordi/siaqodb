using UnityEngine;
using System.Collections;
using System;
using Parse;

[ParseClassName("Note")]
public class Note : ParseObject {

	[ParseFieldName("note_text")]
	public string NoteText { 
		get { return GetProperty<string>("NoteText");} 
		set { SetProperty<string>(value, "NoteText");}
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
	[ParseFieldName("teacher")]
	public Teacher Teacher { 
		get { return GetProperty<Teacher> ("Teacher");} 
		set { 
			ParseObject.RegisterSubclass<Teacher>();
			Teacher teacher = ParseObject.CreateWithoutData<Teacher>(value.ObjectId);
			SetProperty<Teacher>(teacher, "Teacher");
			
			if(value.ObjectId == null){
				Debug.Log ("Relational objectId is null!");
			}
		}
	}
	[ParseFieldName("writtenAt")]
	public long WrittenAt { 
		get { return GetProperty<long>("WrittenAt");} 
		set { SetProperty<long>(value, "WrittenAt");}
	}

	public Note () {}

	public Note (ParseObject po)
	{
		this.ObjectId = po.ObjectId;

		if (po.ContainsKey("note_text"))this.NoteText = po.Get<string>("note_text");
		if (po.ContainsKey("writtenAt"))this.WrittenAt = po.Get<long>("writtenAt");


		if(po.ContainsKey("school")) {
			School s = new School();
			s.ObjectId = po.Get<ParseObject>("school").ObjectId;
			this.School = s;
		}
		

		if(po.ContainsKey("student")) {
			Student st = new Student();
			st.ObjectId = po.Get<ParseObject>("student").ObjectId;
			this.Student = st;
		}
		

		if(po.ContainsKey("teacher")) {
			Teacher t = new Teacher();
			t.ObjectId = po.Get<ParseObject>("teacher").ObjectId;
			this.Teacher = t;
		}
	}

	public Note (NoteSerialized ns) {
		this.NoteText = ns.NoteText;
		this.WrittenAt = ns.WrittenAt;

		School s = new School ();
		if (ns.SchoolSerialized != null)
			s.ObjectId = ns.SchoolSerialized.ObjectId;
		this.School = s;

		Teacher t = new Teacher ();
		if (ns.TeacherSerialized != null)
			t.ObjectId = ns.TeacherSerialized.ObjectId;
		this.Teacher = t;

		Student st = new Student ();
		if (ns.StudentSerialized != null)
			st.ObjectId = ns.StudentSerialized.ObjectId;
		this.Student = st;
	}

	public Note (string noteText, School school, Student student, Teacher teacher, long writtenAt)
	{
		this.NoteText = noteText;
		this.School = school;
		this.Student = student;
		this.Teacher = teacher;
		this.WrittenAt = writtenAt;
	}

	public override string ToString ()
	{
		return string.Format ("[Note: NoteText={0}, School={1}, Student={2}, Teacher={3}, WrittenAt={4}]", NoteText, School, Student, Teacher, WrittenAt);
	}
	
}
