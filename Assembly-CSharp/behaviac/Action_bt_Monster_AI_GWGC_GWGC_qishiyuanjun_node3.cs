using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020033C0 RID: 13248
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GWGC_GWGC_qishiyuanjun_node3 : Action
	{
		// Token: 0x06014FD8 RID: 85976 RVA: 0x006531D0 File Offset: 0x006515D0
		public Action_bt_Monster_AI_GWGC_GWGC_qishiyuanjun_node3()
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
			item.skillID = 7477;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014FD9 RID: 85977 RVA: 0x00653260 File Offset: 0x00651660
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8C3 RID: 59587
		private List<Input> method_p0;

		// Token: 0x0400E8C4 RID: 59588
		private bool method_p1;
	}
}
