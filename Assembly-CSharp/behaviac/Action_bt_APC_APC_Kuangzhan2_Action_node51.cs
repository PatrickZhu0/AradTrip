using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D91 RID: 7569
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan2_Action_node51 : Action
	{
		// Token: 0x060124DD RID: 74973 RVA: 0x005575C0 File Offset: 0x005559C0
		public Action_bt_APC_APC_Kuangzhan2_Action_node51()
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
			item.skillID = 9720;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060124DE RID: 74974 RVA: 0x00557650 File Offset: 0x00555A50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEC8 RID: 48840
		private List<Input> method_p0;

		// Token: 0x0400BEC9 RID: 48841
		private bool method_p1;
	}
}
