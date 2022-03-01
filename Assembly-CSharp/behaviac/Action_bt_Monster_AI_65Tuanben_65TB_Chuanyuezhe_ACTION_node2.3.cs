using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B55 RID: 11093
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node26 : Action
	{
		// Token: 0x06013FB8 RID: 81848 RVA: 0x005FFA1C File Offset: 0x005FDE1C
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node26()
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
			item.skillID = 21851;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013FB9 RID: 81849 RVA: 0x005FFAAC File Offset: 0x005FDEAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9D6 RID: 55766
		private List<Input> method_p0;

		// Token: 0x0400D9D7 RID: 55767
		private bool method_p1;
	}
}
