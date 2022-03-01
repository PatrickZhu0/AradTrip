using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020033A8 RID: 13224
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node24 : Action
	{
		// Token: 0x06014FAB RID: 85931 RVA: 0x00651FA0 File Offset: 0x006503A0
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node24()
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
			item.skillID = 5807;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014FAC RID: 85932 RVA: 0x00652030 File Offset: 0x00650430
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E88B RID: 59531
		private List<Input> method_p0;

		// Token: 0x0400E88C RID: 59532
		private bool method_p1;
	}
}
