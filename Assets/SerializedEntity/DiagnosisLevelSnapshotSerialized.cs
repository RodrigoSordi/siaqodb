using UnityEngine;
using System.Collections;
using System;

public class DiagnosisLevelSnapshotSerialized : SerializedEntity {

	public string DiagnosisLevel { get; set; }
	public SchoolSerialized SchoolSerialized { get; set; }
	public long StartTime { get; set; }
	public StudentSerialized StudentSerialized { get; set; }

	public DiagnosisLevelSnapshotSerialized () {}
	
	public DiagnosisLevelSnapshotSerialized (string diagnosisLevel, SchoolSerialized schoolSerialized, long startTime, StudentSerialized studentSerialized)
	{
		this.DiagnosisLevel = diagnosisLevel;
		this.SchoolSerialized = schoolSerialized;
		this.StartTime = startTime;
		this.StudentSerialized = studentSerialized;
	}

	public DiagnosisLevelSnapshotSerialized (DiagnosisLevelSnapshot dls)
	{
		this.DiagnosisLevel = dls.DiagnosisLevel;
		this.StartTime = dls.StartTime;

		if (dls.School != null){
			SchoolSerialized ss = new SchoolSerializedDAO ().LoadByObjectId (dls.School.ObjectId);
			if (ss != null){
				this.SchoolSerialized = ss;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}

		if (dls.Student != null) {
			StudentSerialized ss = new StudentSerializedDAO ().LoadByObjectId (dls.Student.ObjectId);
			if (ss != null){
				this.StudentSerialized = ss;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}
	}

	public override string ToString ()
	{
		return string.Format (base.ToString () + "[DiagnosisLevelSnapshotSerialized: DiagnosisLevel={0}, SchoolSerialized={1}, StartTime={2}, StudentSerialized={3}]", DiagnosisLevel, SchoolSerialized, StartTime, StudentSerialized);
	}
	
	
}
