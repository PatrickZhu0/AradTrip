using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027EA RID: 10218
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node49 : Action
	{
		// Token: 0x06013913 RID: 80147 RVA: 0x005D5774 File Offset: 0x005D3B74
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node49()
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
			item.skillID = 3609;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013914 RID: 80148 RVA: 0x005D5804 File Offset: 0x005D3C04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D371 RID: 54129
		private List<Input> method_p0;

		// Token: 0x0400D372 RID: 54130
		private bool method_p1;
	}
}
