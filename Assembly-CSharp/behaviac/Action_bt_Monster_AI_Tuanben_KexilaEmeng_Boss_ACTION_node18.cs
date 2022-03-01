using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020039E2 RID: 14818
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node18 : Action
	{
		// Token: 0x06015B94 RID: 88980 RVA: 0x0068F714 File Offset: 0x0068DB14
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node18()
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
			item.skillID = 21075;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015B95 RID: 88981 RVA: 0x0068F7A4 File Offset: 0x0068DBA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4D6 RID: 62678
		private List<Input> method_p0;

		// Token: 0x0400F4D7 RID: 62679
		private bool method_p1;
	}
}
