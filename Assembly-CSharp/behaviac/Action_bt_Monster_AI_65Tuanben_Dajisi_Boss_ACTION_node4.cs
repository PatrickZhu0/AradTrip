using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D66 RID: 11622
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node4 : Action
	{
		// Token: 0x060143AE RID: 82862 RVA: 0x00613E2C File Offset: 0x0061222C
		public Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node4()
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
			item.skillID = 21610;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060143AF RID: 82863 RVA: 0x00613EBC File Offset: 0x006122BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD78 RID: 56696
		private List<Input> method_p0;

		// Token: 0x0400DD79 RID: 56697
		private bool method_p1;
	}
}
