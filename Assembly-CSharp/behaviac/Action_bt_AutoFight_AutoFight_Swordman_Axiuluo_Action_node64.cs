using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028D0 RID: 10448
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node64 : Action
	{
		// Token: 0x06013ADA RID: 80602 RVA: 0x005E0030 File Offset: 0x005DE430
		public Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node64()
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
			item.skillID = 1701;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013ADB RID: 80603 RVA: 0x005E00C0 File Offset: 0x005DE4C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D53A RID: 54586
		private List<Input> method_p0;

		// Token: 0x0400D53B RID: 54587
		private bool method_p1;
	}
}
