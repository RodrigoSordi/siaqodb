using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class WrittenWordSerialized : SerializedEntity {

	public static readonly string SWIPE = "SWIPE";
	public static readonly string DRAG = "DRAG";
	public static readonly string EMPTY = "EMPTY";
	public static readonly string TAP = "TAP";

	public string DiagnosisLevel { get; set; }
	public string Expected { get; set; }
	public string Gesture { get; set; }
	public string Input { get; set; }
	public SchoolSerialized SchoolSerialized { get; set; }
	public StudentSerialized StudentSerialized { get; set; }
	public long WrittenAt { get; set; }

	public WrittenWordSerialized () {}

	public WrittenWordSerialized (string diagnosisLevel, string expected, string gesture, string input, SchoolSerialized schoolSerialized, StudentSerialized studentSerialized, long writtenAt)
	{
		this.DiagnosisLevel = diagnosisLevel;
		this.Expected = expected;
		this.Gesture = gesture;
		this.Input = input;
		this.SchoolSerialized = schoolSerialized;
		this.StudentSerialized = studentSerialized;
		this.WrittenAt = writtenAt;
	}
	
	public WrittenWordSerialized (WrittenWord ww)
	{
		base.ObjectId = ww.ObjectId;
		base.CreatedAt = ww.CreatedAt;
		base.UpdatedAt = ww.UpdatedAt;
		//base.Id = 0;

		this.DiagnosisLevel = ww.DiagnosisLevel;
		this.Expected = ww.Expected;
		this.Gesture = ww.Gesture;
		this.Input = ww.Input;
		this.WrittenAt = ww.WrittenAt;
		
		if (ww.School != null){
			SchoolSerialized ss = new SchoolSerializedDAO ().LoadByObjectId (ww.School.ObjectId);
			if (ss != null)
				this.SchoolSerialized = ss;
			else
				Debug.Log ("Serialized: There is no relationship saved");
		}
		
		if (ww.Student != null) {
			StudentSerialized ss = new StudentSerializedDAO ().LoadByObjectId (ww.Student.ObjectId);
			if (ss != null)
				this.StudentSerialized = ss;
			else
				Debug.Log ("Serialized: There is no relationship saved");
		}
	}


	public List<string> GetGesturesAsList () {
		string [] acts = null;

		if (Gesture != null && Gesture.Contains (" "))
			    acts = Gesture.Split (' ');

		if (acts == null)
			acts = new string[] {Gesture};
		
		List<string> result = new List<string> ();
		if (acts != null && acts.Length > 0) {
			foreach (string s in acts) {
				result.Add (s);
			}
		}

		return result;
	}
	
	public void setGesture(List<string> gestures) {
		if (gestures != null && gestures.Count > 0) {
			foreach (string s in gestures) {
				if (!s.Contains (":") || s.Split(':').Length > 2)
					throw new Exception ("Parameters must have \"one\" character \":\"");
				
				if (s.Contains (" "))
					throw new Exception ("Parameters must not have black spaces!");
				
				this.Gesture += " " + s;
				this.Gesture = this.Gesture.Trim();
			}
		}
	}

	public override string ToString ()
	{
		return string.Format ("[WrittenWordSerialized: DiagnosisLevel={0}, Expected={1}, Gesture={2}, Input={3}, SchoolSerialized={4}, StudentSerialized={5}, WrittenAt={6}]", DiagnosisLevel, Expected, Gesture, Input, SchoolSerialized, StudentSerialized, WrittenAt);
	}
	
}
