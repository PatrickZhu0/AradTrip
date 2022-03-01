using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002ED1 RID: 11985
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node31 : Action
	{
		// Token: 0x0601467C RID: 83580 RVA: 0x0062298C File Offset: 0x00620D8C
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node31()
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
			item.skillID = 21590;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601467D RID: 83581 RVA: 0x00622A1C File Offset: 0x00620E1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFEB RID: 57323
		private List<Input> method_p0;

		// Token: 0x0400DFEC RID: 57324
		private bool method_p1;
	}
}
