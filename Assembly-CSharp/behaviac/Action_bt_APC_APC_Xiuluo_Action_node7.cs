using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E3E RID: 7742
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Xiuluo_Action_node7 : Action
	{
		// Token: 0x0601262A RID: 75306 RVA: 0x0055F404 File Offset: 0x0055D804
		public Action_bt_APC_APC_Xiuluo_Action_node7()
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
			item.skillID = 7112;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601262B RID: 75307 RVA: 0x0055F494 File Offset: 0x0055D894
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C011 RID: 49169
		private List<Input> method_p0;

		// Token: 0x0400C012 RID: 49170
		private bool method_p1;
	}
}
