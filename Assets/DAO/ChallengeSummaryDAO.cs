using UnityEngine;
using System.Collections;

public class ChallengeSummaryDAO : ParseDAO <ChallengeSummary> {

	public ChallengeSummaryDAO () {
		LIMIT = 1000;
	}

}
