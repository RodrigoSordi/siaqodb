using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ChallengeSummarySerializedDAO : SerializedDAO<ChallengeSummarySerialized> {

	public ChallengeSummarySerializedDAO () {}

	public List<ChallengeSummarySerialized> LoadByStudentAndEtapa(StudentSerialized ss, string etapa){
		List<ChallengeSummarySerialized> result = new List<ChallengeSummarySerialized> ();
		
		/*List<ChallengeSummarySerialized> cosList = LoadAll ();// LoadFile ();
		if (cosList != null && cosList.Count > 0) {
			foreach(ChallengeSummarySerialized css in cosList){
				if(ss != null && 
				   css != null && 
				   css.getStudentSerialized (dataPersistencePath) != null && 
				   css.getStudentSerialized (dataPersistencePath).Id == ss.Id && 
				   css.getEtapa () != null && 
				   css.getEtapa ().Equals (etapa)){
					result.Add (css);
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

	public void SaveChallengeFromMotoCat (SchoolSerialized schoolSerialized,
										  StudentSerialized studentSerialized,
	                                      int asserts,
	                                      string challenge, 
	                                      string etapa,
	                                      long totalTime) {
		/*new Thread (() => {
			ChallengeSummarySerialized css = null;

			foreach (ChallengeSummarySerialized tmp in LoadByStudentAndEtapa (studentSerialized, etapa)) {
				if (tmp.getEtapaChallenge ().Equals (challenge)) {
					css = tmp;
				}
			}

			if (css == null)
				css = new ChallengeSummarySerialized ();

			int timesPlayed = css.getTimesPlayed () + 1;
			css.setTimesPlayed (timesPlayed);

			css.setAsserts (css.getAsserts () + asserts);
			css.setEtapa (etapa);
			css.setEtapaChallenge (challenge);
			css.setMinigame ("MOTOCAT");
			css.setTotalTime (css.getTotalTime () + totalTime);
			css.setSchoolSerialized (schoolSerialized);
			css.setStudentSerialized (studentSerialized);

			float assertsPercentage = (float)(100 * css.getAsserts () / css.getTimesPlayed ());
			css.setAssertsPercentage (assertsPercentage);

			SaveOrUpdate (css);
			Debug.Log (css);
		}).Start ();*/
	}

}
