using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002EAE RID: 11950
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node18 : Action
	{
		// Token: 0x06014636 RID: 83510 RVA: 0x00621D7C File Offset: 0x0062017C
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node18()
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
			item.skillID = 21595;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014637 RID: 83511 RVA: 0x00621E0C File Offset: 0x0062020C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFAB RID: 57259
		private List<Input> method_p0;

		// Token: 0x0400DFAC RID: 57260
		private bool method_p1;
	}
}
