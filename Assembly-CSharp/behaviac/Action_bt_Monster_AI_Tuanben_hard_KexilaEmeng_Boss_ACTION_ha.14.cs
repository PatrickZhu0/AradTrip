using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003BB7 RID: 15287
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node24 : Action
	{
		// Token: 0x06015F1E RID: 89886 RVA: 0x006A0F3C File Offset: 0x0069F33C
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node24()
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
			item.skillID = 21058;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015F1F RID: 89887 RVA: 0x006A0FCC File Offset: 0x0069F3CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7B8 RID: 63416
		private List<Input> method_p0;

		// Token: 0x0400F7B9 RID: 63417
		private bool method_p1;
	}
}
