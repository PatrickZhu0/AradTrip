using System;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001989 RID: 6537
public class InstituteTabItem : MonoBehaviour
{
	// Token: 0x0600FE2D RID: 65069 RVA: 0x0046456C File Offset: 0x0046296C
	public void InitTab(InstituteTable data, Action<InstituteTable> clickCallBack)
	{
		MissionManager.SingleMissionInfo missionInfo = DataManager<MissionManager>.GetInstance().GetMissionInfo((uint)data.MissionID);
		if (missionInfo != null)
		{
			this.haveAward.CustomActive(missionInfo.status == 2);
			this.lockState.CustomActive(missionInfo.status == 1);
		}
		this.title.text = data.Title;
		this.btn.onClick.RemoveAllListeners();
		this.btn.onClick.AddListener(delegate()
		{
			if (clickCallBack != null)
			{
				clickCallBack(data);
			}
		});
	}

	// Token: 0x0400A046 RID: 41030
	public GameObject haveAward;

	// Token: 0x0400A047 RID: 41031
	public GameObject lockState;

	// Token: 0x0400A048 RID: 41032
	public Text title;

	// Token: 0x0400A049 RID: 41033
	public Button btn;
}
