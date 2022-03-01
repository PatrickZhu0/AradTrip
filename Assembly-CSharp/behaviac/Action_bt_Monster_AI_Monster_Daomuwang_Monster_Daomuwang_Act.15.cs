using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003659 RID: 13913
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node15 : Action
	{
		// Token: 0x060154D4 RID: 87252 RVA: 0x0066C69C File Offset: 0x0066AA9C
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node15()
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
			item.skillID = 5661;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060154D5 RID: 87253 RVA: 0x0066C72C File Offset: 0x0066AB2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE8B RID: 61067
		private List<Input> method_p0;

		// Token: 0x0400EE8C RID: 61068
		private bool method_p1;
	}
}
