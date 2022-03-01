using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002169 RID: 8553
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node30 : Action
	{
		// Token: 0x06012C63 RID: 76899 RVA: 0x00584FD8 File Offset: 0x005833D8
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node30()
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
			item.skillID = 1008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012C64 RID: 76900 RVA: 0x00585068 File Offset: 0x00583468
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C656 RID: 50774
		private List<Input> method_p0;

		// Token: 0x0400C657 RID: 50775
		private bool method_p1;
	}
}
