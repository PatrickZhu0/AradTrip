using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002055 RID: 8277
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node35 : Action
	{
		// Token: 0x06012A44 RID: 76356 RVA: 0x00577AE8 File Offset: 0x00575EE8
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node35()
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

		// Token: 0x06012A45 RID: 76357 RVA: 0x00577B78 File Offset: 0x00575F78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C437 RID: 50231
		private List<Input> method_p0;

		// Token: 0x0400C438 RID: 50232
		private bool method_p1;
	}
}
