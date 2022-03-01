using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003EB4 RID: 16052
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node16 : Action
	{
		// Token: 0x060164E6 RID: 91366 RVA: 0x006BED94 File Offset: 0x006BD194
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node16()
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
			item.skillID = 7285;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060164E7 RID: 91367 RVA: 0x006BEE24 File Offset: 0x006BD224
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD19 RID: 64793
		private List<Input> method_p0;

		// Token: 0x0400FD1A RID: 64794
		private bool method_p1;
	}
}
