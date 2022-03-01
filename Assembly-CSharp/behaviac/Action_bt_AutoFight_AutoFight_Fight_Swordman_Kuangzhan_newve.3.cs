using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200239F RID: 9119
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node43 : Action
	{
		// Token: 0x060130A4 RID: 77988 RVA: 0x005A2A48 File Offset: 0x005A0E48
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node43()
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
			item.skillID = 1622;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060130A5 RID: 77989 RVA: 0x005A2AD8 File Offset: 0x005A0ED8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAC8 RID: 51912
		private List<Input> method_p0;

		// Token: 0x0400CAC9 RID: 51913
		private bool method_p1;
	}
}
