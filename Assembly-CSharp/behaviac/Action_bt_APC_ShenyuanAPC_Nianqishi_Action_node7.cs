using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EBE RID: 7870
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node7 : Action
	{
		// Token: 0x06012724 RID: 75556 RVA: 0x005650D8 File Offset: 0x005634D8
		public Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node7()
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
			item.skillID = 9704;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012725 RID: 75557 RVA: 0x00565168 File Offset: 0x00563568
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C112 RID: 49426
		private List<Input> method_p0;

		// Token: 0x0400C113 RID: 49427
		private bool method_p1;
	}
}
