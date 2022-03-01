using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200252B RID: 9515
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node54 : Action
	{
		// Token: 0x0601339F RID: 78751 RVA: 0x005B6538 File Offset: 0x005B4938
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node54()
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
			item.skillID = 2603;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133A0 RID: 78752 RVA: 0x005B65C8 File Offset: 0x005B49C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDC1 RID: 52673
		private List<Input> method_p0;

		// Token: 0x0400CDC2 RID: 52674
		private bool method_p1;
	}
}
