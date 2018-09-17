////////////////////////////////////
//製作者　関根明良
//クラス　ボタン処理クラス
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	[SerializeField]
	GameObject panel;

	[SerializeField]
	AudioSource decision;

	bool decPlaying = false;

	[SerializeField]
	AudioSource cancel;

	bool cancelPlaying = false;

	private void Update()
	{
		if (decision != null)
		{
			if (decPlaying && !decision.isPlaying)
				ToGameScene();
		}
		if (cancel != null)
		{
			if (cancelPlaying && !cancel.isPlaying)
				SceneTransition("StageSelect");
		}
	}

	/// <summary>
	/// シーン遷移
	/// </summary>
	public void SceneTransition(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	/// <summary>
	/// メインシーンへの遷移
	/// </summary>
	/// <param name="stageNum">遷移先のステージ番号</param>
	public void ToGameScene()
	{
		SceneManager.LoadScene("Game");
	}

	public void SwitchPanel(string stageName)
	{
		panel.SetActive(!panel.activeSelf);

		ReadPlayerPref.SetStringKey("PlayingStage", stageName);
	}

	public void PlayDecision()
	{
		decision.PlayOneShot(decision.clip);
		decPlaying = true;
	}

	public void PlayCancel()
	{
		cancel.PlayOneShot(cancel.clip);
		cancelPlaying = true;
	}
}
