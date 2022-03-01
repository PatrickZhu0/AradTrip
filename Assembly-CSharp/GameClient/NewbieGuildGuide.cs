using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001048 RID: 4168
	public class NewbieGuildGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CF9 RID: 40185 RVA: 0x001ECC01 File Offset: 0x001EB001
		public NewbieGuildGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CFA RID: 40186 RVA: 0x001ECC0C File Offset: 0x001EB00C
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightHorizon/guild",
				"加入公会，找到组织，可以使你变的更强！",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				new Vector3(0f, 0f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"公会可以让你找到伙伴，一\n起在游戏中体验关卡，切磋\n技术，分享经验！"
			}));
		}

		// Token: 0x06009CFB RID: 40187 RVA: 0x001ECC98 File Offset: 0x001EB098
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				17
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2293
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
