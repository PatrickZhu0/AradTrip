using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003378 RID: 13176
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6 : Action
	{
		// Token: 0x06014F4D RID: 85837 RVA: 0x006506DC File Offset: 0x0064EADC
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6()
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
			item.skillID = 5800;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014F4E RID: 85838 RVA: 0x0065076C File Offset: 0x0064EB6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E812 RID: 59410
		private List<Input> method_p0;

		// Token: 0x0400E813 RID: 59411
		private bool method_p1;
	}
}
