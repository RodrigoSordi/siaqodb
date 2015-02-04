using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using System.Threading.Tasks;
using System;

public class SchoolDAO : ParseDAO<School> {
	
	public Task LoadBySyncCode(string syncCode){
		Debug.Log ("Loading School");

		result = new List<School>();
		
		var query = new ParseQuery<School> ().WhereEqualTo("sync_code", syncCode); 
		//var query = ParseObject.GetQuery("School").WhereEqualTo("sync_code", syncCode);
		Task loading = query.FindAsync().ContinueWith(task => {
			try{
				IEnumerable<School> pos = task.Result;
				
				foreach(ParseObject po in pos){
					School s = new School(po);
					result.Add(s);
					//Print result
					Debug.Log ("Parse Loaded in list: " + s);
				}
				
				if(result.Count == 0)
					Debug.Log ("Parse There is no School with that SyncCode!");
				
				if(task.IsFaulted)
					Debug.Log ("Parse Faulted: " + task.Exception);
				
			}catch(Exception e){
				if (GameController.parseExceptions == null)
					GameController.parseExceptions = new List<Exception> ();
				GameController.parseExceptions.Add (e);
			}
		});
		
		return loading;
	}
	
}
