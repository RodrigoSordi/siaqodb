using UnityEngine;
using System.Collections;

public class StudentGroupDAO : ParseDAO <StudentGroup>{

	public StudentGroupDAO () {
		LIMIT = 200;
	}

}
