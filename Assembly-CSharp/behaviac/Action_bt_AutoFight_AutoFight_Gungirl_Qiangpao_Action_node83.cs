using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200254B RID: 9547
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node83 : Action
	{
		// Token: 0x060133DF RID: 78815 RVA: 0x005B7338 File Offset: 0x005B5738
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node83()
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
			item.skillID = 2515;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133E0 RID: 78816 RVA: 0x005B73C8 File Offset: 0x005B57C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE05 RID: 52741
		private List<Input> method_p0;

		// Token: 0x0400CE06 RID: 52742
		private bool method_p1;
	}
}
