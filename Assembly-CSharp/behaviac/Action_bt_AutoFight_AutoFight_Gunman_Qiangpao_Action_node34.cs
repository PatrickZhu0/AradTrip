using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002668 RID: 9832
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node34 : Action
	{
		// Token: 0x06013615 RID: 79381 RVA: 0x005C46D0 File Offset: 0x005C2AD0
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node34()
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
			item.skillID = 1202;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013616 RID: 79382 RVA: 0x005C4760 File Offset: 0x005C2B60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D067 RID: 53351
		private List<Input> method_p0;

		// Token: 0x0400D068 RID: 53352
		private bool method_p1;
	}
}
