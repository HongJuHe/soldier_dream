using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explain_second : MonoBehaviour {

	public GUIText gexplain;
	public GUIText clicktext;
	List<string> texts;
	
	private int index = 0;
	
	// Use this for initialization
	void Start () {
		texts = new List<string>();
		gexplain.text = "<고대 병사 정령과의 전투>";
		clicktext.text = "클릭하여 다음으로 넘어가세요";
		texts.Add("늙은 병사의 두 번째 꿈 속입니다.\n정령을 피해 던전을 찾아서 꿈을 빠져나오세요.");
		texts.Add ( "전보다 속도가 훨씬 빨라집니다.\n F키를 누르면 한번 목숨을 얻을 수 있습니다. \n스페이스바를 눌러 점프하세요.");
		texts.Add ("무사히 통과하시길 빕니다. \n참고로 공격이 불가능합니다. \n시작합니다.");
	}
	
	// Update is called once per frame
	void Update () {
		int button = 0;
		if (Input.GetMouseButtonDown (button)) {
			if (index <= 2) {
				gexplain.text = texts [index];
				Debug.Log(index.ToString());
				index++;
			} else {
				Application.LoadLevel ("main2");
			}
		}
	}
}
