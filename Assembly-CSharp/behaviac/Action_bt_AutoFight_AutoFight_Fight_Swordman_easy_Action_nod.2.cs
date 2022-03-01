using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200226E RID: 8814
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node16 : Action
	{
		// Token: 0x06012E61 RID: 77409 RVA: 0x00592CA4 File Offset: 0x005910A4
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node16()
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
			item.skillID = 1505;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012E62 RID: 77410 RVA: 0x00592D34 File Offset: 0x00591134
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C86D RID: 51309
		private List<Input> method_p0;

		// Token: 0x0400C86E RID: 51310
		private bool method_p1;
	}
}
