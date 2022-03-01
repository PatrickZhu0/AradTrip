using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002802 RID: 10242
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node104 : Action
	{
		// Token: 0x06013943 RID: 80195 RVA: 0x005D61AC File Offset: 0x005D45AC
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node104()
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
			item.skillID = 3509;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013944 RID: 80196 RVA: 0x005D623C File Offset: 0x005D463C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3A1 RID: 54177
		private List<Input> method_p0;

		// Token: 0x0400D3A2 RID: 54178
		private bool method_p1;
	}
}
