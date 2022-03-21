using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class badending : MonoBehaviour {

	public GUIText gexplain;
	public GUIText title;

	private string write_text = "";
	private string text = "늙은 병사는 굽혀진 허리를 피지 못한 채 그대로 쓰러졌다.\n더 이상 그의 눈에는 어떠한 생기도 띄지 않았다.\n그는 인생을 왕국에 바쳤지만 그에게 남은 것은 없었고\n지금까지의 공로가 무색할 만큼 금세 잊혀졌다.";

	// Use this for initialization
	void Start () {
		title.text = "<베드 엔딩>";
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
