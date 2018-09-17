////////////////////////////////////
//製作者　関根明良
//クラス  シーン遷移時のフェードクラス
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

/// <summary>
/// シーン遷移時のフェードクラス
/// </summary>
public class Fade : MonoBehaviour
{
	//Image fadePanel;
	
	//float fadeSpeed = 0.02f;

	//private static float alpha = 1.0f;

	//[HideInInspector]
	//public bool isFade = false;

	///// <summary>
	///// フェードイン
	///// </summary>
	//public void FadeIn()
	//{
	//	alpha -= fadeSpeed;

	//	if(alpha<=0.0f)
	//	{
	//		isFade = false;
	//	}
	//	fadePanel.color = new Color(0.0f, 0.0f, 0.0f, alpha);
	//}

	///// <summary>
	///// フェードアウト
	///// </summary>
	//public void FadeOut()
	//{

	//}

	///// <summary>
	///// 不透明度を0に設定
	///// </summary>
	//public void AlphaZero()
	//{
	//	alpha = 0.0f;
	//}

	///// <summary>
	///// 不透明度を1に設定
	///// </summary>
	//public void AlphaOne()
	//{
	//	alpha = 1.0f;
	//}

	//[CustomEditor(typeof(Fade))]
	//public class FadeEditor : Editor
	//{
	//	public override void OnInspectorGUI()
	//	{
	//		base.OnInspectorGUI();

	//		Fade fade = target as Fade;

	//		fade.fadePanel = EditorGUILayout.ObjectField("フェードに使用するパネル", fade.fadePanel, typeof(Image), true) as Image;

	//		fade.fadeSpeed = EditorGUILayout.FloatField("フェードする速度", fade.fadeSpeed);
	//	}
	//}
}