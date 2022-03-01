using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020039F0 RID: 14832
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node21 : Action
	{
		// Token: 0x06015BB0 RID: 89008 RVA: 0x0068FCB4 File Offset: 0x0068E0B4
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node21()
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

		// Token: 0x06015BB1 RID: 89009 RVA: 0x0068FD44 File Offset: 0x0068E144
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4E9 RID: 62697
		private List<Input> method_p0;

		// Token: 0x0400F4EA RID: 62698
		private bool method_p1;
	}
}
