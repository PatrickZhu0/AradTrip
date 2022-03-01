using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024FC RID: 9468
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node48 : Action
	{
		// Token: 0x06013342 RID: 78658 RVA: 0x005B37D8 File Offset: 0x005B1BD8
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node48()
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

		// Token: 0x06013343 RID: 78659 RVA: 0x005B3868 File Offset: 0x005B1C68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD62 RID: 52578
		private List<Input> method_p0;

		// Token: 0x0400CD63 RID: 52579
		private bool method_p1;
	}
}
