using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StudentGroup_TeacherSerialized : SerializedEntity {

	public SchoolSerialized SchoolSerialized { get; set; }
	public TeacherSerialized TeacherSerialized { get; set; }
	public StudentGroupSerialized StudentGroupSerialized { get; set; }

	public StudentGroup_TeacherSerialized () {}

	public StudentGroup_TeacherSerialized (SchoolSerialized schoolSerialized, TeacherSerialized teacherSerialized, StudentGroupSerialized studentGroupSerialized)
	{
		this.SchoolSerialized = schoolSerialized;
		this.TeacherSerialized = teacherSerialized;
		this.StudentGroupSerialized = studentGroupSerialized;
	}

	public StudentGroup_TeacherSerialized (studentgroup_teacher sgt) {
		base.ObjectId = sgt.ObjectId;
		base.CreatedAt = sgt.CreatedAt;
		base.UpdatedAt = sgt.UpdatedAt;
		//base.Id = 0;

		if (sgt.School != null){
			SchoolSerialized ss = new SchoolSerializedDAO ().LoadByObjectId (sgt.School.ObjectId);
			if (ss != null){
				this.SchoolSerialized = ss;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}

		if (sgt.StudentGroup != null){
			StudentGroupSerialized sgs = new StudentGroupSerializedDAO ().LoadByObjectId (sgt.StudentGroup.ObjectId);
			if (sgs != null){
				this.StudentGroupSerialized = sgs;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}

		if (sgt.Teacher != null){
			TeacherSerialized ts = new TeacherSerializedDAO ().LoadByObjectId (sgt.Teacher.ObjectId);
			if (ts != null){
				this.TeacherSerialized = ts;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}

	}

	public override string ToString ()
	{
		return string.Format (base.ToString () + "[StudentGroup_TeacherSerialized: SchoolSerialized={0}, TeacherSerialized={1}, StudentGroupSerialized={2}]", SchoolSerialized, TeacherSerialized, StudentGroupSerialized);
	}

}
