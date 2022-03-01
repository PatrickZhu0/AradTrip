using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002553 RID: 9555
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node91 : Action
	{
		// Token: 0x060133EF RID: 78831 RVA: 0x005B76A0 File Offset: 0x005B5AA0
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node91()
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
			item.skillID = 2512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133F0 RID: 78832 RVA: 0x005B7730 File Offset: 0x005B5B30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE15 RID: 52757
		private List<Input> method_p0;

		// Token: 0x0400CE16 RID: 52758
		private bool method_p1;
	}
}
