using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027FE RID: 10238
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node94 : Action
	{
		// Token: 0x0601393B RID: 80187 RVA: 0x005D5FF8 File Offset: 0x005D43F8
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node94()
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
			item.skillID = 3507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601393C RID: 80188 RVA: 0x005D6088 File Offset: 0x005D4488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D399 RID: 54169
		private List<Input> method_p0;

		// Token: 0x0400D39A RID: 54170
		private bool method_p1;
	}
}
