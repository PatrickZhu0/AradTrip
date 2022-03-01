using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200266C RID: 9836
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node48 : Action
	{
		// Token: 0x0601361D RID: 79389 RVA: 0x005C4884 File Offset: 0x005C2C84
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node48()
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
			item.skillID = 1011;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601361E RID: 79390 RVA: 0x005C4914 File Offset: 0x005C2D14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D06F RID: 53359
		private List<Input> method_p0;

		// Token: 0x0400D070 RID: 53360
		private bool method_p1;
	}
}
