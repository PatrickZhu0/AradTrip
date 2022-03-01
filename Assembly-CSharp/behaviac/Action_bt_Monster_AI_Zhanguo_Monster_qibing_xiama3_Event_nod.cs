using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003EF0 RID: 16112
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Monster_qibing_xiama3_Event_node3 : Action
	{
		// Token: 0x06016559 RID: 91481 RVA: 0x006C1CD0 File Offset: 0x006C00D0
		public Action_bt_Monster_AI_Zhanguo_Monster_qibing_xiama3_Event_node3()
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
			item.skillID = 7327;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601655A RID: 91482 RVA: 0x006C1D60 File Offset: 0x006C0160
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD81 RID: 64897
		private List<Input> method_p0;

		// Token: 0x0400FD82 RID: 64898
		private bool method_p1;
	}
}
