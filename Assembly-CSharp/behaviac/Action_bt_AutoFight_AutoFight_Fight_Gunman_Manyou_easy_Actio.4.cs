using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002109 RID: 8457
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node10 : Action
	{
		// Token: 0x06012BA5 RID: 76709 RVA: 0x00580BD0 File Offset: 0x0057EFD0
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node10()
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
			item.skillID = 1101;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012BA6 RID: 76710 RVA: 0x00580C60 File Offset: 0x0057F060
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C598 RID: 50584
		private List<Input> method_p0;

		// Token: 0x0400C599 RID: 50585
		private bool method_p1;
	}
}
