using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002BA1 RID: 11169
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node2 : Action
	{
		// Token: 0x0601404B RID: 81995 RVA: 0x00603174 File Offset: 0x00601574
		public Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 20774;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601404C RID: 81996 RVA: 0x00603204 File Offset: 0x00601604
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_INVALID;
		}

		// Token: 0x0400DA43 RID: 55875
		private List<Input> method_p0;

		// Token: 0x0400DA44 RID: 55876
		private bool method_p1;
	}
}
