using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002547 RID: 9543
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node79 : Action
	{
		// Token: 0x060133D7 RID: 78807 RVA: 0x005B7184 File Offset: 0x005B5584
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node79()
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
			item.skillID = 2506;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133D8 RID: 78808 RVA: 0x005B7214 File Offset: 0x005B5614
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDFD RID: 52733
		private List<Input> method_p0;

		// Token: 0x0400CDFE RID: 52734
		private bool method_p1;
	}
}
