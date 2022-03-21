using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explain_third : MonoBehaviour {

	public GUIText gexplain;
	public GUIText clicktext;
	List<string> texts;
	
	private int index = 0;
	
	// Use this for initialization
	void Start () {
		texts = new List<string>();
		gexplain.text = "<자신과의 싸움>";
		clicktext.text = "클릭하여 다음으로 넘어가세요";
		texts.Add("늙은 병사의 세 번째 꿈 속입니다.\nX를 길게 눌러 공격하세요.");
		texts.Add ("무사히 통과하시길 빕니다. \n시작합니다.");
	}
	
	// Update is called once per frame
	void Update () {
		int button = 0;
		if (Input.GetMouseButtonDown (button)) {
			if (index <= 1) {
				gexplain.text = texts [index];
				Debug.Log(index.ToString());
				index++;
			} else {
				Application.LoadLevel ("escapeknight");
			}
		}
	}
}
