using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001AA0 RID: 6816
internal class ComSkillTreeEle : MonoBehaviour
{
	// Token: 0x17001D5B RID: 7515
	// (get) Token: 0x06010BB2 RID: 68530 RVA: 0x004BEA71 File Offset: 0x004BCE71
	// (set) Token: 0x06010BB3 RID: 68531 RVA: 0x004BEA79 File Offset: 0x004BCE79
	public RectTransform mrt
	{
		get
		{
			return this.rt;
		}
		set
		{
			this.rt = value;
		}
	}

	// Token: 0x06010BB4 RID: 68532 RVA: 0x004BEA82 File Offset: 0x004BCE82
	private void Start()
	{
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnEquipOrDropSkill, new ClientEventSystem.UIEventHandler(this.OnListenerSkillEquipOrDrop));
	}

	// Token: 0x06010BB5 RID: 68533 RVA: 0x004BEA9F File Offset: 0x004BCE9F
	private void OnDestroy()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnEquipOrDropSkill, new ClientEventSystem.UIEventHandler(this.OnListenerSkillEquipOrDrop));
	}

	// Token: 0x06010BB6 RID: 68534 RVA: 0x004BEABC File Offset: 0x004BCEBC
	private void OnListenerSkillEquipOrDrop(UIEvent uiEvent)
	{
		ushort num = (ushort)uiEvent.Param1;
		bool bActive = (bool)uiEvent.Param2;
		if (this.DragMe != null && this.DragMe.Id == num)
		{
			this.SkillAllocate.CustomActive(bActive);
		}
	}

	// Token: 0x0400AB11 RID: 43793
	public Toggle SkillToggle;

	// Token: 0x0400AB12 RID: 43794
	public Text Skilllevel;

	// Token: 0x0400AB13 RID: 43795
	public Text SkillAddlevel;

	// Token: 0x0400AB14 RID: 43796
	public Image SkillIcon;

	// Token: 0x0400AB15 RID: 43797
	public Image SkillLvUp;

	// Token: 0x0400AB16 RID: 43798
	public Text SkillNames;

	// Token: 0x0400AB17 RID: 43799
	public Image SkillAllocate;

	// Token: 0x0400AB18 RID: 43800
	public Image redpoint;

	// Token: 0x0400AB19 RID: 43801
	public Image NewIcon;

	// Token: 0x0400AB1A RID: 43802
	public Text CanLearn;

	// Token: 0x0400AB1B RID: 43803
	public Text AwakeText;

	// Token: 0x0400AB1C RID: 43804
	public Image PvPForbidImg;

	// Token: 0x0400AB1D RID: 43805
	public GameObject SkillInfoGo;

	// Token: 0x0400AB1E RID: 43806
	public int iPanelIndex;

	// Token: 0x0400AB1F RID: 43807
	public Drag_Me DragMe;

	// Token: 0x0400AB20 RID: 43808
	private RectTransform rt;
}
