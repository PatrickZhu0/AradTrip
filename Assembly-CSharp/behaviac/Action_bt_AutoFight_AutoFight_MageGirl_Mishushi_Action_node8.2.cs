using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026D0 RID: 9936
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node86 : Action
	{
		// Token: 0x060136E3 RID: 79587 RVA: 0x005C93AC File Offset: 0x005C77AC
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node86()
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
			item.skillID = 2208;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060136E4 RID: 79588 RVA: 0x005C943C File Offset: 0x005C783C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D139 RID: 53561
		private List<Input> method_p0;

		// Token: 0x0400D13A RID: 53562
		private bool method_p1;
	}
}
