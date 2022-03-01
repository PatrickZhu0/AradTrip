using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026C4 RID: 9924
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node62 : Action
	{
		// Token: 0x060136CB RID: 79563 RVA: 0x005C8E90 File Offset: 0x005C7290
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node62()
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
			item.skillID = 2205;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060136CC RID: 79564 RVA: 0x005C8F20 File Offset: 0x005C7320
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D121 RID: 53537
		private List<Input> method_p0;

		// Token: 0x0400D122 RID: 53538
		private bool method_p1;
	}
}
