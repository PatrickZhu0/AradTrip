using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D73 RID: 11635
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node29 : Action
	{
		// Token: 0x060143C8 RID: 82888 RVA: 0x006142F0 File Offset: 0x006126F0
		public Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node29()
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
			item.skillID = 21605;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060143C9 RID: 82889 RVA: 0x00614380 File Offset: 0x00612780
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD93 RID: 56723
		private List<Input> method_p0;

		// Token: 0x0400DD94 RID: 56724
		private bool method_p1;
	}
}
