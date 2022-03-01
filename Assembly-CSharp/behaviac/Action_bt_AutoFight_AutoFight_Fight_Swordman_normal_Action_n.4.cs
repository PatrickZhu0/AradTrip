using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200244D RID: 9293
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node41 : Action
	{
		// Token: 0x060131EE RID: 78318 RVA: 0x005AC090 File Offset: 0x005AA490
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node41()
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
			item.skillID = 1512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060131EF RID: 78319 RVA: 0x005AC120 File Offset: 0x005AA520
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC16 RID: 52246
		private List<Input> method_p0;

		// Token: 0x0400CC17 RID: 52247
		private bool method_p1;
	}
}
