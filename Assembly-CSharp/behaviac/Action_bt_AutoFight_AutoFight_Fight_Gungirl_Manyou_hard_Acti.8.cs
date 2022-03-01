using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002021 RID: 8225
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node20 : Action
	{
		// Token: 0x060129DD RID: 76253 RVA: 0x00575748 File Offset: 0x00573B48
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node20()
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

		// Token: 0x060129DE RID: 76254 RVA: 0x005757D8 File Offset: 0x00573BD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3D0 RID: 50128
		private List<Input> method_p0;

		// Token: 0x0400C3D1 RID: 50129
		private bool method_p1;
	}
}
