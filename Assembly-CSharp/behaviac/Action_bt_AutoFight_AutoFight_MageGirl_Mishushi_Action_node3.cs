using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026C8 RID: 9928
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node39 : Action
	{
		// Token: 0x060136D3 RID: 79571 RVA: 0x005C9044 File Offset: 0x005C7444
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node39()
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
			item.skillID = 2200;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060136D4 RID: 79572 RVA: 0x005C90D4 File Offset: 0x005C74D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D129 RID: 53545
		private List<Input> method_p0;

		// Token: 0x0400D12A RID: 53546
		private bool method_p1;
	}
}
