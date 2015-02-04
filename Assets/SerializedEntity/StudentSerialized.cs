using UnityEngine;
using System.Collections;
using System;
using Parse;

public class StudentSerialized : SerializedEntity {
	
	public long BirthDate { get; set; }
	public long BuildingsCount { get; set; }
	public long Coins { get; set; }
	public string DiagnosisLevel { get; set; }
	public string Gender { get; set; }
	public string Guardian { get; set; }
	public string Name { get; set; }
	public SchoolSerialized SchoolSerialized { get; set; }
	public StudentGroupSerialized StudentGroupSerialized { get; set; }
	public string LastName { get; set; }

	public byte[] Picture;

	public StudentSerialized (){}
	
	public StudentSerialized (long birthDate, long buildingsCount, long coins, string diagnosisLevel, string gender, string guardian, string name, SchoolSerialized schoolSerialized, StudentGroupSerialized studentGroupSerialized, string lastName)
	{
		this.BirthDate = birthDate;
		this.BuildingsCount = buildingsCount;
		this.Coins = coins;
		this.DiagnosisLevel = diagnosisLevel;
		this.Gender = gender;
		this.Guardian = guardian;
		this.Name = name;
		this.SchoolSerialized = schoolSerialized;
		this.StudentGroupSerialized = studentGroupSerialized;
		this.LastName = lastName;
	}
	
	public StudentSerialized (Student s) {
		base.ObjectId = s.ObjectId;
		
		this.BirthDate = s.BirthDate;
		this.BuildingsCount = s.BuildingsCount;
		this.Coins = s.Coins;
		this.DiagnosisLevel = s.DiagnosisLevel;
		this.Gender = s.Gender;
		this.Guardian = s.Guardian;
		this.Name = s.Name;
		this.LastName = s.LastName;
		
		if (s.School != null){
			SchoolSerialized ss = new SchoolSerializedDAO ().LoadByObjectId (s.School.ObjectId);
			if (ss != null){
				this.SchoolSerialized = ss;
			}else{
				//Debug.Log ("Serialized: There is no relationship saved");
			}
		}

		if (s.StudentGroup != null) {
			StudentGroupSerialized sgs = new StudentGroupSerializedDAO ().LoadByObjectId (s.StudentGroup.ObjectId);
			if (sgs != null){
				this.StudentGroupSerialized = sgs;
			}else{
				//Debug.Log ("[ObjectId: " + s.StudentGroup.ObjectId + "] Serialized: There is no relationship saved");
			}
		}
	}

	public override string ToString ()
	{
		return string.Format (base.ToString () + "[StudentSerialized: BirthDate={0}, BuildingsCount={1}, Coins={2}, DiagnosisLevel={3}, Gender={4}, Guardian={5}, Name={6}, SchoolSerialized={7}, StudentGroupSerialized={8}, LastName={9}]", BirthDate, BuildingsCount, Coins, DiagnosisLevel, Gender, Guardian, Name, SchoolSerialized, StudentGroupSerialized, LastName);
	}
	

}
