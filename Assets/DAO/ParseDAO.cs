using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

public class ParseDAO <T> where T : ParseObject{
	public static List<T> result;
	public int LIMIT;

	//Saving Parse
	public Task SaveOrUpdateParse(T t)
	{
		ParseObject po = t as ParseObject;
		Task loading = null;

		loading = po.SaveAsync ().ContinueWith(task => {
			if(!task.IsFaulted){
				//Debug.Log ("Parse Saved or Updated: " + po);
			}else{
				Debug.Log (Type.GetType(typeof(T).ToString()) + " - " + task.Exception);
				//new ParseDAO <T> ().SaveOrUpdateParse (t);
			}
		});
		
		return loading;
	}

	//Saving List
	public Task SaveOrUpdateList (List<T> list) 
	{
		Task loading = null;

		loading = ParseObject.SaveAllAsync<T> (list).ContinueWith(task => {
			if(!task.IsFaulted){
				//Debug.Log ("Parse Saved or Updated: " + po);
			}else{
				Debug.Log (Type.GetType(typeof(T).ToString()) + " - " + task.Exception);
				//new ParseDAO <T> ().SaveOrUpdateList (list);
			}
		});
		
		return loading;
	}

	
	//Deleting Parse
	public Task DeleteParse(T t)
	{
		ParseObject po = t as ParseObject;
		Task loading = null;

		loading = po.DeleteAsync ().ContinueWith (task => {
			if(!task.IsFaulted){
				//Debug.Log ("Parse Deleted: " + po);
			}else{
				//Debug.Log (Type.GetType(typeof(T).ToString()) + " - Tentando novamente! " + task.Exception);
				//new ParseDAO <T> ().DeleteParse (t);
			}
		});
		
		return loading;
	}
	
	
	//Loading Parse
	public Task LoadByIdParse(string objectId)
	{
		//var query = ParseObject.GetQuery(typeof(T).ToString());
		var query = new ParseQuery<T> ();
		Task loading = null;

		loading = query.GetAsync(objectId.ToString()).ContinueWith(task => {
			if(!task.IsFaulted){
				try
				{
					result = new List<T> ();
					
					ParseObject po = task.Result;
					T t = Activator.CreateInstance (Type.GetType(typeof(T).ToString()), new object[] {po}) as T;
					
					result.Add(t);
					
					//Print result
					//Debug.Log ("Parse Loaded: " + t);
				}
				catch
				{
					/*if (GameController.parseExceptions == null)
						GameController.parseExceptions = new List<Exception> ();
					GameController.parseExceptions.Add (e);*/
				}
			}else{
				//Debug.Log (Type.GetType(typeof(T).ToString()) + " - Tentando novamente! " + task.Exception);
				//new ParseDAO <T> ().LoadByIdParse (objectId);
			}
		});
		
		return loading;
	}
	
	//Load All Parse
	public Task LoadAllParse()
	{
		//var query = ParseObject.GetQuery (typeof(T).ToString());
		var query = new ParseQuery<T>();
		Task loading = null;

		loading = query.FindAsync ().ContinueWith (task => {
			if(!task.IsFaulted){
				result = new List<T>();

				IEnumerable<T> pos = task.Result;
				
				foreach(ParseObject po in pos)
				{
					T t = Activator.CreateInstance (Type.GetType(typeof(T).ToString()), new object[] {po}) as T;
					result.Add(t);
					
					//Print result
					//Debug.Log ("Parse Loaded in list: " + t);
				}
				
				if(result.Count == 0)
				{
					Debug.Log ("Parse There is no saved data");
				}
				
				if(task.IsFaulted)
				{
					Debug.Log ("Parse Faulted: " + task.Exception);
				}
			} else {
				//Debug.Log (Type.GetType(typeof(T).ToString()) + " - Tentando novamente! " + task.Exception);
				//new ParseDAO <T> ().LoadAllParse ();
			}
		});
		
		return loading;
	}
	
	public Task LoadBySchool (School s, string orderedBy) {
		Debug.Log ("Loading " + Type.GetType (typeof(T).ToString ()) + "s");

		var query = new ParseQuery<T> ().WhereEqualTo ("school", s).Limit (LIMIT).OrderByDescending (orderedBy);
		Task loading = null;

		loading = query.FindAsync ().ContinueWith (task => {
			if(!task.IsFaulted){
				try{
					result = new List<T> ();

					IEnumerable<T> pos = task.Result;
					if (pos == null)
						pos = new List<T>();
					
					foreach(ParseObject po in pos){
						T t = Activator.CreateInstance (Type.GetType(typeof(T).ToString()), new object [] {po}) as T;
						result.Add (t);

						//Debug.Log ("Parse Loaded in list: " + t);
					}
					
				}catch(Exception e){
					Debug.Log (Type.GetType(typeof(T).ToString()) + " - erro: " + e);
				}
			} else {
				Debug.Log (Type.GetType(typeof(T).ToString()) + " - erro: " + task.Exception);
			}
		});
		return loading;
	}
	
}
