using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003BB0 RID: 15280
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node12 : Action
	{
		// Token: 0x06015F10 RID: 89872 RVA: 0x006A0D10 File Offset: 0x0069F110
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node12()
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
			item.skillID = 21056;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015F11 RID: 89873 RVA: 0x006A0DA0 File Offset: 0x0069F1A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7B2 RID: 63410
		private List<Input> method_p0;

		// Token: 0x0400F7B3 RID: 63411
		private bool method_p1;
	}
}
