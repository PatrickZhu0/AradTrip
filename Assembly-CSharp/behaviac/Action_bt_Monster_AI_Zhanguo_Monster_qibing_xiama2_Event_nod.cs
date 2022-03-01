using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003EEA RID: 16106
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Monster_qibing_xiama2_Event_node3 : Action
	{
		// Token: 0x0601654E RID: 91470 RVA: 0x006C19B4 File Offset: 0x006BFDB4
		public Action_bt_Monster_AI_Zhanguo_Monster_qibing_xiama2_Event_node3()
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
			item.skillID = 7326;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601654F RID: 91471 RVA: 0x006C1A44 File Offset: 0x006BFE44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD7B RID: 64891
		private List<Input> method_p0;

		// Token: 0x0400FD7C RID: 64892
		private bool method_p1;
	}
}
