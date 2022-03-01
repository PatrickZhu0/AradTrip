using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026F5 RID: 9973
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node72 : Action
	{
		// Token: 0x0601372D RID: 79661 RVA: 0x005CA338 File Offset: 0x005C8738
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node72()
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
			item.skillID = 2111;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601372E RID: 79662 RVA: 0x005CA3C8 File Offset: 0x005C87C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D183 RID: 53635
		private List<Input> method_p0;

		// Token: 0x0400D184 RID: 53636
		private bool method_p1;
	}
}
