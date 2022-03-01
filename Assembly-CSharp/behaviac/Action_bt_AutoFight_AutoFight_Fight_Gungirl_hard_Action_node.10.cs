using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001FBA RID: 8122
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node25 : Action
	{
		// Token: 0x06012912 RID: 76050 RVA: 0x0057089C File Offset: 0x0056EC9C
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node25()
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
			item.skillID = 2507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012913 RID: 76051 RVA: 0x0057092C File Offset: 0x0056ED2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C304 RID: 49924
		private List<Input> method_p0;

		// Token: 0x0400C305 RID: 49925
		private bool method_p1;
	}
}
