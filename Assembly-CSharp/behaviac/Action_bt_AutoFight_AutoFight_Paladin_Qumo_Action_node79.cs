using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027EE RID: 10222
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node79 : Action
	{
		// Token: 0x0601391B RID: 80155 RVA: 0x005D5928 File Offset: 0x005D3D28
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node79()
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
			item.skillID = 3612;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601391C RID: 80156 RVA: 0x005D59B8 File Offset: 0x005D3DB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D379 RID: 54137
		private List<Input> method_p0;

		// Token: 0x0400D37A RID: 54138
		private bool method_p1;
	}
}
