using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class SchoolSerializedDAO : SerializedDAO<SchoolSerialized> {

	public SchoolSerializedDAO () {}
	public SchoolSerializedDAO (string path) : base (path) {}

}
