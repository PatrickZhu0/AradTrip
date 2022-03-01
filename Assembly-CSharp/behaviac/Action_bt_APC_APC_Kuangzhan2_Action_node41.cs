using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D89 RID: 7561
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan2_Action_node41 : Action
	{
		// Token: 0x060124CD RID: 74957 RVA: 0x00557288 File Offset: 0x00555688
		public Action_bt_APC_APC_Kuangzhan2_Action_node41()
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
			item.skillID = 9716;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060124CE RID: 74958 RVA: 0x00557318 File Offset: 0x00555718
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEB8 RID: 48824
		private List<Input> method_p0;

		// Token: 0x0400BEB9 RID: 48825
		private bool method_p1;
	}
}
