using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C5B RID: 11355
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node1 : Action
	{
		// Token: 0x060141B1 RID: 82353 RVA: 0x00609B84 File Offset: 0x00607F84
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node1()
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
			item.skillID = 20779;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060141B2 RID: 82354 RVA: 0x00609C14 File Offset: 0x00608014
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB73 RID: 56179
		private List<Input> method_p0;

		// Token: 0x0400DB74 RID: 56180
		private bool method_p1;
	}
}
