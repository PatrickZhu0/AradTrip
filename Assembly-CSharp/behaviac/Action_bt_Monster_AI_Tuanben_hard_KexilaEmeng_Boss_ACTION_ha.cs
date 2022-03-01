using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B8C RID: 15244
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node51 : Action
	{
		// Token: 0x06015EC8 RID: 89800 RVA: 0x0069FFF8 File Offset: 0x0069E3F8
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node51()
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
			item.skillID = 21069;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015EC9 RID: 89801 RVA: 0x006A0088 File Offset: 0x0069E488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F785 RID: 63365
		private List<Input> method_p0;

		// Token: 0x0400F786 RID: 63366
		private bool method_p1;
	}
}
