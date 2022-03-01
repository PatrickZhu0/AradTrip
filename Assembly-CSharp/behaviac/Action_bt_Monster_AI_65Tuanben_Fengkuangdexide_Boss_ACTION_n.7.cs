using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002ECC RID: 11980
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node12 : Action
	{
		// Token: 0x06014672 RID: 83570 RVA: 0x00622758 File Offset: 0x00620B58
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node12()
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
			item.skillID = 21592;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014673 RID: 83571 RVA: 0x006227E8 File Offset: 0x00620BE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFDC RID: 57308
		private List<Input> method_p0;

		// Token: 0x0400DFDD RID: 57309
		private bool method_p1;
	}
}
