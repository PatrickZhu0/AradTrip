using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200277E RID: 10110
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node34 : Action
	{
		// Token: 0x0601383D RID: 79933 RVA: 0x005D09F4 File Offset: 0x005CEDF4
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node34()
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
			item.skillID = 2010;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601383E RID: 79934 RVA: 0x005D0A84 File Offset: 0x005CEE84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D29D RID: 53917
		private List<Input> method_p0;

		// Token: 0x0400D29E RID: 53918
		private bool method_p1;
	}
}
