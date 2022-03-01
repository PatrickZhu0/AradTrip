using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024DF RID: 9439
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node29 : Action
	{
		// Token: 0x06013308 RID: 78600 RVA: 0x005B28A4 File Offset: 0x005B0CA4
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 4000;
			item.randomChangeDirection = false;
			item.skillID = 2522;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013309 RID: 78601 RVA: 0x005B2938 File Offset: 0x005B0D38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD25 RID: 52517
		private List<Input> method_p0;

		// Token: 0x0400CD26 RID: 52518
		private bool method_p1;
	}
}
