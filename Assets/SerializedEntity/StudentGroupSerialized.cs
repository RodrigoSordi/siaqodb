using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class StudentGroupSerialized : SerializedEntity {
	
	public string Name { get; set; }
	public string Period { get; set; }
	public SchoolSerialized SchoolSerialized { get; set; }
	public string Series { get; set; }
	
	public List<TeacherSerialized> TeacherSerializedList;
	
	public StudentGroupSerialized (){}
	
	public StudentGroupSerialized (string name, string period, SchoolSerialized schoolSerialized, string series)
	{
		this.Name = name;
		this.Period = period;
		this.SchoolSerialized = schoolSerialized;
		this.Series = series;
	}
	
	public StudentGroupSerialized (StudentGroup sg) {
		base.ObjectId = sg.ObjectId;
		
		this.Name = sg.Name;
		this.Period = sg.Period;
		this.Series = sg.Series;
		
		if (sg.School != null){
			SchoolSerialized ss = new SchoolSerializedDAO ().LoadByObjectId (sg.School.ObjectId);
			if (ss != null){
				this.SchoolSerialized = ss;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}
	}

	public override string ToString ()
	{
		return string.Format (base.ToString () + "[StudentGroupSerialized: Name={0}, Period={1}, SchoolSerialized={2}, Series={3}]", Name, Period, SchoolSerialized != null ? "Not null" : "null", Series);
	}


}
