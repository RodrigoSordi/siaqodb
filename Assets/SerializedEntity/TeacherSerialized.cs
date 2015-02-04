using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TeacherSerialized : SerializedEntity {

	public string Answer { get; set; }
	public string Email { get; set; }
	public bool IsCoordinator { get; set; }
	public string LastName { get; set; }
	public string Name { get; set; }
	public string PassCode { get; set; }
	public string Phone { get; set; }
	public string Question { get; set; }
	public SchoolSerialized SchoolSerialized { get; set; }
	public byte[] Picture { get; set; }

	public List<StudentGroupSerialized> studentGroupSerializedList;

	public TeacherSerialized () {}

	public TeacherSerialized (string answer, string email, bool isCoordinator, string lastName, string name, string passCode, string phone, string question, SchoolSerialized schoolSerialized)
	{
		this.Answer = answer;
		this.Email = email;
		this.IsCoordinator = isCoordinator;
		this.LastName = lastName;
		this.Name = name;
		this.PassCode = passCode;
		this.Phone = phone;
		this.Question = question;

		this.SchoolSerialized = schoolSerialized;
	}

	public TeacherSerialized (Teacher t)
	{
		base.ObjectId = t.ObjectId;
		base.CreatedAt = t.CreatedAt;
		base.UpdatedAt = t.UpdatedAt;
		//base.Id = 0;

		this.Answer = t.Answer;
		this.Email = t.Email;
		this.IsCoordinator = t.IsCoordinator;
		this.LastName = t.LastName;
		this.Name = t.Name;
		this.PassCode = t.PassCode;
		this.Phone = t.Phone;
		this.Question = t.Question;

		if (t.School != null){
			SchoolSerialized ss = new SchoolSerializedDAO ().LoadByObjectId (t.School.ObjectId);
			if (ss != null){
				this.SchoolSerialized = ss;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}
	}

	public override string ToString ()
	{
		return string.Format (base.ToString () + "[TeacherSerialized: Answer={0}, Email={1}, IsCoordinator={2}, LastName={3}, Name={4}, PassCode={5}, Phone={6}, Question={7}, SchoolSerialized={8}]", Answer, Email, IsCoordinator, LastName, Name, PassCode, Phone, Question, SchoolSerialized);
	}	

}
	
