using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E0F RID: 11791
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node149 : Action
	{
		// Token: 0x060144FB RID: 83195 RVA: 0x006199F4 File Offset: 0x00617DF4
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node149()
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
			item.skillID = 21641;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060144FC RID: 83196 RVA: 0x00619A84 File Offset: 0x00617E84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEA2 RID: 56994
		private List<Input> method_p0;

		// Token: 0x0400DEA3 RID: 56995
		private bool method_p1;
	}
}
