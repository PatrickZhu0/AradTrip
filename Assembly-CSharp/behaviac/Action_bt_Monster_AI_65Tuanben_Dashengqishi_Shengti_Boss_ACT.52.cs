using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E6D RID: 11885
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node269 : Action
	{
		// Token: 0x060145B7 RID: 83383 RVA: 0x0061BFC8 File Offset: 0x0061A3C8
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node269()
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
			item.skillID = 21629;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060145B8 RID: 83384 RVA: 0x0061C058 File Offset: 0x0061A458
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF40 RID: 57152
		private List<Input> method_p0;

		// Token: 0x0400DF41 RID: 57153
		private bool method_p1;
	}
}
