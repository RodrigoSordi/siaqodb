using UnityEngine;
using System.Collections;
using System;

public class NoteSerialized : SerializedEntity {

	public string NoteText { get; set; }
	public SchoolSerialized SchoolSerialized { get; set; }
	public StudentSerialized StudentSerialized { get; set; }
	public TeacherSerialized TeacherSerialized { get; set; }
	public long WrittenAt { get; set; }

	public NoteSerialized () {}

	public NoteSerialized (string noteText, SchoolSerialized schoolSerialized, StudentSerialized studentSerialized, TeacherSerialized teacherSerialized, long writtenAt)
	{
		this.NoteText = noteText;
		this.SchoolSerialized = schoolSerialized;
		this.StudentSerialized = studentSerialized;
		this.TeacherSerialized = teacherSerialized;
		this.WrittenAt = writtenAt;
	}

	public NoteSerialized (Note n) {
		base.ObjectId = n.ObjectId;
		base.CreatedAt = n.CreatedAt;
		base.UpdatedAt = n.UpdatedAt;
		//base.Id = 0;

		this.NoteText = n.NoteText;
		this.WrittenAt = n.WrittenAt;

		if (n.School != null){
			SchoolSerialized ss = new SchoolSerializedDAO ().LoadByObjectId (n.School.ObjectId);
			if (ss != null){
				this.SchoolSerialized = ss;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}

		if (n.Student != null) {
			StudentSerialized ss = new StudentSerializedDAO ().LoadByObjectId (n.Student.ObjectId);
			if (ss != null){
				this.StudentSerialized = ss;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}

		if (n.Teacher != null) {
			TeacherSerialized ts = new TeacherSerializedDAO ().LoadByObjectId (n.Teacher.ObjectId);
			if (ts != null) 
				this.TeacherSerialized = ts;
			else
				Debug.Log ("Serialized: There is no relationship saved");
		}
	}

	public override string ToString ()
	{
		return string.Format (base.ToString () + "[NoteSerialized: NoteText={0}, SchoolSerialized={1}, StudentSerialized={2}, TeacherSerialized={3}, WrittenAt={4}]", NoteText, SchoolSerialized, StudentSerialized, TeacherSerialized, WrittenAt);
	}
	

}
