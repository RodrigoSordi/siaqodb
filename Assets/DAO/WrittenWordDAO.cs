using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

public class WrittenWordDAO : ParseDAO<WrittenWord> {
	//public static List<List<WrittenWord>> result;

	public WrittenWordDAO () {
		base.LIMIT = 1000;
	}

	/*[Obsolete("You shouldn't use this method for this class.", true)]
	public Task LoadBySchool (School s, string orderedBy) {
		return null;
	}

	public List<Task> LoadByStudents (School s, List<Student> stList, string orderedBy) {
		Debug.Log ("Loading Written Words");

		List<Task> loading = new List<Task> ();
		result = new List<List<WrittenWord>> ();

		foreach (Student st in stList) {
			Debug.Log ("Loading ww by = " + st);
			loading.Add (LoadByStudent (s, st, orderedBy));
		}

		return loading;
	}

	Task LoadByStudent (School s, Student st, string orderedBy) {
		Task loading = null;
		
		var query = new ParseQuery<WrittenWord> ().WhereEqualTo ("school", s).WhereEqualTo("student", st).Limit (LIMIT).OrderBy (orderedBy);
		
		loading = query.FindAsync ().ContinueWith (task => {
			if(!task.IsFaulted){
				try{
					IEnumerable<WrittenWord> pos = task.Result;

					List<WrittenWord> tmp = new List<WrittenWord> ();
					foreach(WrittenWord ww in pos){
						tmp.Add (ww);

						//Debug.Log ("Parse Loaded in list: " + t);
					}

					result.Add (tmp);
					
				}catch(Exception e){
					Debug.Log ("WrittenWord - erro: " + e);
				}
			} else {
				Debug.Log ("WrittenWord - Faulted: " + task.Exception);
			}
		});

		return loading;
	}*/

}

