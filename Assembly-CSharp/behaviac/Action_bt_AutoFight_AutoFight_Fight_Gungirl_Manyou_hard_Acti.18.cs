using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002035 RID: 8245
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node45 : Action
	{
		// Token: 0x06012A05 RID: 76293 RVA: 0x00576110 File Offset: 0x00574510
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node45()
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

		// Token: 0x06012A06 RID: 76294 RVA: 0x005761A0 File Offset: 0x005745A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3F8 RID: 50168
		private List<Input> method_p0;

		// Token: 0x0400C3F9 RID: 50169
		private bool method_p1;
	}
}
