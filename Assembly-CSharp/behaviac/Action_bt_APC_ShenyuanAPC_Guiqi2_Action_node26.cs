using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E47 RID: 7751
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Guiqi2_Action_node26 : Action
	{
		// Token: 0x0601263B RID: 75323 RVA: 0x0055FB8C File Offset: 0x0055DF8C
		public Action_bt_APC_ShenyuanAPC_Guiqi2_Action_node26()
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
			item.skillID = 9724;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601263C RID: 75324 RVA: 0x0055FC1C File Offset: 0x0055E01C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C021 RID: 49185
		private List<Input> method_p0;

		// Token: 0x0400C022 RID: 49186
		private bool method_p1;
	}
}
