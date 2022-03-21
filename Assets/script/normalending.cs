using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class normalending : MonoBehaviour {
	
	public GUIText gexplain;
	public GUIText title;
	
	private string write_text = "";
	private string text = "늙은 병사는 깊은 잠에서 깨어났다.\n그는 성치 않은 몸을 이끌고 힘겹게 문을 열었다.\n햇살 아래로 전쟁 폐허 속에서 아이들이 뛰어놀고 있었다.\n그리고 그의 입가에는 미소가 번졌다.";
	
	// Use this for initialization
	void Start () {
		title.text = "<노멀 엔딩>";
		StartCoroutine (textending());
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	IEnumerator ending()
	{
		write_text = "";
		//yield return new WaitForSeconds (1f);
		for(int i=0; i<text.Length;i++)
		{
			write_text += text[i];
			gexplain.text = write_text;
			yield return new WaitForSeconds(0.15f);
		}
	}
	
	IEnumerator textending()
	{
		yield return StartCoroutine (ending ());
	}
}
