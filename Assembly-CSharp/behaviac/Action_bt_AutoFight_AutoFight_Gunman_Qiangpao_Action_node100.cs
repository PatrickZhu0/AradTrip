using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002647 RID: 9799
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node100 : Action
	{
		// Token: 0x060135D3 RID: 79315 RVA: 0x005C3900 File Offset: 0x005C1D00
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node100()
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
			item.skillID = 1209;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060135D4 RID: 79316 RVA: 0x005C3990 File Offset: 0x005C1D90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D022 RID: 53282
		private List<Input> method_p0;

		// Token: 0x0400D023 RID: 53283
		private bool method_p1;
	}
}
