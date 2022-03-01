using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003BAB RID: 15275
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node34 : Action
	{
		// Token: 0x06015F06 RID: 89862 RVA: 0x006A0AE4 File Offset: 0x0069EEE4
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node34()
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
			item.skillID = 21076;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015F07 RID: 89863 RVA: 0x006A0B74 File Offset: 0x0069EF74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7AB RID: 63403
		private List<Input> method_p0;

		// Token: 0x0400F7AC RID: 63404
		private bool method_p1;
	}
}
