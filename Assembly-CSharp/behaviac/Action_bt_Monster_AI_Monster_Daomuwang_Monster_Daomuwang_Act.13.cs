using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003651 RID: 13905
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node30 : Action
	{
		// Token: 0x060154C4 RID: 87236 RVA: 0x0066C334 File Offset: 0x0066A734
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node30()
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
			item.skillID = 5430;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060154C5 RID: 87237 RVA: 0x0066C3C4 File Offset: 0x0066A7C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE7B RID: 61051
		private List<Input> method_p0;

		// Token: 0x0400EE7C RID: 61052
		private bool method_p1;
	}
}
