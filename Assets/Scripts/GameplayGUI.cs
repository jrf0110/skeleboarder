using UnityEngine;
using System.Collections;

public class GameplayGUI : MonoBehaviour {
	
	public tk2dUIItem exitBtn;
	public tk2dUIItem deadExitBtn;
	public tk2dUIItem resetLevelBtn;
	public tk2dUIItem nextLevelBtn;

	
//	public tk2dUIItem thisDeadExitBtn;
//	public tk2dUIItem thisResetLevelBtn;
//	public tk2dUIItem thisNextLevelBtn;


	void Start()
	{
//		thisDeadExitBtn = GameObject.FindGameObjectWithTag ("MenuBtn").GetComponent<tk2dUIItem>();
//		thisResetLevelBtn = GameObject.FindGameObjectWithTag ("RestartLevelBtn").GetComponent<tk2dUIItem>();
//		thisNextLevelBtn = GameObject.FindGameObjectWithTag ("NextLevelBtn").GetComponent<tk2dUIItem>();

	}

	void OnEnable()
	{
		if (exitBtn) {exitBtn.OnClick += LoadTitleScreen;}
//		if (thisDeadExitBtn) {thisDeadExitBtn.OnClick += LoadTitleScreen;}
//		if (thisResetLevelBtn) {thisResetLevelBtn.OnClick += ResetLevel;}
//		if (thisNextLevelBtn) {thisNextLevelBtn.OnClick += NextLevel;}

		if (deadExitBtn) {deadExitBtn.OnClick += LoadTitleScreen;}
		if (resetLevelBtn) {resetLevelBtn.OnClick += ResetLevel;}
		if (nextLevelBtn) {nextLevelBtn.OnClick += NextLevel;}
	}


	private void LoadTitleScreen()
	{
		Application.LoadLevel("TitleScreen");
	}

	private void NextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	private void ResetLevel()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}
}
