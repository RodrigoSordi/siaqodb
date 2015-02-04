using UnityEngine;
using System.Collections;
using System;
using Parse;

[System.Serializable]
[ParseClassName("School")]
public class School : ParseObject {

	[ParseFieldName("coordinator_code")]
	public string CoordinatorCode { 
		get { return GetProperty<string>("CoordinatorCode");} 
		set { SetProperty<string>(value, "CoordinatorCode");}
	}

	[ParseFieldName("name")]
	public string Name { 
		get{ return GetProperty<string>("Name");} 
		set{ SetProperty<string>(value, "Name");}
	}

	[ParseFieldName("public_id")]
	public string PublicId { 
		get{ return GetProperty<string>("PublicId");} 
		set{ SetProperty<string>(value, "PublicId");} 
	}

	[ParseFieldName("sync_code")]
	public string SyncCode { 
		get{ return GetProperty<string>("SyncCode");} 
		set{ SetProperty<string>(value, "SyncCode");} 
	}

	public School () {}

	public School (ParseObject po)
	{
		this.ObjectId = po.ObjectId;

		if(po.ContainsKey("coordinator_code"))this.CoordinatorCode = po.Get<string> ("coordinator_code");
		if(po.ContainsKey("name"))this.Name = po.Get<string> ("name");
		if(po.ContainsKey("public_id"))this.PublicId = po.Get<string> ("public_id");
		if(po.ContainsKey("sync_code"))this.SyncCode = po.Get<string> ("sync_code");
	}

	public School (string coordinatorCode, string name, string publicId, string syncCode)
	{
		this.CoordinatorCode = coordinatorCode;
		this.Name = name;
		this.PublicId = publicId;
		this.SyncCode = syncCode;
	}

	public override string ToString ()
	{
		return string.Format ("[School: CoordinatorCode={0}, Name={1}, PublicId={2}, SyncCode={3}]", CoordinatorCode, Name, PublicId, SyncCode);
	}
	
}
