using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001FA2 RID: 8098
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node25 : Action
	{
		// Token: 0x060128E3 RID: 76003 RVA: 0x0056F5DC File Offset: 0x0056D9DC
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node25()
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
			item.skillID = 2507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060128E4 RID: 76004 RVA: 0x0056F66C File Offset: 0x0056DA6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2D5 RID: 49877
		private List<Input> method_p0;

		// Token: 0x0400C2D6 RID: 49878
		private bool method_p1;
	}
}
