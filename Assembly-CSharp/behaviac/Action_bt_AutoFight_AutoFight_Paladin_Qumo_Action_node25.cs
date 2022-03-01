using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027CA RID: 10186
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node25 : Action
	{
		// Token: 0x060138D3 RID: 80083 RVA: 0x005D49D4 File Offset: 0x005D2DD4
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node25()
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
			item.skillID = 3601;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060138D4 RID: 80084 RVA: 0x005D4A64 File Offset: 0x005D2E64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D331 RID: 54065
		private List<Input> method_p0;

		// Token: 0x0400D332 RID: 54066
		private bool method_p1;
	}
}
