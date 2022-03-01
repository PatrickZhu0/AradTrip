using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001FC6 RID: 8134
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node10 : Action
	{
		// Token: 0x06012929 RID: 76073 RVA: 0x00571478 File Offset: 0x0056F878
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node10()
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
			item.skillID = 2517;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601292A RID: 76074 RVA: 0x00571508 File Offset: 0x0056F908
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C31B RID: 49947
		private List<Input> method_p0;

		// Token: 0x0400C31C RID: 49948
		private bool method_p1;
	}
}
