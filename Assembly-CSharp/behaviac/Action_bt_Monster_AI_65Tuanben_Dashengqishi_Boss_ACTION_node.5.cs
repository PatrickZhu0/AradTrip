using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D99 RID: 11673
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node29 : Action
	{
		// Token: 0x06014413 RID: 82963 RVA: 0x00615B5C File Offset: 0x00613F5C
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node29()
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
			item.skillID = 21645;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014414 RID: 82964 RVA: 0x00615BEC File Offset: 0x00613FEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDDB RID: 56795
		private List<Input> method_p0;

		// Token: 0x0400DDDC RID: 56796
		private bool method_p1;
	}
}
