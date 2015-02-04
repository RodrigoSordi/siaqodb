using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using GameEntities;
using SiaqodbDemo;
using Sqo;
using System.Collections.Generic;

public class RodrigoTest : MonoBehaviour {

	System.Random random = new System.Random ();
	DateTime dt;

	public UILabel debug;
	public UILabel Qtde;
	public UILabel Index;
	public UIPopupList popup;

	SchoolSerialized school;
	TeacherSerialized ts;
	StudentGroup_TeacherSerialized sg_ts;
	StudentGroupSerialized sgs;
	StudentSerialized ss;

	SchoolSerializedDAO schooldao = new SchoolSerializedDAO ();
	TeacherSerializedDAO tsdao = new TeacherSerializedDAO ();
	StudentGroup_TeacherSerializedDAO sg_tsdao = new StudentGroup_TeacherSerializedDAO ();
	StudentGroupSerializedDAO sgsdao = new StudentGroupSerializedDAO ();
	StudentSerializedDAO ssdao = new StudentSerializedDAO ();

	// Use this for initialization
	void Start () {
		print (DatabaseFactory.siaoqodbPath);
		Qtde.text = "1";
		Index.text = "1";

		/*school = new SchoolSerializedDAO ().LoadLast ();
		List<StudentGroupSerialized> sgsList = new StudentGroupSerializedDAO ().LoadBySchool (school);
		Debug.Log ("sgsList.Count = " + sgsList.Count);
		foreach (StudentGroupSerialized aux in sgsList)
			Debug.Log (aux);*/

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Add () {
		dt = DateTime.Now;

		int value = int.Parse (Qtde.text);

		if (popup.value == "School") {
			for (int i = 0; i < value; i++) {
				school = new SchoolSerialized ("1234", "Escola Marota", "1234", "1234");
				schooldao.SaveOrUpdate (school);
			}
			print (school + GetTimeWated ());
		} else if (popup.value == "Teacher") {
			for (int i = 0; i < value; i++) {
				ts = new TeacherSerialized ("a", "rodsordi@hotmail.com", true, 
				                            "Sordi", "Rodrigo", "1234", "", "a", school);
				tsdao.SaveOrUpdate (ts);
			}
			print (ts + GetTimeWated ());
		} else if (popup.value == "StudentGroup_Teacher") {
			for (int i = 0; i < value; i++) {
				sg_ts = new StudentGroup_TeacherSerialized (school, ts, sgs);
				sg_tsdao.SaveOrUpdate (sg_ts);
			}
			print (sg_ts + GetTimeWated ());
		} else if (popup.value == "StudentGroup") {
			for (int i = 0; i < value; i++) {
				sgs = new StudentGroupSerialized ("Group", "Manha", school, "Serie 1");
				sgsdao.SaveOrUpdate (sgs);
			}
			print (sgs + GetTimeWated ());
		} else if (popup.value == "Student") {
			for (int i = 0; i < value; i++) {
				ss = new StudentSerialized (999999, 1l, 1000l, "", "", "", "Rodrigo", school, sgs, "Sordi");
				ssdao.SaveOrUpdate (ss);
			}
			print (ss + GetTimeWated ());
		}
	}

	public void UpdateItem () {
		dt = DateTime.Now;
		
		if (popup.value == "School") {
			school = new SchoolSerializedDAO ().LoadLast ();
			school.Updated = true;
			school.ObjectId = "1234";
			school.Name = "Escola Atualizada";
			schooldao.SaveOrUpdate (school);
			print ("Updated " + GetTimeWated ());
		}
	}

	public void LoadLast () {
		dt = DateTime.Now;

		if (popup.value == "School") {
			school = schooldao.LoadLast ();
			print (school + GetTimeWated ());
		} else if (popup.value == "Teacher") {
			ts = tsdao.LoadLast ();
			print (ts + GetTimeWated ());
		}else if (popup.value == "StudentGroup_Teacher") {
			sg_ts = sg_tsdao.LoadLast ();
			print (sg_ts + GetTimeWated ());
		}else if (popup.value == "StudentGroup") {
			sgs = sgsdao.LoadLast ();
			print (sgs + GetTimeWated ());
		}else if (popup.value == "Student") {
			ss = ssdao.LoadLast ();
			print (ss + GetTimeWated ());
		}



		/*dt = DateTime.Now;
		int value = int.Parse (Index.text);
		ss = dao.LoadById (value);
		print (ss + GetTimeWated ());


		/*TeacherSerialized ts = new TeacherSerialized ("a", "rodsordi@hotmail.com", true, "Sordi", "Rodrigo", "1234", "", "a", ss);
		tdao.SaveOrUpdate (ts);

		foreach (TeacherSerialized aux in tdao.LoadAll ())
			Debug.Log (aux);*/

	}

	public void LoadAll () {
		dt = DateTime.Now;

		if (popup.value == "School") {
			List <SchoolSerialized> ssList = schooldao.LoadAll ();
			print ("DB contains = " + ssList.Count + " registers." + GetTimeWated ());
		} else if (popup.value == "Teacher") {
			List <TeacherSerialized> tsList = tsdao.LoadAll ();
			print ("DB contains = " + tsList.Count + " registers." + GetTimeWated ());
		} else if (popup.value == "StudentGroup_Teacher") {
			List <StudentGroup_TeacherSerialized> sg_tsList = sg_tsdao.LoadAll ();
			print ("DB contains = " + sg_tsList.Count + " registers." + GetTimeWated ());
		} else if (popup.value == "StudentGroup") {
			List <StudentGroupSerialized> sgsList = sgsdao.LoadAll ();
			print ("DB contains = " + sgsList.Count + " registers." + GetTimeWated ());
		} else if (popup.value == "Student") {
			List <StudentSerialized> ssList = ssdao.LoadAll ();
			print ("DB contains = " + ssList.Count + " registers." + GetTimeWated ());
		}

	}

	public void Delete () {
		dt = DateTime.Now;

		if (popup.value == "School") {
			schooldao.Delete (school);
			print ("Deleted = " + GetTimeWated ());
		} else if (popup.value == "Teacher") {
			tsdao.Delete (ts);
			print ("Deleted = " + GetTimeWated ());
		} else if (popup.value == "StudentGroup_Teacher") {
			tsdao.Delete (sg_ts);
			print ("Deleted = " + GetTimeWated ());
		} else if (popup.value == "StudentGroup") {
			tsdao.Delete (sgs);
			print ("Deleted = " + GetTimeWated ());
		} else if (popup.value == "Student") {
			tsdao.Delete (ss);
			print ("Deleted = " + GetTimeWated ());
		}

	}

	public void DeleteAll () {
		dt = DateTime.Now;

		if (popup.value == "School") {
			schooldao.DeleteAll ();
			print ("Deleted " + GetTimeWated ());
		} else if (popup.value == "Teacher") {
			tsdao.DeleteAll ();
			print ("Deleted " + GetTimeWated ());
		} else if (popup.value == "StudentGroup_Teacher") {
			sg_tsdao.DeleteAll ();
			print ("Deleted " + GetTimeWated ());
		} else if (popup.value == "StudentGroup") {
			sgsdao.DeleteAll ();
			print ("Deleted " + GetTimeWated ());
		} else if (popup.value == "Student") {
			ssdao.DeleteAll ();
			print ("Deleted " + GetTimeWated ());
		}

	}








	public void QtdeLessLess () {
		int value = int.Parse (Qtde.text) - 1;
		if (value > 0)
			Qtde.text = value.ToString ();
	}

	public void QtdePlusPlus () {
		Qtde.text = (int.Parse (Qtde.text) + 1).ToString ();
	}

	public void QtdeLess100 () {
		int value = int.Parse (Qtde.text) - 100;
		if (value > 0)
			Qtde.text = value.ToString ();
	}
	
	public void QtdePlus100 () {
		Qtde.text = (int.Parse (Qtde.text) + 100).ToString ();
	}

	public void IndexLessLess () {
		int value = int.Parse (Index.text) - 1;
		if (value > 0)
			Index.text = value.ToString ();
	}

	public void IndexPlusPlus () {
		Index.text = (int.Parse (Index.text) + 1).ToString ();
	}
	

	 
	new void print (object obj) {
		debug.text = obj.ToString ();
		Debug.Log (obj.ToString ());
	}

	string GetTimeWated () {
		this.dt = new DateTime(DateTime.Now.Ticks - dt.Ticks);
		return " - "  + string.Format ("Levou = {0} min, {1} secs, {2} millis", dt.Minute, dt.Second, dt.Millisecond);
	}

}

class Test {}