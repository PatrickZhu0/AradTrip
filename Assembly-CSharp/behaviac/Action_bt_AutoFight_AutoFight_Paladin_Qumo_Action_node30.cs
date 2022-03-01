using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027CE RID: 10190
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node30 : Action
	{
		// Token: 0x060138DB RID: 80091 RVA: 0x005D4B88 File Offset: 0x005D2F88
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node30()
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
			item.skillID = 3600;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060138DC RID: 80092 RVA: 0x005D4C18 File Offset: 0x005D3018
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D339 RID: 54073
		private List<Input> method_p0;

		// Token: 0x0400D33A RID: 54074
		private bool method_p1;
	}
}
