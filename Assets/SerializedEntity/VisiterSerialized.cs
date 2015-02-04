using UnityEngine;
using System.Collections;
using System;
using Parse;

public class VisiterSerialized : SerializedEntity {

	private long buildingsCount { get; set; }
	private long coins { get; set; }
	private string diagnosisLevel { get; set; }
	private string name { get; set; }
	
	public VisiterSerialized (){}
	
	public VisiterSerialized (long buildingsCount, long coins, string diagnosisLevel, string name)
	{
		this.buildingsCount = buildingsCount;
		this.coins = coins;
		this.diagnosisLevel = diagnosisLevel;
		this.name = name;
	}

	public long getBuildingsCount() {
		return buildingsCount;
	}
	public void setBuildingsCount(long buildingsCount) {
		this.buildingsCount = buildingsCount;
	}
	public long getCoins() {
		return coins;
	}
	public void setCoins(long coins) {
		this.coins = coins;
	}
	public string getDiagnosisLevel() {
		return diagnosisLevel;
	}
	public void setDiagnosisLevel(string diagnosisLevel) {
		this.diagnosisLevel = diagnosisLevel;
	}
	public string getName() {
		return name;
	}
	public void setName(string name) {
		this.name = name;
	}

	public override string ToString ()
	{
		return string.Format ("[VisitingSerialized: buildingsCount={0}, coins={1}, diagnosisLevel={2}, name={3}]", buildingsCount, coins, diagnosisLevel, name);
	}
	
}
