using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using Parse;
using System;

public class TeacherDAO : ParseDAO <Teacher> {

	public TeacherDAO () {
		LIMIT = 100;
	}

}
