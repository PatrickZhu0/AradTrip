using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003EFC RID: 16124
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Monster_qibing_xiama_Event_node3 : Action
	{
		// Token: 0x0601656F RID: 91503 RVA: 0x006C2308 File Offset: 0x006C0708
		public Action_bt_Monster_AI_Zhanguo_Monster_qibing_xiama_Event_node3()
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
			item.skillID = 7310;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016570 RID: 91504 RVA: 0x006C2398 File Offset: 0x006C0798
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD8D RID: 64909
		private List<Input> method_p0;

		// Token: 0x0400FD8E RID: 64910
		private bool method_p1;
	}
}
