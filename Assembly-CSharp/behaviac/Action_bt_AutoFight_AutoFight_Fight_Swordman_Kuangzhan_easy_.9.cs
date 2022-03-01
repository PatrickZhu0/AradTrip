using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200232E RID: 9006
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node58 : Action
	{
		// Token: 0x06012FCF RID: 77775 RVA: 0x0059CDF8 File Offset: 0x0059B1F8
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node58()
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
			item.skillID = 1511;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012FD0 RID: 77776 RVA: 0x0059CE88 File Offset: 0x0059B288
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9E8 RID: 51688
		private List<Input> method_p0;

		// Token: 0x0400C9E9 RID: 51689
		private bool method_p1;
	}
}
