using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200339F RID: 13215
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node17 : Action
	{
		// Token: 0x06014F99 RID: 85913 RVA: 0x00651BBC File Offset: 0x0064FFBC
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node17()
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
			item.skillID = 5804;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014F9A RID: 85914 RVA: 0x00651C4C File Offset: 0x0065004C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E874 RID: 59508
		private List<Input> method_p0;

		// Token: 0x0400E875 RID: 59509
		private bool method_p1;
	}
}
