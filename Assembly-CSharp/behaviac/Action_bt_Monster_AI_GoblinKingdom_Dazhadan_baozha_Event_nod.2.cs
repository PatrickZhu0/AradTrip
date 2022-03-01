using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032D8 RID: 13016
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node2 : Action
	{
		// Token: 0x06014E20 RID: 85536 RVA: 0x0064AC3C File Offset: 0x0064903C
		public Action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node2()
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
			item.skillID = 5899;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014E21 RID: 85537 RVA: 0x0064ACCC File Offset: 0x006490CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6FE RID: 59134
		private List<Input> method_p0;

		// Token: 0x0400E6FF RID: 59135
		private bool method_p1;
	}
}
