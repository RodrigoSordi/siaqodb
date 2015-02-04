using UnityEngine;
using System.Collections;

public class WeekSummaryDAO : ParseDAO<WeekSummary> {

	public WeekSummaryDAO () {
		LIMIT = 200;
	}

}
