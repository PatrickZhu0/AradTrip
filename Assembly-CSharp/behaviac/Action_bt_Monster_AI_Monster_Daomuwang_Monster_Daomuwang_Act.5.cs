using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200362F RID: 13871
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node20 : Action
	{
		// Token: 0x06015482 RID: 87170 RVA: 0x0066A66C File Offset: 0x00668A6C
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node20()
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
			item.skillID = 5426;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015483 RID: 87171 RVA: 0x0066A6FC File Offset: 0x00668AFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE3B RID: 60987
		private List<Input> method_p0;

		// Token: 0x0400EE3C RID: 60988
		private bool method_p1;
	}
}
