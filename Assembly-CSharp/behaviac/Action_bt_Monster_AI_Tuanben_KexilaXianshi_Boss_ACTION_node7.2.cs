using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A51 RID: 14929
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node7 : Action
	{
		// Token: 0x06015C6B RID: 89195 RVA: 0x00693AF0 File Offset: 0x00691EF0
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node7()
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
			item.skillID = 21054;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C6C RID: 89196 RVA: 0x00693B80 File Offset: 0x00691F80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F593 RID: 62867
		private List<Input> method_p0;

		// Token: 0x0400F594 RID: 62868
		private bool method_p1;
	}
}
