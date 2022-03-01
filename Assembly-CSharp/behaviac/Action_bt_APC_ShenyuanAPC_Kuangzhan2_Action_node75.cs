using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E6D RID: 7789
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node75 : Action
	{
		// Token: 0x06012686 RID: 75398 RVA: 0x00561A88 File Offset: 0x0055FE88
		public Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node75()
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

		// Token: 0x06012687 RID: 75399 RVA: 0x00561B18 File Offset: 0x0055FF18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C06E RID: 49262
		private List<Input> method_p0;

		// Token: 0x0400C06F RID: 49263
		private bool method_p1;
	}
}
