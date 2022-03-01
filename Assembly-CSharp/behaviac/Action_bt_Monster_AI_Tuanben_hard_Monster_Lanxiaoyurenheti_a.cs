using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D2B RID: 15659
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node9 : Action
	{
		// Token: 0x060161F0 RID: 90608 RVA: 0x006AFE88 File Offset: 0x006AE288
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node9()
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
			item.skillID = 21300;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060161F1 RID: 90609 RVA: 0x006AFF18 File Offset: 0x006AE318
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA67 RID: 64103
		private List<Input> method_p0;

		// Token: 0x0400FA68 RID: 64104
		private bool method_p1;
	}
}
