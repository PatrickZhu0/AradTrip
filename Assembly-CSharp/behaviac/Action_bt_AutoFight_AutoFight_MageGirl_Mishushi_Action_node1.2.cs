using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026D9 RID: 9945
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node100 : Action
	{
		// Token: 0x060136F5 RID: 79605 RVA: 0x005C974C File Offset: 0x005C7B4C
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node100()
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
			item.skillID = 2211;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060136F6 RID: 79606 RVA: 0x005C97DC File Offset: 0x005C7BDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D14B RID: 53579
		private List<Input> method_p0;

		// Token: 0x0400D14C RID: 53580
		private bool method_p1;
	}
}
