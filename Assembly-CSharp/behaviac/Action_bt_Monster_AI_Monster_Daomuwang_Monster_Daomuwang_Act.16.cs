using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200365D RID: 13917
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node10 : Action
	{
		// Token: 0x060154DC RID: 87260 RVA: 0x0066C850 File Offset: 0x0066AC50
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node10()
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
			item.skillID = 5425;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060154DD RID: 87261 RVA: 0x0066C8E0 File Offset: 0x0066ACE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE93 RID: 61075
		private List<Input> method_p0;

		// Token: 0x0400EE94 RID: 61076
		private bool method_p1;
	}
}
