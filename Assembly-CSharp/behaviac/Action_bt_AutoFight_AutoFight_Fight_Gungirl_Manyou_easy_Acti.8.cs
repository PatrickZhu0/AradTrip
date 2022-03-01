using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001FCE RID: 8142
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node20 : Action
	{
		// Token: 0x06012939 RID: 76089 RVA: 0x00571860 File Offset: 0x0056FC60
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node20()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 2508;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601293A RID: 76090 RVA: 0x005718F0 File Offset: 0x0056FCF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C32B RID: 49963
		private List<Input> method_p0;

		// Token: 0x0400C32C RID: 49964
		private bool method_p1;
	}
}
