using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003EC2 RID: 16066
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node5 : Action
	{
		// Token: 0x06016501 RID: 91393 RVA: 0x006BFD08 File Offset: 0x006BE108
		public Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node5()
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
			item.skillID = 7294;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016502 RID: 91394 RVA: 0x006BFD98 File Offset: 0x006BE198
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD35 RID: 64821
		private List<Input> method_p0;

		// Token: 0x0400FD36 RID: 64822
		private bool method_p1;
	}
}
