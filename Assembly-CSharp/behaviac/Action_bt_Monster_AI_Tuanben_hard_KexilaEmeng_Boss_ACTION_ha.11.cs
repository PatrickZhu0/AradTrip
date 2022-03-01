using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003BAD RID: 15277
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node15 : Action
	{
		// Token: 0x06015F0A RID: 89866 RVA: 0x006A0BD8 File Offset: 0x0069EFD8
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node15()
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
			item.skillID = 21072;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015F0B RID: 89867 RVA: 0x006A0C68 File Offset: 0x0069F068
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7AE RID: 63406
		private List<Input> method_p0;

		// Token: 0x0400F7AF RID: 63407
		private bool method_p1;
	}
}
