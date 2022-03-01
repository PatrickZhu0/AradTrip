using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E97 RID: 7831
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Mishushi_Action_node67 : Action
	{
		// Token: 0x060126D8 RID: 75480 RVA: 0x005638B8 File Offset: 0x00561CB8
		public Action_bt_APC_ShenyuanAPC_Mishushi_Action_node67()
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
			item.skillID = 9742;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060126D9 RID: 75481 RVA: 0x00563948 File Offset: 0x00561D48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0C5 RID: 49349
		private List<Input> method_p0;

		// Token: 0x0400C0C6 RID: 49350
		private bool method_p1;
	}
}
