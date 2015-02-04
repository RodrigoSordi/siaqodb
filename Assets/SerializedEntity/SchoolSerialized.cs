using UnityEngine;
using System.Collections;
using System;

public class SchoolSerialized : SerializedEntity{

	public static readonly string DEFAULT_SCHOOL = "DEFAULT_SCHOOL";

	public string CoordinatorCode { get; set; }
	public string Name { get; set; }
	public string PublicId { get; set; }
	public string SyncCode { get; set; }

	public string lastSyncDate;

	public SchoolSerialized (){}

	public SchoolSerialized (string coordinatorCode, string name, string publicId, string syncCode)
	{
		this.CoordinatorCode = coordinatorCode;
		this.Name = name;
		this.PublicId = publicId;
		this.SyncCode = syncCode;
	}

	public SchoolSerialized (School s){
		base.ObjectId = s.ObjectId;

		this.CoordinatorCode = s.CoordinatorCode;
		this.Name = s.Name;
		this.PublicId = s.PublicId;
		this.SyncCode = s.SyncCode;
	}

	public override string ToString ()
	{
		return string.Format (base.ToString () + "[SchoolSerialized: CoordinatorCode={0}, Name={1}, PublicId={2}, SyncCode={3}]", CoordinatorCode, Name, PublicId, SyncCode);
	}

}
