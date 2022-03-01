using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003F80 RID: 16256
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node13 : Action
	{
		// Token: 0x0601666C RID: 91756 RVA: 0x006C6BF0 File Offset: 0x006C4FF0
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node13()
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
			item.skillID = 5355;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601666D RID: 91757 RVA: 0x006C6C80 File Offset: 0x006C5080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEC1 RID: 65217
		private List<Input> method_p0;

		// Token: 0x0400FEC2 RID: 65218
		private bool method_p1;
	}
}
