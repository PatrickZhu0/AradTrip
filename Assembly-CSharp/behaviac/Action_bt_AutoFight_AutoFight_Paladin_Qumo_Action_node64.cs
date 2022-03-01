using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027E6 RID: 10214
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node64 : Action
	{
		// Token: 0x0601390B RID: 80139 RVA: 0x005D55C0 File Offset: 0x005D39C0
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node64()
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
			item.skillID = 3613;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601390C RID: 80140 RVA: 0x005D5650 File Offset: 0x005D3A50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D369 RID: 54121
		private List<Input> method_p0;

		// Token: 0x0400D36A RID: 54122
		private bool method_p1;
	}
}
