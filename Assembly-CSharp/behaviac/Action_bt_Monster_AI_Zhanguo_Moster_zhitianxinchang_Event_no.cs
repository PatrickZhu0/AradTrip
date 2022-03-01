using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003F06 RID: 16134
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Moster_zhitianxinchang_Event_node3 : Action
	{
		// Token: 0x06016581 RID: 91521 RVA: 0x006C2878 File Offset: 0x006C0C78
		public Action_bt_Monster_AI_Zhanguo_Moster_zhitianxinchang_Event_node3()
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
			item.skillID = 7384;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016582 RID: 91522 RVA: 0x006C2908 File Offset: 0x006C0D08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD99 RID: 64921
		private List<Input> method_p0;

		// Token: 0x0400FD9A RID: 64922
		private bool method_p1;
	}
}
