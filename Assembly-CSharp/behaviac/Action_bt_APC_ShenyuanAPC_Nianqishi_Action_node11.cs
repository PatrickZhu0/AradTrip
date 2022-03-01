using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EB5 RID: 7861
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node11 : Action
	{
		// Token: 0x06012712 RID: 75538 RVA: 0x00564D08 File Offset: 0x00563108
		public Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node11()
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
			item.skillID = 9703;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012713 RID: 75539 RVA: 0x00564D98 File Offset: 0x00563198
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0FF RID: 49407
		private List<Input> method_p0;

		// Token: 0x0400C100 RID: 49408
		private bool method_p1;
	}
}
