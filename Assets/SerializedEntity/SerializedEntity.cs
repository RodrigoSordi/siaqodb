using UnityEngine;
using System.Collections;
using System;

public class SerializedEntity {
	public int OID { get; set; }

	public string ObjectId { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }

	public bool Updated = false;

	public override string ToString ()
	{
		return string.Format ("[SerializedEntity: OID={0}, ObjectId={1}, CreatedAt={2}, UpdatedAt={3}]", OID, ObjectId, CreatedAt, UpdatedAt);
	}

}
