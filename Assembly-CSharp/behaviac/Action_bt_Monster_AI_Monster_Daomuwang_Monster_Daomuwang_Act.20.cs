using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200366E RID: 13934
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node5 : Action
	{
		// Token: 0x060154FD RID: 87293 RVA: 0x0066D6B4 File Offset: 0x0066BAB4
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node5()
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
			item.skillID = 5428;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060154FE RID: 87294 RVA: 0x0066D744 File Offset: 0x0066BB44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEB3 RID: 61107
		private List<Input> method_p0;

		// Token: 0x0400EEB4 RID: 61108
		private bool method_p1;
	}
}
