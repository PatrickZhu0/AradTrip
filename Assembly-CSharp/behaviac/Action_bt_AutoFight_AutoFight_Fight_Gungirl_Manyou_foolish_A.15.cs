using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002005 RID: 8197
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node35 : Action
	{
		// Token: 0x060129A6 RID: 76198 RVA: 0x00573DC4 File Offset: 0x005721C4
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node35()
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
			item.skillID = 2512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060129A7 RID: 76199 RVA: 0x00573E54 File Offset: 0x00572254
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C399 RID: 50073
		private List<Input> method_p0;

		// Token: 0x0400C39A RID: 50074
		private bool method_p1;
	}
}
