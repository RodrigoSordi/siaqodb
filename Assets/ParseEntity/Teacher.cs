using UnityEngine;
using System.Collections;
using System;
using Parse;
using System.Collections.Generic;

[ParseClassName("Teacher")]
public class Teacher : ParseObject {

	[ParseFieldName("answer")]
	public string Answer { 
		get { return GetProperty<string>("Answer");} 
		set { SetProperty<string>(value, "Answer");}
	}

	[ParseFieldName("email")]
	public string Email { 
		get { return GetProperty<string>("Email");} 
		set { SetProperty<string>(value, "Email");}
	}

	[ParseFieldName("is_coordinator")]
	public bool IsCoordinator { 
		get { return GetProperty<bool>("IsCoordinator");} 
		set { SetProperty<bool>(value, "IsCoordinator");}
	}

	[ParseFieldName("last_name")]
	public string LastName { 
		get { return GetProperty<string>("LastName");} 
		set { SetProperty<string>(value, "LastName");}
	}

	[ParseFieldName("name")]
	public string Name { 
		get { return GetProperty<string>("Name");} 
		set { SetProperty<string>(value, "Name");}
	}

	[ParseFieldName("passcode")]
	public string PassCode { 
		get { return GetProperty<string>("PassCode");} 
		set { SetProperty<string>(value, "PassCode");}
	}

	[ParseFieldName("phone")]
	public string Phone { 
		get { return GetProperty<string>("Phone");} 
		set { SetProperty<string>(value, "Phone");}
	}

	[ParseFieldName("picture")]
	public ParseFile Picture { 
		get { return GetProperty<ParseFile>("Picture");} 
		set { SetProperty<ParseFile>(value, "Picture");}
	}

	[ParseFieldName("question")]
	public string Question { 
		get { return GetProperty<string>("Question");} 
		set { SetProperty<string>(value, "Question");}
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

	public Teacher(){}

	public Teacher(ParseObject po) {
		this.ObjectId = po.ObjectId;

		if (po.ContainsKey ("answer")) this.Answer = po.Get<string> ("answer");
		if (po.ContainsKey ("email")) this.Email = po.Get<string> ("email");
		if (po.ContainsKey ("is_coordinator")) this.IsCoordinator = po.Get<bool> ("is_coordinator");
		if (po.ContainsKey ("last_name")) this.LastName = po.Get<string> ("last_name");
		if (po.ContainsKey ("name")) this.Name = po.Get<string> ("name");
		if (po.ContainsKey ("passcode")) this.PassCode = po.Get<string> ("passcode");
		if (po.ContainsKey ("phone")) this.Phone = po.Get<string> ("phone");
		if (po.ContainsKey ("question")) this.Question = po.Get<string> ("question");

		if(po.ContainsKey("picture"))
			this.Picture = po.Get<ParseFile>("picture");

		if(po.ContainsKey("school")){
			School s = new School();
			s.ObjectId = po.Get<ParseObject>("school").ObjectId;
			this.School = s;
		}
	}

	public Teacher (string answer, string email, bool isCoordinator, string lastName, string name, string passCode, string phone, string question, School school)
	{
		this.Answer = answer;
		this.Email = email;
		this.IsCoordinator = isCoordinator;
		this.LastName = lastName;
		this.Name = name;
		this.PassCode = passCode;
		this.Phone = phone;
		//this.Picture = picture;
		this.Question = question;
		this.School = school;
	}

	public Teacher (TeacherSerialized ts) {
		if (ts != null){
			this.ObjectId = ts.ObjectId;

			this.Answer = ts.Answer;
			this.Email = ts.Email;
			this.IsCoordinator = ts.IsCoordinator;
			this.LastName = ts.LastName;
			this.Name = ts.Name;
			this.PassCode = ts.PassCode;
			this.Phone = ts.Phone;
			this.Question = ts.Question;

			if (ts.Picture != null) {
				byte[] data = ts.Picture;
				this.Picture = new ParseFile("photo.jpg", data);
			}

			School s = new School ();
			if (ts.SchoolSerialized != null)
				s.ObjectId = ts.SchoolSerialized.ObjectId;
			this.School = s;
		}
	}
	
	public override string ToString ()
	{
		return string.Format ("[Teacher: Answer={0}, Email={1}, IsCoordinator={2}, LastName={3}, Name={4}, PassCode={5}, Phone={6}, Question={7}, School={8}]", Answer, Email, IsCoordinator, LastName, Name, PassCode, Phone, Question, School);
	}
	
	
}
	
