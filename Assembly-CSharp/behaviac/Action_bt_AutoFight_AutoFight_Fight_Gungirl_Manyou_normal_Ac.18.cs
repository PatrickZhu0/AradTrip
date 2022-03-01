using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200205D RID: 8285
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node45 : Action
	{
		// Token: 0x06012A54 RID: 76372 RVA: 0x00577F2C File Offset: 0x0057632C
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node45()
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
			item.skillID = 2507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012A55 RID: 76373 RVA: 0x00577FBC File Offset: 0x005763BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C447 RID: 50247
		private List<Input> method_p0;

		// Token: 0x0400C448 RID: 50248
		private bool method_p1;
	}
}
