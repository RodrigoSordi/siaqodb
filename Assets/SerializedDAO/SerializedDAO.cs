using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Sqo;
using SiaqodbDemo;

public class SerializedDAO <T> where T : SerializedEntity{

	private static readonly int MAX_DATA = 100000;
	public Siaqodb siaqodb;

	public SerializedDAO() {
		siaqodb = DatabaseFactory.GetInstance();
	}

	public SerializedDAO (string s) {

	}

	public void SaveOrUpdate(SerializedEntity se){
		if (se != null) {
			if (se.OID == 0) {
				se.CreatedAt = DateTime.Now;
				siaqodb.StoreObject (se);
			} else {
				se.Updated = true;
				se.UpdatedAt = DateTime.Now;
				siaqodb.StoreObject (se);
			}
		}
	}

	public void SaveList (List<T> tList) {
		foreach (T t in tList)
			SaveOrUpdate (t);
	}

	public void UpdateWithoutSetAsUpdated (SerializedEntity se) {

	}

	public T LoadByObjectId (string objectId) {
		T result = null;
		try {
			var query = (from T t in siaqodb select t);
			result = query.ToList<T> ().Where (t => t.ObjectId == objectId).ToList ()[0];
		} catch {
			return null;
		}
		return result;
	}

	/*public T LoadById (int id) {
		var query = (from T t in siaqodb select t);
		return query.ToList<T> ().Where (t => t.Id == id).ToList ()[0];
	}*/

	public T LoadLast () {
		T result = null;
		try {
			result = (from T t in siaqodb select t).Last<T> ();
		} catch {
			return null;
		}
		return result;
	}

	public List<T> LoadAll () {
		IEnumerable<T> query = (from T t in siaqodb
								orderby t.CreatedAt, t.UpdatedAt ascending
								select t).Take(MAX_DATA);

		return query.ToList<T> ();
	}

	public void Delete (SerializedEntity se) {
		siaqodb.Delete (se);
	}
	

	public void DeleteAll () { 
		List<T> tList = LoadAll ();
		foreach (T t in tList) {
			Delete (t);
		}
	}

	public void DeleteFile () {
		IEnumerable<T> query = (from T t in siaqodb
		                        orderby t.CreatedAt.Value, t.UpdatedAt.Value ascending
		                        select t).Take(100000);

		foreach (T t in query.ToList<T> ()) {
			siaqodb.Delete (t);
		}
	}

	public List <T> LoadByCriteria (Func<T, bool> predicate) {
		var query = (from T t in siaqodb select t);
		return query.ToList<T> ().Where (predicate).ToList ();
	}

}
