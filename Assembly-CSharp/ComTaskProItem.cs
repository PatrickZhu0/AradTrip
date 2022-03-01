using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200151D RID: 5405
internal class ComTaskProItem : MonoBehaviour
{
	// Token: 0x04007B02 RID: 31490
	public uint TaskID;

	// Token: 0x04007B03 RID: 31491
	public Text TaskTitle;

	// Token: 0x04007B04 RID: 31492
	public Text TaskName;

	// Token: 0x04007B05 RID: 31493
	public LinkParse TaskContent;

	// Token: 0x04007B06 RID: 31494
	public List<GameObject> Reward;

	// Token: 0x04007B07 RID: 31495
	public List<Text> RewardNum;

	// Token: 0x04007B08 RID: 31496
	public Button FinishButton;

	// Token: 0x04007B09 RID: 31497
	public Text FinishButtonText;

	// Token: 0x04007B0A RID: 31498
	public Text FinishText;

	// Token: 0x04007B0B RID: 31499
	public GameObject LockObj;
}
