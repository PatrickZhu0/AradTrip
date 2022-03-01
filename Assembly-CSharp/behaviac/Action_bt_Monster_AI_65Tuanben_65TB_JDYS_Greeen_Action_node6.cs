using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002BA4 RID: 11172
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node6 : Action
	{
		// Token: 0x06014051 RID: 82001 RVA: 0x006032E0 File Offset: 0x006016E0
		public Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node6()
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
			item.skillID = 20775;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014052 RID: 82002 RVA: 0x00603370 File Offset: 0x00601770
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_INVALID;
		}

		// Token: 0x0400DA4A RID: 55882
		private List<Input> method_p0;

		// Token: 0x0400DA4B RID: 55883
		private bool method_p1;
	}
}
