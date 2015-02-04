using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Sqo;
using SiaqodbDemo;

public class StudentGroup_TeacherSerializedDAO : SerializedDAO <StudentGroup_TeacherSerialized> {

	public StudentGroup_TeacherSerializedDAO () {}
	public StudentGroup_TeacherSerializedDAO (string path) : base (path) {}

	public List<StudentGroup_TeacherSerialized> LoadByTeachersObjectId (string objectId) {
		List<StudentGroup_TeacherSerialized> result = null;
		try {
			var query = (from StudentGroup_TeacherSerialized t in siaqodb select t);
			result = query.ToList<StudentGroup_TeacherSerialized> ().Where (t => t.ObjectId == objectId).ToList ();
		} catch {
			return null;
		}
		return result;
	}

	public List<StudentGroup_TeacherSerialized> LoadByTeacher (TeacherSerialized ts) {
		List<StudentGroup_TeacherSerialized> result = new List<StudentGroup_TeacherSerialized> ();

		/*List<StudentGroup_TeacherSerialized> sg_tsList = LoadAll ();

		foreach (StudentGroup_TeacherSerialized sg_ts in sg_tsList) {
			if (sg_ts != null && sg_ts.getTeacherSerialized () != null && sg_ts.getTeacherSerialized ().Id == ts.Id) {
				result.Add (sg_ts);
				//Debug.Log ("Founded relation's Teacher");
			}
		}*/

		return result;
	}

	public void UpdateRelations (TeacherSerialized ts) {
		/*List<StudentGroup_TeacherSerialized> sg_tsList = LoadByTeacher (ts);

		if (ts.studentGroupSerializedList != null) {
			//Add new
			foreach (StudentGroupSerialized sgs in ts.studentGroupSerializedList) {
				if (!Contains (sgs, sg_tsList)) {
					StudentGroup_TeacherSerialized sg_ts = new StudentGroup_TeacherSerialized();
					sg_ts.setSchoolSerialized (ts.getSchoolSerialized ());
					sg_ts.setTeacherSerialized (ts);
					sg_ts.setStudentGroupSerialized (sgs);
					new StudentGroup_TeacherSerializedDAO ().SaveOrUpdate (sg_ts);
				}
			}
			//Remove deleted
			foreach (StudentGroup_TeacherSerialized sg_ts in sg_tsList) {
				if (!Contains (sg_ts, ts.studentGroupSerializedList)) {
					new StudentGroup_TeacherSerializedDAO ().Delete (sg_ts);
				}
			}

			if (ts.studentGroupSerializedList.Count == 0) {
				//Debug.Log ("List is empty");
				DeleteRelations (sg_tsList);
			}

		}else{
			//Find the relations saved and delete them
			//Debug.Log ("List is null");
			DeleteRelations (sg_tsList);
		}*/
	}

	public void DeleteRelations (List<StudentGroup_TeacherSerialized> sg_tsList) {
		/*foreach (StudentGroup_TeacherSerialized sg_ts in sg_tsList) {
			Delete (sg_ts);
		}*/
	}

	//Verify if Group is in a Relation List
	public bool Contains (StudentGroupSerialized sgs, List<StudentGroup_TeacherSerialized> sg_tsList) {
		bool contains = false;

		/*if (sgs.Id == 0) {
			//Debug.Log ("Group is not saved!");
			return false;
		}

		foreach (StudentGroup_TeacherSerialized sg_ts in sg_tsList) {
			if (sg_ts != null && sgs.Id == sg_ts.getStudentGroupSerialized ().Id) {
				contains = true;
				break;
			}
		}*/

		return contains;
	}

	//Verify if Relation is in a Group List
	public bool Contains (StudentGroup_TeacherSerialized sg_ts, List<StudentGroupSerialized> sgsList) {
		bool contains = false;

		/*if (sg_ts != null && sgsList != null) {
			foreach (StudentGroupSerialized sgs in sgsList) {
				if (sg_ts.getStudentGroupSerialized ().Id == sgs.Id) {
					contains = true;
					break;
				}
			}
		}*/

		return contains;
	}

}
