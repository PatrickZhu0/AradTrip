using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028BE RID: 10430
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node46 : Action
	{
		// Token: 0x06013AB6 RID: 80566 RVA: 0x005DF78C File Offset: 0x005DDB8C
		public Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node46()
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
			item.skillID = 1716;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013AB7 RID: 80567 RVA: 0x005DF81C File Offset: 0x005DDC1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D514 RID: 54548
		private List<Input> method_p0;

		// Token: 0x0400D515 RID: 54549
		private bool method_p1;
	}
}
