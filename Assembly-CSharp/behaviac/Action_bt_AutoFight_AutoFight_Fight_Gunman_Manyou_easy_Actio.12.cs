using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002119 RID: 8473
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node30 : Action
	{
		// Token: 0x06012BC5 RID: 76741 RVA: 0x005813A0 File Offset: 0x0057F7A0
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node30()
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
			item.skillID = 1008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012BC6 RID: 76742 RVA: 0x00581430 File Offset: 0x0057F830
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5B8 RID: 50616
		private List<Input> method_p0;

		// Token: 0x0400C5B9 RID: 50617
		private bool method_p1;
	}
}
