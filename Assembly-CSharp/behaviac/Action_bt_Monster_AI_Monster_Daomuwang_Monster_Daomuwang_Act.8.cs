using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200363C RID: 13884
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node5 : Action
	{
		// Token: 0x0601549B RID: 87195 RVA: 0x0066B31C File Offset: 0x0066971C
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node5()
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

		// Token: 0x0601549C RID: 87196 RVA: 0x0066B3AC File Offset: 0x006697AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE53 RID: 61011
		private List<Input> method_p0;

		// Token: 0x0400EE54 RID: 61012
		private bool method_p1;
	}
}
