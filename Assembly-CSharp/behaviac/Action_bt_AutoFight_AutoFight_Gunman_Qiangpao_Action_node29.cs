using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002663 RID: 9827
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node29 : Action
	{
		// Token: 0x0601360B RID: 79371 RVA: 0x005C44C0 File Offset: 0x005C28C0
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node29()
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
			item.skillID = 1200;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601360C RID: 79372 RVA: 0x005C4550 File Offset: 0x005C2950
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D05C RID: 53340
		private List<Input> method_p0;

		// Token: 0x0400D05D RID: 53341
		private bool method_p1;
	}
}
