using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200246E RID: 9326
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node68 : Action
	{
		// Token: 0x0601322C RID: 78380 RVA: 0x005AD798 File Offset: 0x005ABB98
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node68()
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
			item.skillID = 1510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601322D RID: 78381 RVA: 0x005AD828 File Offset: 0x005ABC28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC50 RID: 52304
		private List<Input> method_p0;

		// Token: 0x0400CC51 RID: 52305
		private bool method_p1;
	}
}
