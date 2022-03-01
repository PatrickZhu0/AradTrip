using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002029 RID: 8233
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node30 : Action
	{
		// Token: 0x060129ED RID: 76269 RVA: 0x00575B30 File Offset: 0x00573F30
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node30()
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

		// Token: 0x060129EE RID: 76270 RVA: 0x00575BC0 File Offset: 0x00573FC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3E0 RID: 50144
		private List<Input> method_p0;

		// Token: 0x0400C3E1 RID: 50145
		private bool method_p1;
	}
}
