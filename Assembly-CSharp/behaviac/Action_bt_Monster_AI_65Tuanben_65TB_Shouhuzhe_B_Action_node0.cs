using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C58 RID: 11352
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node0 : Action
	{
		// Token: 0x060141AB RID: 82347 RVA: 0x00609A80 File Offset: 0x00607E80
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node0()
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
			item.skillID = 20780;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060141AC RID: 82348 RVA: 0x00609B10 File Offset: 0x00607F10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB70 RID: 56176
		private List<Input> method_p0;

		// Token: 0x0400DB71 RID: 56177
		private bool method_p1;
	}
}
