using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001FD6 RID: 8150
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node30 : Action
	{
		// Token: 0x06012949 RID: 76105 RVA: 0x00571C48 File Offset: 0x00570048
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node30()
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
			item.skillID = 2510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601294A RID: 76106 RVA: 0x00571CD8 File Offset: 0x005700D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C33B RID: 49979
		private List<Input> method_p0;

		// Token: 0x0400C33C RID: 49980
		private bool method_p1;
	}
}
