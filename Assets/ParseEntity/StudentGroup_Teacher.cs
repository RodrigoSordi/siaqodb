using UnityEngine;
using System.Collections;
using System;
using Parse;

[ParseClassName("studentgroup_teacher")]
public class studentgroup_teacher : ParseObject {
	
	/*[ParseFieldName("deletedAt")]
	public DateTime DeletedAt { 
		get { return GetProperty<DateTime>("DeletedAt");} 
		set { SetProperty<DateTime>(value, "DeletedAt");}
	}*/
	[ParseFieldName("school")]
	public School School { 
		get { return GetProperty<School> ("School");} 
		set { 
			ParseObject.RegisterSubclass<School>();
			School school = ParseObject.CreateWithoutData<School>(value.ObjectId);
			SetProperty<School>(school, "School");
			
			if(value.ObjectId == null){
				Debug.Log ("studentGroup_teacher.school is null!");
			}
		}
	}
	[ParseFieldName("student_group")]
	public StudentGroup StudentGroup { 
		get { return GetProperty<StudentGroup> ("StudentGroup");} 
		set { 
			ParseObject.RegisterSubclass<StudentGroup>();
			StudentGroup sg = ParseObject.CreateWithoutData<StudentGroup>(value.ObjectId);
			SetProperty<StudentGroup>(sg, "StudentGroup");
			
			if(value.ObjectId == null){
				Debug.Log ("studentGroup_teacher.student_group is null!");
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
				Debug.Log ("studentGroup_teacher.teacher is null!");
			}
		}
	}
	
	public studentgroup_teacher () {}
	
	public studentgroup_teacher(ParseObject po){
		this.ObjectId = po.ObjectId;
		

		if(po.ContainsKey("school")) {
			School s = new School();
			s.ObjectId = po.Get<ParseObject>("school").ObjectId;
			this.School = s;
		}
		

		if(po.ContainsKey("student_group")) {
			StudentGroup sg = new StudentGroup();
			sg.ObjectId = po.Get<ParseObject>("student_group").ObjectId;
			this.StudentGroup = sg;
		}
		

		if(po.ContainsKey("teacher")) {
			Teacher t = new Teacher();
			t.ObjectId = po.Get<ParseObject>("teacher").ObjectId;
			this.Teacher = t;
		}
	}
	
	public studentgroup_teacher (School school, StudentGroup studentGroup, Teacher teacher)
	{
		this.School = school;
		this.StudentGroup = studentGroup;
		this.Teacher = teacher;
	}

	public studentgroup_teacher (StudentGroup_TeacherSerialized sg_ts){
		if (sg_ts != null) {
			this.ObjectId = sg_ts.ObjectId;

			School s = new School ();
			if (sg_ts.SchoolSerialized != null)
				s.ObjectId = sg_ts.SchoolSerialized.ObjectId;
			this.School = s;

			StudentGroup sg = new StudentGroup ();
			if (sg_ts.StudentGroupSerialized != null)
				sg.ObjectId = sg_ts.StudentGroupSerialized.ObjectId;
			this.StudentGroup = sg;

			Teacher t = new Teacher ();
			if (sg_ts.TeacherSerialized != null)
				t.ObjectId = sg_ts.TeacherSerialized.ObjectId;
			this.Teacher = t;
		}
	}

	public override string ToString ()
	{
		return string.Format ("[studentgroup_teacher: School={0}, StudentGroup={1}, Teacher={2}]", School, StudentGroup, Teacher);
	}
	
	
}
