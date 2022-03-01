using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001034 RID: 4148
	public class NewbieBufferSkillGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CBC RID: 40124 RVA: 0x001EA39C File Offset: 0x001E879C
		public NewbieBufferSkillGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CBD RID: 40125 RVA: 0x001EA3A8 File Offset: 0x001E87A8
		public override void InitContent()
		{
			List<NewbieModifyData> list = new List<NewbieModifyData>();
			NewbieModifyData item = default(NewbieModifyData);
			item.iIndex = 1;
			item.ModifyDataType = NewBieModifyDataType.IconPath;
			NewbieModifyData item2 = default(NewbieModifyData);
			item2.iIndex = 2;
			item2.ModifyDataType = NewBieModifyDataType.IconName;
			list.Add(item);
			list.Add(item2);
			base.AddContent(new ComNewbieData(NewbieGuideComType.NEWICON_UNLOCK, list, new object[]
			{
				"UIFlatten/Prefabs/NewbieGuide/NewbieGuideAddBuff",
				"{0}",
				"{0}",
				3f,
				eNewbieGuideAgrsName.SaveBoot,
				eNewbieGuideAgrsName.PauseBattle
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.1f,
				false,
				eNewbieGuideAgrsName.None,
				eNewbieGuideAgrsName.None,
				eNewbieGuideAgrsName.ResumeBattle
			}));
		}

		// Token: 0x06009CBE RID: 40126 RVA: 0x001EA48C File Offset: 0x001E888C
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				15
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ChangedJob, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneBattle, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.BattleInitFinished, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.LearnBufferSkill, null, null));
		}
	}
}
