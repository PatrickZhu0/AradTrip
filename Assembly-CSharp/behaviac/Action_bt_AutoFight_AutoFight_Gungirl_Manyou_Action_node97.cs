using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024D3 RID: 9427
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node97 : Action
	{
		// Token: 0x060132F0 RID: 78576 RVA: 0x005B2388 File Offset: 0x005B0788
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node97()
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
			item.skillID = 2534;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060132F1 RID: 78577 RVA: 0x005B2418 File Offset: 0x005B0818
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD0D RID: 52493
		private List<Input> method_p0;

		// Token: 0x0400CD0E RID: 52494
		private bool method_p1;
	}
}
