using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003ECA RID: 16074
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node15 : Action
	{
		// Token: 0x06016511 RID: 91409 RVA: 0x006C0070 File Offset: 0x006BE470
		public Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node15()
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
			item.skillID = 7296;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016512 RID: 91410 RVA: 0x006C0100 File Offset: 0x006BE500
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD45 RID: 64837
		private List<Input> method_p0;

		// Token: 0x0400FD46 RID: 64838
		private bool method_p1;
	}
}
