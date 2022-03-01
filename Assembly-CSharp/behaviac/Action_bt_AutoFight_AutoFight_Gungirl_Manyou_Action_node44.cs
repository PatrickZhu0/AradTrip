using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024F8 RID: 9464
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node44 : Action
	{
		// Token: 0x0601333A RID: 78650 RVA: 0x005B3624 File Offset: 0x005B1A24
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node44()
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
			item.skillID = 2510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601333B RID: 78651 RVA: 0x005B36B4 File Offset: 0x005B1AB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD5A RID: 52570
		private List<Input> method_p0;

		// Token: 0x0400CD5B RID: 52571
		private bool method_p1;
	}
}
