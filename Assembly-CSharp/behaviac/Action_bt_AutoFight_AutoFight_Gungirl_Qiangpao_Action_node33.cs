using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002533 RID: 9523
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node33 : Action
	{
		// Token: 0x060133AF RID: 78767 RVA: 0x005B68F0 File Offset: 0x005B4CF0
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node33()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 850;
			item.randomChangeDirection = false;
			item.skillID = 2603;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133B0 RID: 78768 RVA: 0x005B6984 File Offset: 0x005B4D84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDD5 RID: 52693
		private List<Input> method_p0;

		// Token: 0x0400CDD6 RID: 52694
		private bool method_p1;
	}
}
