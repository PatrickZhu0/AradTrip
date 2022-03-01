using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027C2 RID: 10178
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node20 : Action
	{
		// Token: 0x060138C3 RID: 80067 RVA: 0x005D466C File Offset: 0x005D2A6C
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node20()
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
			item.skillID = 3615;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060138C4 RID: 80068 RVA: 0x005D46FC File Offset: 0x005D2AFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D321 RID: 54049
		private List<Input> method_p0;

		// Token: 0x0400D322 RID: 54050
		private bool method_p1;
	}
}
