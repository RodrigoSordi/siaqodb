using UnityEngine;
using System.Collections;

public class NoteDAO : ParseDAO<Note> {

	public NoteDAO () {
		LIMIT = 100;
	}

}
