using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002655 RID: 9813
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node57 : Action
	{
		// Token: 0x060135EF RID: 79343 RVA: 0x005C3E8C File Offset: 0x005C228C
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node57()
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
			item.skillID = 1213;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060135F0 RID: 79344 RVA: 0x005C3F1C File Offset: 0x005C231C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D03E RID: 53310
		private List<Input> method_p0;

		// Token: 0x0400D03F RID: 53311
		private bool method_p1;
	}
}
