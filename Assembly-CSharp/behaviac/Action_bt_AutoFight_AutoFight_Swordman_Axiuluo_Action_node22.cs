using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028B0 RID: 10416
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node22 : Action
	{
		// Token: 0x06013A9A RID: 80538 RVA: 0x005DF1B4 File Offset: 0x005DD5B4
		public Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node22()
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
			item.skillID = 1521;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013A9B RID: 80539 RVA: 0x005DF244 File Offset: 0x005DD644
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4F6 RID: 54518
		private List<Input> method_p0;

		// Token: 0x0400D4F7 RID: 54519
		private bool method_p1;
	}
}
