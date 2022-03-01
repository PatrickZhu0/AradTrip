using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003BC1 RID: 15297
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node71 : Action
	{
		// Token: 0x06015F32 RID: 89906 RVA: 0x006A12A0 File Offset: 0x0069F6A0
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node71()
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
			item.skillID = 21508;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015F33 RID: 89907 RVA: 0x006A1330 File Offset: 0x0069F730
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7C2 RID: 63426
		private List<Input> method_p0;

		// Token: 0x0400F7C3 RID: 63427
		private bool method_p1;
	}
}
