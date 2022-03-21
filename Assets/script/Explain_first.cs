using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explain_first : MonoBehaviour {

	public GUIText gexplain;
	public GUIText clicktext;
	List<string> texts;

	private int index = 0;

	// Use this for initialization
	void Start () {
		texts = new List<string>();
		gexplain.text = "<환각의 숲: 영혼의 말소리>";
		clicktext.text = "클릭하여 다음으로 넘어가세요";
		texts.Add("늙은 병사의 첫 번째 꿈 속입니다.\n제한 시간 안에 던전을 찾아서 꿈을 빠져나오세요.");
		texts.Add ( "X키를 길게 눌러 나무를 잘라보세요.\n F키를 눌러 힘을 얻으세요. \n 스페이스바를 눌러 점프하세요.");
		texts.Add ("무사히 통과하시길 빕니다. \n시작합니다.");
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
								Application.LoadLevel ("main");
						}
				}
	}
}
