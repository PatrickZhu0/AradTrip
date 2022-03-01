using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003EF6 RID: 16118
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Monster_qibing_xiamaGHFB_Event_node3 : Action
	{
		// Token: 0x06016564 RID: 91492 RVA: 0x006C1FEC File Offset: 0x006C03EC
		public Action_bt_Monster_AI_Zhanguo_Monster_qibing_xiamaGHFB_Event_node3()
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
			item.skillID = 20053;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016565 RID: 91493 RVA: 0x006C207C File Offset: 0x006C047C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD87 RID: 64903
		private List<Input> method_p0;

		// Token: 0x0400FD88 RID: 64904
		private bool method_p1;
	}
}
