using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002543 RID: 9539
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node71 : Action
	{
		// Token: 0x060133CF RID: 78799 RVA: 0x005B6FD0 File Offset: 0x005B53D0
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node71()
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
			item.skillID = 2509;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133D0 RID: 78800 RVA: 0x005B7060 File Offset: 0x005B5460
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDF5 RID: 52725
		private List<Input> method_p0;

		// Token: 0x0400CDF6 RID: 52726
		private bool method_p1;
	}
}
