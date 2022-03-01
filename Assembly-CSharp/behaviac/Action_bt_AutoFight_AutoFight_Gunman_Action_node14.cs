using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002572 RID: 9586
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Action_node14 : Action
	{
		// Token: 0x0601342C RID: 78892 RVA: 0x005B9DB4 File Offset: 0x005B81B4
		public Action_bt_AutoFight_AutoFight_Gunman_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 100;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 1000;
			item.randomChangeDirection = false;
			item.skillID = 1014;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601342D RID: 78893 RVA: 0x005B9E49 File Offset: 0x005B8249
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE54 RID: 52820
		private List<Input> method_p0;

		// Token: 0x0400CE55 RID: 52821
		private bool method_p1;
	}
}
