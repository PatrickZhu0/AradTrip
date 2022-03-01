using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002071 RID: 8305
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node20 : Action
	{
		// Token: 0x06012A7B RID: 76411 RVA: 0x00579380 File Offset: 0x00577780
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node20()
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
			item.skillID = 2508;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012A7C RID: 76412 RVA: 0x00579410 File Offset: 0x00577810
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C46E RID: 50286
		private List<Input> method_p0;

		// Token: 0x0400C46F RID: 50287
		private bool method_p1;
	}
}
