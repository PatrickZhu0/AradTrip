using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200209D RID: 8349
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node25 : Action
	{
		// Token: 0x06012AD2 RID: 76498 RVA: 0x0057B4F4 File Offset: 0x005798F4
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node25()
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
			item.skillID = 2507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012AD3 RID: 76499 RVA: 0x0057B584 File Offset: 0x00579984
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4C5 RID: 50373
		private List<Input> method_p0;

		// Token: 0x0400C4C6 RID: 50374
		private bool method_p1;
	}
}
