using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003EC6 RID: 16070
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node12 : Action
	{
		// Token: 0x06016509 RID: 91401 RVA: 0x006BFEBC File Offset: 0x006BE2BC
		public Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node12()
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
			item.skillID = 7295;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601650A RID: 91402 RVA: 0x006BFF4C File Offset: 0x006BE34C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD3D RID: 64829
		private List<Input> method_p0;

		// Token: 0x0400FD3E RID: 64830
		private bool method_p1;
	}
}
