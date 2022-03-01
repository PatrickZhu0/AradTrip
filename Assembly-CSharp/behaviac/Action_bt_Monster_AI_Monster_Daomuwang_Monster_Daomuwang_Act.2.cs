using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003623 RID: 13859
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node5 : Action
	{
		// Token: 0x0601546A RID: 87146 RVA: 0x0066A150 File Offset: 0x00668550
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node5()
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

		// Token: 0x0601546B RID: 87147 RVA: 0x0066A1E0 File Offset: 0x006685E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE23 RID: 60963
		private List<Input> method_p0;

		// Token: 0x0400EE24 RID: 60964
		private bool method_p1;
	}
}
