using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029D3 RID: 10707
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node67 : Action
	{
		// Token: 0x06013CDA RID: 81114 RVA: 0x005EBCD4 File Offset: 0x005EA0D4
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node67()
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

		// Token: 0x06013CDB RID: 81115 RVA: 0x005EBD64 File Offset: 0x005EA164
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D74A RID: 55114
		private List<Input> method_p0;

		// Token: 0x0400D74B RID: 55115
		private bool method_p1;
	}
}
