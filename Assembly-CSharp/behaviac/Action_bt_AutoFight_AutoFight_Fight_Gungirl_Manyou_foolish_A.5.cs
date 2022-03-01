using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001FF1 RID: 8177
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node10 : Action
	{
		// Token: 0x0601297E RID: 76158 RVA: 0x00573458 File Offset: 0x00571858
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node10()
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

		// Token: 0x0601297F RID: 76159 RVA: 0x005734E8 File Offset: 0x005718E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C371 RID: 50033
		private List<Input> method_p0;

		// Token: 0x0400C372 RID: 50034
		private bool method_p1;
	}
}
