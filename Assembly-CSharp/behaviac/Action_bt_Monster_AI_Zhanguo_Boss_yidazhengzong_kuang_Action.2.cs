using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003EAC RID: 16044
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node5 : Action
	{
		// Token: 0x060164D6 RID: 91350 RVA: 0x006BE9D0 File Offset: 0x006BCDD0
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node5()
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
			item.skillID = 7286;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060164D7 RID: 91351 RVA: 0x006BEA60 File Offset: 0x006BCE60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD09 RID: 64777
		private List<Input> method_p0;

		// Token: 0x0400FD0A RID: 64778
		private bool method_p1;
	}
}
