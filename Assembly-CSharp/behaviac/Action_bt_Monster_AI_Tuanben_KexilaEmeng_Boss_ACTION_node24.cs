using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020039F3 RID: 14835
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node24 : Action
	{
		// Token: 0x06015BB6 RID: 89014 RVA: 0x0068FDB8 File Offset: 0x0068E1B8
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node24()
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

		// Token: 0x06015BB7 RID: 89015 RVA: 0x0068FE48 File Offset: 0x0068E248
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4EC RID: 62700
		private List<Input> method_p0;

		// Token: 0x0400F4ED RID: 62701
		private bool method_p1;
	}
}
