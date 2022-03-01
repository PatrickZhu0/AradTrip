using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002041 RID: 8257
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node10 : Action
	{
		// Token: 0x06012A1C RID: 76316 RVA: 0x0057717C File Offset: 0x0057557C
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node10()
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
			item.skillID = 2517;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012A1D RID: 76317 RVA: 0x0057720C File Offset: 0x0057560C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C40F RID: 50191
		private List<Input> method_p0;

		// Token: 0x0400C410 RID: 50192
		private bool method_p1;
	}
}
