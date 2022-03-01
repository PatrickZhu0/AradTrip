using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A6A RID: 14954
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node41 : Action
	{
		// Token: 0x06015C9D RID: 89245 RVA: 0x00694664 File Offset: 0x00692A64
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node41()
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
			item.skillID = 21063;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C9E RID: 89246 RVA: 0x006946F4 File Offset: 0x00692AF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5D0 RID: 62928
		private List<Input> method_p0;

		// Token: 0x0400F5D1 RID: 62929
		private bool method_p1;
	}
}
