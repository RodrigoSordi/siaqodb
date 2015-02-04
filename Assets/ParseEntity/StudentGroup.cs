using UnityEngine;
using System.Collections;
using System;
using Parse;

[ParseClassName("StudentGroup")]
public class StudentGroup : ParseObject {
	
	/*[ParseFieldName("deletedAt")]
	public DateTime DeletedAt { 
		get { return GetProperty<DateTime>("DeletedAt");} 
		set { SetProperty<DateTime>(value, "DeletedAt");}
	}*/
	
	[ParseFieldName("name")]
	public string Name { 
		get { return GetProperty<string>("Name");} 
		set { SetProperty<string>(value, "Name");}
	}
	
	[ParseFieldName("period")]
	public string Period { 
		get { return GetProperty<string>("Period");} 
		set { SetProperty<string>(value, "Period");}
	}
	
	[ParseFieldName("school")]
	public School School { 
		get { return GetProperty<School> ("School");} 
		set { 
			ParseObject.RegisterSubclass<School>();
			School school = ParseObject.CreateWithoutData<School>(value.ObjectId);
			SetProperty<School>(school, "School");
		}
	}
	
	[ParseFieldName("series")]
	public string Series { 
		get { return GetProperty<string>("Series");} 
		set { SetProperty<string>(value, "Series");}
	}
	
	public StudentGroup () {}
	
	public StudentGroup (ParseObject po)
	{
		this.ObjectId = po.ObjectId;
		
		if (po.ContainsKey ("name")) this.Name = po.Get<string> ("name");
		if (po.ContainsKey ("period")) this.Period = po.Get<string> ("period");
		if (po.ContainsKey ("series")) this.Series = po.Get<string> ("series");
		

		if(po.ContainsKey("school")) {
			School s = new School();
			s.ObjectId = po.Get<ParseObject>("school").ObjectId;
			this.School = s;
		}
	}

	public StudentGroup (StudentGroupSerialized sgs) {
		if (sgs != null) {
			this.ObjectId = sgs.ObjectId;

			this.Name = sgs.Name;
			this.Period = sgs.Period;
			this.Series = sgs.Series;

			School s = new School ();
			if (sgs.SchoolSerialized != null)
				s.ObjectId = sgs.SchoolSerialized.ObjectId;
			this.School = s;
		}
	}
	
	public StudentGroup (string name, string period, School school, string series)
	{
		this.Name = name;
		this.Period = period;
		this.School = school;
		this.Series = series;
	}
	
	public override string ToString ()
	{
		return string.Format ("[StudentGroup: Name={0}, Period={1}, School={2}, Series={3}]", Name, Period, School, Series);
	}
	
	
	
}
