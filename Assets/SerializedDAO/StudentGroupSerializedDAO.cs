using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Sqo;
using SiaqodbDemo;

public class StudentGroupSerializedDAO : SerializedDAO<StudentGroupSerialized> {

	public StudentGroupSerializedDAO () {}
	public StudentGroupSerializedDAO (string path) : base (path) {}

	public void UpdateWithoutSetAsUpdated (StudentGroupSerialized sgs) {
		/*List<StudentGroupSerialized> sgsList = LoadAll ();// LoadFile ();
		
		if (sgs != null) {
			if (sgs.Id == 0) {
				Debug.Log ("Id is 0, cannot fill the list!");
			} else {
				bool updateCheck = false;
				for (int i = 0; i < sgsList.Count; i++) {
					updateCheck = true;
					if (sgsList[i] != null && sgsList[i].Id == sgs.Id) {
						sgsList[i] = sgs;
						//SaveFile (sgsList);
						SaveList (sgsList);
						break;
					}
				}
				if (!updateCheck) {
					Debug.Log ("Serialized Id not found!");
				}
			}
		} else {
			Debug.Log ("No Serialized to save!");
		}*/
	}
	
	
	public void FillGroupListAndSave (StudentGroupSerialized sgs, List<StudentGroup_TeacherSerialized> sg_tsList) {
		/*foreach (StudentGroup_TeacherSerialized sg_ts in sg_tsList) {
			if (sg_ts != null && sg_ts.getStudentGroupSerialized () != null && sg_ts.getStudentGroupSerialized ().ObjectId.Equals(sgs.ObjectId)) {
				if (sgs.TeacherSerializedList == null)
					sgs.TeacherSerializedList = new List<TeacherSerialized> ();
				sgs.TeacherSerializedList.Add (sg_ts.getTeacherSerialized ());
				Debug.Log ("Added Teacher in StudentGroup.TeacherList");
			}
		}
		
		UpdateWithoutSetAsUpdated (sgs);*/
	}

	public List<StudentGroupSerialized> LoadBySchool (SchoolSerialized ss) {
		Func<StudentGroupSerialized, bool> predicate = sgs => sgs.SchoolSerialized.OID == ss.OID;
		return LoadByCriteria (predicate);
	}

}
