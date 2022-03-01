using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200255B RID: 9563
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node99 : Action
	{
		// Token: 0x060133FF RID: 78847 RVA: 0x005B7A08 File Offset: 0x005B5E08
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node99()
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
			item.skillID = 2509;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013400 RID: 78848 RVA: 0x005B7A98 File Offset: 0x005B5E98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE25 RID: 52773
		private List<Input> method_p0;

		// Token: 0x0400CE26 RID: 52774
		private bool method_p1;
	}
}
