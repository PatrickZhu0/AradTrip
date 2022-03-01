using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x0200101D RID: 4125
	public class NewbieScriptDataGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009C62 RID: 40034 RVA: 0x001E8FD0 File Offset: 0x001E73D0
		public NewbieScriptDataGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009C63 RID: 40035 RVA: 0x001E8FD9 File Offset: 0x001E73D9
		public void LoadScriptData(DNewbieGuideData data)
		{
			this.scriptData = data;
		}

		// Token: 0x06009C64 RID: 40036 RVA: 0x001E8FE4 File Offset: 0x001E73E4
		public override void InitContent()
		{
			if (this.scriptData == null)
			{
				return;
			}
			for (int i = 0; i < this.scriptData.UnitData.Length; i++)
			{
				NewbieDataUnitData newbieDataUnitData = this.scriptData.UnitData[i];
				List<NewbieModifyData> list = new List<NewbieModifyData>();
				if (newbieDataUnitData.modifyData != null && newbieDataUnitData.modifyData.Length > 0)
				{
					for (int j = 0; j < newbieDataUnitData.modifyData.Length; j++)
					{
						list.Add(new NewbieModifyData
						{
							iIndex = newbieDataUnitData.modifyData[j].iIndex,
							ModifyDataType = newbieDataUnitData.modifyData[j].ModifyDataType
						});
					}
				}
				IUnitData data = newbieDataUnitData.GetData();
				base.AddContent(new ComNewbieData(newbieDataUnitData.Type, list, (data != null) ? data.getArgs() : null));
			}
		}

		// Token: 0x06009C65 RID: 40037 RVA: 0x001E90E8 File Offset: 0x001E74E8
		public override void InitCondition()
		{
			if (this.scriptData == null)
			{
				return;
			}
			for (int i = 0; i < this.scriptData.ConditionData.Length; i++)
			{
				NewbieConditionData newbieConditionData = this.scriptData.ConditionData[i];
				base.AddCondition(new NewbieConditionData(newbieConditionData.condition, newbieConditionData.LimitArgsList, newbieConditionData.LimitFramesList));
			}
		}

		// Token: 0x040055E8 RID: 21992
		private DNewbieGuideData scriptData;
	}
}
