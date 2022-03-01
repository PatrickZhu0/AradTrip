using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020033A3 RID: 13219
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node22 : Action
	{
		// Token: 0x06014FA1 RID: 85921 RVA: 0x00651D8C File Offset: 0x0065018C
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node22()
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
			item.skillID = 5805;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014FA2 RID: 85922 RVA: 0x00651E1C File Offset: 0x0065021C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E87F RID: 59519
		private List<Input> method_p0;

		// Token: 0x0400E880 RID: 59520
		private bool method_p1;
	}
}
