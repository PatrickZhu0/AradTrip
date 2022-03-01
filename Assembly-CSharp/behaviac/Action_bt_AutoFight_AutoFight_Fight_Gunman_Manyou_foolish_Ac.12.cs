using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002141 RID: 8513
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node30 : Action
	{
		// Token: 0x06012C14 RID: 76820 RVA: 0x005831BC File Offset: 0x005815BC
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node30()
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

		// Token: 0x06012C15 RID: 76821 RVA: 0x0058324C File Offset: 0x0058164C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C607 RID: 50695
		private List<Input> method_p0;

		// Token: 0x0400C608 RID: 50696
		private bool method_p1;
	}
}
