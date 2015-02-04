using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class WrittenWordSerializedDAO : SerializedDAO<WrittenWordSerialized> {

	public WrittenWordSerializedDAO () {}

	public List<WrittenWordSerialized> LoadByStudent (StudentSerialized ss) {
		List<WrittenWordSerialized> result = new List<WrittenWordSerialized> ();
		
		/*List<WrittenWordSerialized> wwsList = LoadAll ();//LoadFile ();
		foreach (WrittenWordSerialized wws in wwsList) {
			if (ss != null &&
			    wws != null && 
			    wws.getStudentSerialized () != null && 
			    wws.getStudentSerialized ().Id == ss.Id) {
				
				result.Add (wws);
			}
		}
		
		//Order by date ascendent
		for (int i = 0; i < result.Count - 1; i++) {
			for (int j = result.Count - 1; j > i; j--) {
				if (result[i].getWrittenAt () < result[j].getWrittenAt ()) {
					WrittenWordSerialized aux = result [i];
					result [i] = result [j];
					result [j] = aux;
				}
			}
		}

		result.Reverse ();
		
		//Print test
		/*foreach (WrittenWordSerialized wws in result) {
			Debug.Log (wws.getWrittenAt ());
		}*/
		
		return result;
	}

	public List<WrittenWordSerialized> GetByStudentLast10 (StudentSerialized ss) {
		List<WrittenWordSerialized> result = new List<WrittenWordSerialized> ();
		/*try {
			List<WrittenWordSerialized> orderedByWrittenAt = new List<WrittenWordSerialized> ();

			List<WrittenWordSerialized> wwsList = LoadAll ();// LoadFile ();
			foreach (WrittenWordSerialized wws in wwsList) {
				if (ss != null &&
				    wws != null && 
				    wws.getStudentSerialized (dataPersistencePath) != null && 
				    wws.getStudentSerialized (dataPersistencePath).Id == ss.Id) {

					orderedByWrittenAt.Add (wws);
				}
			}

			//Order by date ascendent
			for (int i = 0; i < orderedByWrittenAt.Count - 1; i++) {
				for (int j = orderedByWrittenAt.Count - 1; j > i; j--) {
					if (orderedByWrittenAt[i].getWrittenAt () > orderedByWrittenAt[j].getWrittenAt ()) {
						WrittenWordSerialized aux = orderedByWrittenAt [i];
						orderedByWrittenAt [i] = orderedByWrittenAt [j];
						orderedByWrittenAt [j] = aux;
					}
				}
			}

			//Get last ten
			if (orderedByWrittenAt.Count > 10) {
				int counting10 = 0;
				for (int i = orderedByWrittenAt.Count -1; i > 0; i--) {
					counting10 ++;
					result.Add (orderedByWrittenAt[i]);
					if (counting10 == 10)
						break;
				}
			} else {
				result = orderedByWrittenAt;
			}

			//Print test
			/*foreach (WrittenWordSerialized wws in result) {
				Debug.Log (wws.getWrittenAt ());
			}
		}catch (System.Exception e) {
			Debug.Log (e);
		}*/
		return result;
	}

}
