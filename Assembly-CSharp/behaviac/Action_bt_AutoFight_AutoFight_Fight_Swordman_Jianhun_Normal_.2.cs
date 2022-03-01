using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020022F1 RID: 8945
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node28 : Action
	{
		// Token: 0x06012F5B RID: 77659 RVA: 0x0059A5C8 File Offset: 0x005989C8
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node28()
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
			item.skillID = 1912;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012F5C RID: 77660 RVA: 0x0059A658 File Offset: 0x00598A58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C972 RID: 51570
		private List<Input> method_p0;

		// Token: 0x0400C973 RID: 51571
		private bool method_p1;
	}
}
