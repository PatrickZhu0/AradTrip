using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003C1C RID: 15388
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node34 : Action
	{
		// Token: 0x06015FE3 RID: 90083 RVA: 0x006A50E8 File Offset: 0x006A34E8
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node34()
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
			item.skillID = 21066;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015FE4 RID: 90084 RVA: 0x006A5178 File Offset: 0x006A3578
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F860 RID: 63584
		private List<Input> method_p0;

		// Token: 0x0400F861 RID: 63585
		private bool method_p1;
	}
}
