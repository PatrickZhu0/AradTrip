using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E6A RID: 11882
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node265 : Action
	{
		// Token: 0x060145B1 RID: 83377 RVA: 0x0061BE74 File Offset: 0x0061A274
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node265()
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
			item.skillID = 21641;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060145B2 RID: 83378 RVA: 0x0061BF04 File Offset: 0x0061A304
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF3A RID: 57146
		private List<Input> method_p0;

		// Token: 0x0400DF3B RID: 57147
		private bool method_p1;
	}
}
