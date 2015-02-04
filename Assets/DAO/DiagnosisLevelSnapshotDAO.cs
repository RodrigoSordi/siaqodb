using UnityEngine;
using System.Collections;

public class DiagnosisLevelSnapshotDAO : ParseDAO <DiagnosisLevelSnapshot>{

	public DiagnosisLevelSnapshotDAO () {
		LIMIT = 1000;
	}
}
