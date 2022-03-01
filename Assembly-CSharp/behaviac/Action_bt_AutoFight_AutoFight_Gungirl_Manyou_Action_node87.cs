using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024CB RID: 9419
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node87 : Action
	{
		// Token: 0x060132E0 RID: 78560 RVA: 0x005B2038 File Offset: 0x005B0438
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node87()
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
			item.skillID = 2524;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060132E1 RID: 78561 RVA: 0x005B20C8 File Offset: 0x005B04C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCFD RID: 52477
		private List<Input> method_p0;

		// Token: 0x0400CCFE RID: 52478
		private bool method_p1;
	}
}
