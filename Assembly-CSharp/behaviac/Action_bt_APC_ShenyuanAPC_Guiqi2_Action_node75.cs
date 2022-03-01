using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E43 RID: 7747
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Guiqi2_Action_node75 : Action
	{
		// Token: 0x06012633 RID: 75315 RVA: 0x0055F9D8 File Offset: 0x0055DDD8
		public Action_bt_APC_ShenyuanAPC_Guiqi2_Action_node75()
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
			item.skillID = 9725;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012634 RID: 75316 RVA: 0x0055FA68 File Offset: 0x0055DE68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C019 RID: 49177
		private List<Input> method_p0;

		// Token: 0x0400C01A RID: 49178
		private bool method_p1;
	}
}
