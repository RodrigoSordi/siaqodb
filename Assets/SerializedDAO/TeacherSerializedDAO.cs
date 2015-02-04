using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class TeacherSerializedDAO : SerializedDAO<TeacherSerialized> {

	private static StudentGroup_TeacherSerializedDAO sg_tsDAO;

	public TeacherSerializedDAO () {}
	public TeacherSerializedDAO (string path) : base (path) {}

	public void SaveOrUpdate(TeacherSerialized ts){

		sg_tsDAO = new StudentGroup_TeacherSerializedDAO ();

		if (ts.studentGroupSerializedList == null)
			ts.studentGroupSerializedList = new List<StudentGroupSerialized> ();

		List<StudentGroup_TeacherSerialized> sg_tsList = sg_tsDAO.LoadByTeachersObjectId (ts.ObjectId);

		foreach (StudentGroup_TeacherSerialized sg_ts in sg_tsList) {
			ts.studentGroupSerializedList.Add (sg_ts.StudentGroupSerialized);
			Debug.Log (sg_ts.StudentGroupSerialized);
		}

		base.SaveOrUpdate (ts);

		/*List<TeacherSerialized> tsList = LoadAll ();// LoadFile ();
		
		if(ts != null){
			if (ts.Id == 0) {
				//Set the id by the size of the existent amount of SerializedEntities
				ts.Id = tsList.Count + 1;
				ts.updated = false;
				tsList.Add (ts as TeacherSerialized);
				//SaveFile (tsList);
				SaveList (tsList);
				//Debug.Log ("Serialized Saved [id = " + ts.Id + "] " + ts + " at: " + base.path);
				new StudentGroup_TeacherSerializedDAO ().UpdateRelations (ts);
			}else{
				bool updateCheck = false;
				for(int i = 0; i < tsList.Count; i++){
					if(tsList[i] != null && tsList[i].Id == ts.Id){
						updateCheck = true;
						ts.updated = true;
						tsList[i] = ts as TeacherSerialized;
						//SaveFile (tsList);
						SaveList (tsList);
						//Debug.Log ("Serialized Updated [id = " + ts.Id + "] " + ts);

						new StudentGroup_TeacherSerializedDAO ().UpdateRelations (ts);
						break;
					}
				}
				if(!updateCheck){
					Debug.Log ("Serialized Id not found!");
				}
			}
			
		}else{
			Debug.Log ("No Serialized to save!");
		}*/
	}

	public void UpdateWithoutSetAsUpdated (TeacherSerialized ts) {
		/*List<TeacherSerialized> tsList = LoadAll ();// LoadFile ();
		
		if (ts != null) {
			if (ts.Id == 0) {
				Debug.Log ("Id is 0, cannot fill the list!");
			} else {
				bool updateCheck = false;
				for (int i = 0; i < tsList.Count; i++) {
					updateCheck = true;
					if (tsList[i] != null && tsList[i].Id == ts.Id) {
						tsList[i] = ts;
						//SaveFile (tsList);
						SaveList (tsList);
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


	public void FillGroupListAndSave (TeacherSerialized ts, List<StudentGroup_TeacherSerialized> sg_tsList) {
		/*foreach (StudentGroup_TeacherSerialized sg_ts in sg_tsList) {
			if (sg_ts != null && sg_ts.getTeacherSerialized () != null && sg_ts.getTeacherSerialized ().ObjectId.Equals(ts.ObjectId)) {
				if (ts.studentGroupSerializedList == null)
					ts.studentGroupSerializedList = new List<StudentGroupSerialized> ();
				ts.studentGroupSerializedList.Add (sg_ts.getStudentGroupSerialized ());
				//Debug.Log ("Added Student in Teacher.StudentList");
			}
		}

		UpdateWithoutSetAsUpdated (ts);*/
	}

}
