using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027D6 RID: 10198
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node40 : Action
	{
		// Token: 0x060138EB RID: 80107 RVA: 0x005D4EF0 File Offset: 0x005D32F0
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node40()
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
			item.skillID = 3606;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060138EC RID: 80108 RVA: 0x005D4F80 File Offset: 0x005D3380
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D349 RID: 54089
		private List<Input> method_p0;

		// Token: 0x0400D34A RID: 54090
		private bool method_p1;
	}
}
