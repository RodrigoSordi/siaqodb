using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiagnosisLevelSnapshotSerializedDAO : SerializedDAO<DiagnosisLevelSnapshotSerialized> {

	public DiagnosisLevelSnapshotSerializedDAO () {}
	public DiagnosisLevelSnapshotSerializedDAO (string path) : base (path) {}

	public List<DiagnosisLevelSnapshotSerialized> LoadByStudent (StudentSerialized ss) {
		List<DiagnosisLevelSnapshotSerialized> result = new List<DiagnosisLevelSnapshotSerialized> ();		//Debug.Log ("sgs.getSeries () = " + sgs.getSeries ());

		/*List<DiagnosisLevelSnapshotSerialized> dlssList = LoadAll ();// LoadFile ();
		foreach (DiagnosisLevelSnapshotSerialized dlss in dlssList) {
			if (ss != null &&
			    dlss != null && 
			    dlss.getStudentSerialized () != null && 
			    dlss.getStudentSerialized ().Id == ss.Id) {
				result.Add (dlss);
			}
		}*/
		
		return result;
	}

	public List<DiagnosisLevelSnapshotSerialized> LoadByGroupSerie (StudentGroupSerialized sgs) {
		List<DiagnosisLevelSnapshotSerialized> result = new List<DiagnosisLevelSnapshotSerialized> ();

		/*List<DiagnosisLevelSnapshotSerialized> dlssList = LoadAll ();// LoadFile ();
		foreach (DiagnosisLevelSnapshotSerialized dlss in dlssList) {
			if (sgs != null &&
					dlss != null && 
				    dlss.getStudentSerialized () != null && 
				    dlss.getStudentSerialized ().getStudentGroupSerialized () != null &&
					dlss.getStudentSerialized ().getStudentGroupSerialized ().Id == sgs.Id &&
			    	dlss.getStudentSerialized ().getStudentGroupSerialized ().getSeries ().Equals(sgs.getSeries ())) {
				result.Add (dlss);
			}
		}*/
		
		return result;
	}

	public Dictionary<int, List<DiagnosisLevelSnapshotSerialized>> LoadByGroupSerieButThis (StudentGroupSerialized sgs) {
		//Debug.Log ("sgs.Id = " + sgs.Id);
		//Debug.Log ("sgs.getSeries () = " + sgs.getSeries ());
		Dictionary<int, List<DiagnosisLevelSnapshotSerialized>> result = new Dictionary<int, List<DiagnosisLevelSnapshotSerialized>> ();

		/*List<DiagnosisLevelSnapshotSerialized> dlssList = LoadAll ();// LoadFile ();
		foreach (DiagnosisLevelSnapshotSerialized dlss in dlssList) {
			if (sgs != null &&
			    	dlss != null &&
				    dlss.getStudentSerialized () != null && 
				    dlss.getStudentSerialized ().getStudentGroupSerialized () != null &&
					dlss.getStudentSerialized ().getStudentGroupSerialized ().Id != sgs.Id &&
			    	!dlss.getStudentSerialized ().getStudentGroupSerialized ().getSeries ().Equals(sgs.getSeries ())) {
				int id = dlss.getStudentSerialized ().getStudentGroupSerialized ().Id;
				if (!result.ContainsKey (id)) {
					//Debug.Log ("Dont Contains and new = " + id);
					result.Add (id, new List<DiagnosisLevelSnapshotSerialized> () {dlss});
				} else {
					//Debug.Log ("Contains and add = " + id);
					List<DiagnosisLevelSnapshotSerialized> value = null;
					if (result.TryGetValue (id, out value)) {
						value.Add (dlss);
					}
				}
			}//else
				//Debug.Log ("Doesn enter in list = " + dlss.getStudentSerialized ().getStudentGroupSerialized ().Id);
		}*/
		
		return result;
	}

}
