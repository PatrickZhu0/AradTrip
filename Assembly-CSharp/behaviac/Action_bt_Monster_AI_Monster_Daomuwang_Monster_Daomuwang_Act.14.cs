using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003655 RID: 13909
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node5 : Action
	{
		// Token: 0x060154CC RID: 87244 RVA: 0x0066C4E8 File Offset: 0x0066A8E8
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node5()
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

		// Token: 0x060154CD RID: 87245 RVA: 0x0066C578 File Offset: 0x0066A978
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE83 RID: 61059
		private List<Input> method_p0;

		// Token: 0x0400EE84 RID: 61060
		private bool method_p1;
	}
}
