using UnityEngine;
using System.Collections;

public class StudentDAO : ParseDAO <Student> {

	public StudentDAO () {
		LIMIT = 1000;
	}

}
