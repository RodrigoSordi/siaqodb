using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class StudentSerializedDAO : SerializedDAO<StudentSerialized> {

	public StudentSerializedDAO () {}
	public StudentSerializedDAO (string path) : base (path) {}

	public void UpdateWithoutSetAsUpdated (StudentSerialized ss) {
		/*List<StudentSerialized> ssList = LoadAll ();//LoadFile ();
		
		if (ss != null) {
			if (ss.Id == 0) {
				Debug.Log ("Id is 0, cannot fill the list!");
			} else {
				bool updateCheck = false;
				for (int i = 0; i < ssList.Count; i++) {
					updateCheck = true;
					if (ssList[i] != null && ssList[i].Id == ss.Id) {
						ssList[i] = ss;
						//SaveFile (ssList);
						SaveList (ssList);
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

	public List<StudentSerialized> GetStudentsFromGroup (StudentGroupSerialized sgs) {
		List<StudentSerialized> studentsToReturn = new List<StudentSerialized> ();
		/*List<StudentSerialized> students = LoadAll ();

		if (students.Count > 0) {
			foreach (StudentSerialized ss in students) {
				if (ss != null && ss.getStudentGroupSerialized () != null && sgs != null && ss.getStudentGroupSerialized ().Id == sgs.Id) {
					studentsToReturn.Add (ss);
				}
			}
		}*/
		return studentsToReturn;
	}

	public List<string> LoadClassFriendsNames (StudentGroupSerialized sgs) {
		List<string> result = new List<string> ();

		/*List<StudentSerialized> ssList = LoadAll (); //LoadFile ();
		foreach (StudentSerialized ss in ssList) {
			if (ss.getStudentGroupSerialized ().Id == sgs.Id) {
				result.Add (ss.getName ());
			}
		}*/

		return result;
	}

}
