using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FB0 RID: 16304
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node48 : Action
	{
		// Token: 0x060166CA RID: 91850 RVA: 0x006C8540 File Offset: 0x006C6940
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node48()
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
			item.skillID = 5108;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060166CB RID: 91851 RVA: 0x006C85D0 File Offset: 0x006C69D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF1D RID: 65309
		private List<Input> method_p0;

		// Token: 0x0400FF1E RID: 65310
		private bool method_p1;
	}
}
