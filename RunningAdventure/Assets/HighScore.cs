using NCMB;
using System.Collections.Generic;
using UnityEngine;

namespace NCMB
{
	public class HighScore
	{
		private string DEFAULT_NAME = "__YOU__";
		public int score   { get; set; }
		public string name { get; set; }
		public string uuid { get; private set; }
		
		// コンストラクタ -----------------------------------
		public HighScore(int _score, string _name, string _uuid)
		{
			score = _score;
			name = _name;
			uuid  = _uuid;
		}
		
		// サーバーにハイスコアを保存 -------------------------
		public void save()
		{
			#if true
			NCMBObject obj = new NCMBObject("HighScore");
			obj["Uuid"]  = uuid;
			obj["Name"]  = name;
			obj["Score"] = score;
			obj.SaveAsync();
			#else
			// データストアの「HighScore」クラスから、Nameをキーにして検索
			NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
			query.WhereEqualTo ("Uuid", uuid);
			query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
				
				//検索成功したら    
				if (e == null) {
					objList[0]["Score"] = score;
					objList[0]["Uuid"] = uuid;
					objList[0]["Name"] = name;
					objList[0].SaveAsync();
				}
			});
			#endif
		}
		
		// サーバーからハイスコアを取得  -----------------
		public void fetch()
		{
			// データストアの「HighScore」クラスから、Nameをキーにして検索
			NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
			query.WhereEqualTo ("Uuid", uuid);
			query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
				
				//検索成功したら  
				if (e == null) {
					// ハイスコアが未登録だったら
					if( objList.Count == 0 )
					{
						NCMBObject obj = new NCMBObject("HighScore");
						obj["Uuid"]  = uuid;
						obj["Name"]  = name;
						obj["Score"] = 0;
						obj.SaveAsync();
						score = 0;
					} 
					// ハイスコアが登録済みだったら
					else {
						score = System.Convert.ToInt32( objList[0]["Score"] ); 
					}
				}
			});
		}
		
		// ランキングで表示するために文字列を整形 -----------
		public string print()
		{
			string savedUuid = PlayerPrefs.GetString("Uuid", "__UNDEFINED__");
			string savedName = PlayerPrefs.GetString("Name", "__UNDEFINED__");
			string nameToShow = DEFAULT_NAME;
			if (savedUuid == uuid) nameToShow = savedName;
			else if(savedName != name) nameToShow = name;
			else if (savedName != "__UNDEFINED__") nameToShow = savedName;
			else if (savedUuid != "__UNDEFINED__") nameToShow = savedUuid;
			if (nameToShow.Length > 13) nameToShow = nameToShow.Remove (12);
			Debug.Log ("savedUuid:" + savedUuid + " uuid:" + uuid + " name:" + savedName
			           + " nameToShow:" +nameToShow + "(" +nameToShow.Length +")");
			return nameToShow + ' ' + score;
		}
		
	}
	
}
