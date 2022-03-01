using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026A3 RID: 9891
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Action_node29 : Action
	{
		// Token: 0x0601368A RID: 79498 RVA: 0x005C72EC File Offset: 0x005C56EC
		public Action_bt_AutoFight_AutoFight_MageGirl_Action_node29()
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
			item.skillID = 2103;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601368B RID: 79499 RVA: 0x005C737C File Offset: 0x005C577C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0DD RID: 53469
		private List<Input> method_p0;

		// Token: 0x0400D0DE RID: 53470
		private bool method_p1;
	}
}
