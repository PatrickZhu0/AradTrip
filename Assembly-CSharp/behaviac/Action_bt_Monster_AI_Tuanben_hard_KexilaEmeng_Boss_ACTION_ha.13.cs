using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003BB4 RID: 15284
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node21 : Action
	{
		// Token: 0x06015F18 RID: 89880 RVA: 0x006A0E38 File Offset: 0x0069F238
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node21()
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
			item.skillID = 21071;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015F19 RID: 89881 RVA: 0x006A0EC8 File Offset: 0x0069F2C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7B5 RID: 63413
		private List<Input> method_p0;

		// Token: 0x0400F7B6 RID: 63414
		private bool method_p1;
	}
}
