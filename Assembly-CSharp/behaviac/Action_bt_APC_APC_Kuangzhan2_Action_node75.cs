using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D8D RID: 7565
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan2_Action_node75 : Action
	{
		// Token: 0x060124D5 RID: 74965 RVA: 0x00557424 File Offset: 0x00555824
		public Action_bt_APC_APC_Kuangzhan2_Action_node75()
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
			item.skillID = 9719;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060124D6 RID: 74966 RVA: 0x005574B4 File Offset: 0x005558B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEC0 RID: 48832
		private List<Input> method_p0;

		// Token: 0x0400BEC1 RID: 48833
		private bool method_p1;
	}
}
