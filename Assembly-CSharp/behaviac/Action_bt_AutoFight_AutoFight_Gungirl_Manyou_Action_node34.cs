using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024E3 RID: 9443
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node34 : Action
	{
		// Token: 0x06013310 RID: 78608 RVA: 0x005B2A5C File Offset: 0x005B0E5C
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node34()
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
			item.skillID = 2516;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013311 RID: 78609 RVA: 0x005B2AEC File Offset: 0x005B0EEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD2D RID: 52525
		private List<Input> method_p0;

		// Token: 0x0400CD2E RID: 52526
		private bool method_p1;
	}
}
