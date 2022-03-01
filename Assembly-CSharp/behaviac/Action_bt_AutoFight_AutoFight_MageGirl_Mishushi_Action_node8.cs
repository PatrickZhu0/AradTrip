using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026B9 RID: 9913
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node81 : Action
	{
		// Token: 0x060136B5 RID: 79541 RVA: 0x005C89BC File Offset: 0x005C6DBC
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node81()
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
			item.skillID = 2206;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060136B6 RID: 79542 RVA: 0x005C8A4C File Offset: 0x005C6E4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D10A RID: 53514
		private List<Input> method_p0;

		// Token: 0x0400D10B RID: 53515
		private bool method_p1;
	}
}
