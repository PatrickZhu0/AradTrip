using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AE0 RID: 15072
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node48 : Action
	{
		// Token: 0x06015D7F RID: 89471 RVA: 0x0069912C File Offset: 0x0069752C
		public Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node48()
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
			item.skillID = 21029;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015D80 RID: 89472 RVA: 0x006991BC File Offset: 0x006975BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F68F RID: 63119
		private List<Input> method_p0;

		// Token: 0x0400F690 RID: 63120
		private bool method_p1;
	}
}
