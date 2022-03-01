using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026CC RID: 9932
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node67 : Action
	{
		// Token: 0x060136DB RID: 79579 RVA: 0x005C91F8 File Offset: 0x005C75F8
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node67()
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
			item.skillID = 2207;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060136DC RID: 79580 RVA: 0x005C9288 File Offset: 0x005C7688
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D131 RID: 53553
		private List<Input> method_p0;

		// Token: 0x0400D132 RID: 53554
		private bool method_p1;
	}
}
