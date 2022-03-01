using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028B9 RID: 10425
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node41 : Action
	{
		// Token: 0x06013AAC RID: 80556 RVA: 0x005DF578 File Offset: 0x005DD978
		public Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node41()
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
			item.skillID = 1510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013AAD RID: 80557 RVA: 0x005DF608 File Offset: 0x005DDA08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D509 RID: 54537
		private List<Input> method_p0;

		// Token: 0x0400D50A RID: 54538
		private bool method_p1;
	}
}
