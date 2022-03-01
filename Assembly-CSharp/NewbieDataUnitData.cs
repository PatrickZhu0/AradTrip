using System;

// Token: 0x0200101A RID: 4122
[Serializable]
public struct NewbieDataUnitData
{
	// Token: 0x06009C5A RID: 40026 RVA: 0x001E8B00 File Offset: 0x001E6F00
	public NewbieDataUnitData(string name = null)
	{
		this.stepName = name;
		this.type = NewbieGuideComType.NULL;
		this.modifyData = null;
		this.buttonGuide = null;
		this.coverGuide = null;
		this.etcButtonGuide = null;
		this.etcJoystickGuide = null;
		this.introductionGuide = null;
		this.introduction2Guide = null;
		this.newiconUnlockGuide = null;
		this.passThroughGuide = null;
		this.stressGuide = null;
		this.talkDialogGuide = null;
		this.waitGuide = null;
		this.playEffectGuide = null;
	}

	// Token: 0x06009C5B RID: 40027 RVA: 0x001E8B78 File Offset: 0x001E6F78
	private void ClearData()
	{
		this.buttonGuide = null;
		this.coverGuide = null;
		this.etcButtonGuide = null;
		this.etcJoystickGuide = null;
		this.introductionGuide = null;
		this.introduction2Guide = null;
		this.newiconUnlockGuide = null;
		this.passThroughGuide = null;
		this.stressGuide = null;
		this.talkDialogGuide = null;
		this.waitGuide = null;
		this.playEffectGuide = null;
	}

	// Token: 0x06009C5C RID: 40028 RVA: 0x001E8BDC File Offset: 0x001E6FDC
	private IUnitData SetType(NewbieGuideComType type)
	{
		this.ClearData();
		switch (type)
		{
		case NewbieGuideComType.BUTTON:
		case NewbieGuideComType.TOGGLE:
			this.buttonGuide = new GuideButton();
			return this.buttonGuide;
		case NewbieGuideComType.ETC_BUTTON:
			this.etcButtonGuide = new GuideETCButton();
			return this.etcButtonGuide;
		case NewbieGuideComType.ETC_JOYSTICK:
			this.etcJoystickGuide = new GuideETCJoystick();
			return this.etcJoystickGuide;
		case NewbieGuideComType.TALK_DIALOG:
			this.talkDialogGuide = new GuideTalkDialog();
			return this.talkDialogGuide;
		case NewbieGuideComType.WAIT:
			this.waitGuide = new GuideWait();
			return this.waitGuide;
		case NewbieGuideComType.INTRODUCTION:
			this.introductionGuide = new GuideIntroduction();
			return this.introductionGuide;
		case NewbieGuideComType.INTRODUCTION2:
			this.introduction2Guide = new GuideIntroduction2();
			return this.introduction2Guide;
		case NewbieGuideComType.COVER:
			this.coverGuide = new GuideCover();
			return this.coverGuide;
		case NewbieGuideComType.PASS_THROUGH:
			this.passThroughGuide = new GuidePassThrough();
			return this.passThroughGuide;
		case NewbieGuideComType.STRESS:
			this.stressGuide = new GuideStress();
			return this.stressGuide;
		case NewbieGuideComType.NEWICON_UNLOCK:
			this.newiconUnlockGuide = new GuideNewIconUnlock();
			return this.newiconUnlockGuide;
		case NewbieGuideComType.PLAY_EFFECT:
			this.playEffectGuide = new GuidePlayEffect();
			return this.playEffectGuide;
		}
		return null;
	}

	// Token: 0x06009C5D RID: 40029 RVA: 0x001E8D24 File Offset: 0x001E7124
	public IUnitData GetData()
	{
		switch (this.type)
		{
		case NewbieGuideComType.BUTTON:
		case NewbieGuideComType.TOGGLE:
			return this.buttonGuide;
		case NewbieGuideComType.ETC_BUTTON:
			return this.etcButtonGuide;
		case NewbieGuideComType.ETC_JOYSTICK:
			return this.etcJoystickGuide;
		case NewbieGuideComType.TALK_DIALOG:
			return this.talkDialogGuide;
		case NewbieGuideComType.WAIT:
			return this.waitGuide;
		case NewbieGuideComType.INTRODUCTION:
			return this.introductionGuide;
		case NewbieGuideComType.INTRODUCTION2:
			return this.introduction2Guide;
		case NewbieGuideComType.COVER:
			return this.coverGuide;
		case NewbieGuideComType.PASS_THROUGH:
			return this.passThroughGuide;
		case NewbieGuideComType.STRESS:
			return this.stressGuide;
		case NewbieGuideComType.NEWICON_UNLOCK:
			return this.newiconUnlockGuide;
		case NewbieGuideComType.PLAY_EFFECT:
			return this.playEffectGuide;
		}
		return null;
	}

	// Token: 0x06009C5E RID: 40030 RVA: 0x001E8DE8 File Offset: 0x001E71E8
	public void ChangeType(NewbieGuideComType type)
	{
		this.Type = type;
		this.SetType(type);
	}

	// Token: 0x17001952 RID: 6482
	// (get) Token: 0x06009C5F RID: 40031 RVA: 0x001E8DF9 File Offset: 0x001E71F9
	// (set) Token: 0x06009C60 RID: 40032 RVA: 0x001E8E01 File Offset: 0x001E7201
	public NewbieGuideComType Type
	{
		get
		{
			return this.type;
		}
		set
		{
			this.type = value;
		}
	}

	// Token: 0x040055D3 RID: 21971
	public string stepName;

	// Token: 0x040055D4 RID: 21972
	public NewbieGuideComType type;

	// Token: 0x040055D5 RID: 21973
	public ModifyData[] modifyData;

	// Token: 0x040055D6 RID: 21974
	public GuideButton buttonGuide;

	// Token: 0x040055D7 RID: 21975
	public GuideCover coverGuide;

	// Token: 0x040055D8 RID: 21976
	public GuideETCButton etcButtonGuide;

	// Token: 0x040055D9 RID: 21977
	public GuideETCJoystick etcJoystickGuide;

	// Token: 0x040055DA RID: 21978
	public GuideIntroduction introductionGuide;

	// Token: 0x040055DB RID: 21979
	public GuideIntroduction2 introduction2Guide;

	// Token: 0x040055DC RID: 21980
	public GuideNewIconUnlock newiconUnlockGuide;

	// Token: 0x040055DD RID: 21981
	public GuidePassThrough passThroughGuide;

	// Token: 0x040055DE RID: 21982
	public GuideStress stressGuide;

	// Token: 0x040055DF RID: 21983
	public GuideTalkDialog talkDialogGuide;

	// Token: 0x040055E0 RID: 21984
	public GuideWait waitGuide;

	// Token: 0x040055E1 RID: 21985
	public GuidePlayEffect playEffectGuide;
}
