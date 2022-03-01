using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E69 RID: 7785
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node41 : Action
	{
		// Token: 0x0601267E RID: 75390 RVA: 0x005618EC File Offset: 0x0055FCEC
		public Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node41()
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

		// Token: 0x0601267F RID: 75391 RVA: 0x0056197C File Offset: 0x0055FD7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C066 RID: 49254
		private List<Input> method_p0;

		// Token: 0x0400C067 RID: 49255
		private bool method_p1;
	}
}
