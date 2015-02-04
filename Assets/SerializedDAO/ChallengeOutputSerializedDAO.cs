using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class ChallengeOutputSerializedDAO : SerializedDAO<ChallengeOutputSerialized> {

	public ChallengeOutputSerializedDAO () {}
	public ChallengeOutputSerializedDAO (string path) : base (path) {}

	public List<ChallengeOutputSerialized> LoadByStudent(StudentSerialized ss){
		List<ChallengeOutputSerialized> result = new List<ChallengeOutputSerialized> ();

		/*List<ChallengeOutputSerialized> cosList = LoadAll ();// LoadFile ();
		if (cosList != null && cosList.Count > 0) {
			foreach(ChallengeOutputSerialized cos in cosList){
				if(cos != null && cos.getStudentSerialized () != null && cos.getStudentSerialized ().Id == ss.Id){
					result.Add (cos);
					//Debug.Log ("Serialized Loaded [id =  " + t.Id + "] " + t + " from " + path);
				}
				else
				{
					//Debug.Log ("Serialized is Deleted!");
				}
			}
		}else{
			//Debug.Log ("There are no Serializeds saved!");
		}*/
		
		return result;
	}

	public List<ChallengeOutputSerialized> LoadStudentsByGroupButThis(StudentSerialized ss){
		List<ChallengeOutputSerialized> result = new List<ChallengeOutputSerialized> ();
		
		/*List<ChallengeOutputSerialized> cosList = LoadAll (); //LoadFile ();
		if (cosList != null && cosList.Count > 0) {
			foreach(ChallengeOutputSerialized cos in cosList){
				if (cos != null &&
					    cos.getStudentSerialized () != null &&
					    cos.getStudentSerialized ().getStudentGroupSerialized () != null &&
					    ss != null &&
					    ss.getStudentGroupSerialized () != null &&
					    cos.getStudentSerialized ().getStudentGroupSerialized ().Id == ss.getStudentGroupSerialized ().Id &&
					    cos.getStudentSerialized ().Id != ss.Id) {

					result.Add (cos);
				}
			}
		}else{
			//Debug.Log ("There are no Serializeds saved!");
		}*/
		
		return result;
	}

	public List<ChallengeOutputSerialized> LoadByStudentAndEtapa(StudentSerialized ss, string etapa){
		List<ChallengeOutputSerialized> result = new List<ChallengeOutputSerialized> ();
		
		/*List<ChallengeOutputSerialized> cosList = LoadAll ();// LoadFile ();
		if (cosList != null && cosList.Count > 0) {
			foreach(ChallengeOutputSerialized cos in cosList){
				if(cos != null && cos.getStudentSerialized () != null && cos.getStudentSerialized ().Id == ss.Id && 
				   		cos.getEtapa ().Equals (etapa)){
					result.Add (cos);
					//Debug.Log ("Serialized Loaded [id =  " + t.Id + "] " + t + " from " + path);
				}
				else
				{
					//Debug.Log ("Serialized is Deleted!");
				}
			}
		}else{
			//Debug.Log ("There are no Serializeds saved!");
		}*/
		
		return result;
	}

}
