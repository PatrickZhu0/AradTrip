using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002670 RID: 9840
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node39 : Action
	{
		// Token: 0x06013625 RID: 79397 RVA: 0x005C4A38 File Offset: 0x005C2E38
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 2000;
			item.randomChangeDirection = false;
			item.skillID = 1014;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013626 RID: 79398 RVA: 0x005C4ACC File Offset: 0x005C2ECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D077 RID: 53367
		private List<Input> method_p0;

		// Token: 0x0400D078 RID: 53368
		private bool method_p1;
	}
}
