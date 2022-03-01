using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C73 RID: 11379
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node14 : Action
	{
		// Token: 0x060141DF RID: 82399 RVA: 0x0060A8B0 File Offset: 0x00608CB0
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node14()
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
			item.skillID = 20781;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060141E0 RID: 82400 RVA: 0x0060A940 File Offset: 0x00608D40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBA1 RID: 56225
		private List<Input> method_p0;

		// Token: 0x0400DBA2 RID: 56226
		private bool method_p1;
	}
}
