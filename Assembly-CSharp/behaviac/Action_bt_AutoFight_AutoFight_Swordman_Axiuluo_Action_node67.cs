using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028D5 RID: 10453
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node67 : Action
	{
		// Token: 0x06013AE4 RID: 80612 RVA: 0x005E0244 File Offset: 0x005DE644
		public Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node67()
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
			item.skillID = 1511;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013AE5 RID: 80613 RVA: 0x005E02D4 File Offset: 0x005DE6D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D545 RID: 54597
		private List<Input> method_p0;

		// Token: 0x0400D546 RID: 54598
		private bool method_p1;
	}
}
