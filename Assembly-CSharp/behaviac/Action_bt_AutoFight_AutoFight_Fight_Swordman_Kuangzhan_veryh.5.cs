using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002423 RID: 9251
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node35 : Action
	{
		// Token: 0x0601319F RID: 78239 RVA: 0x005AA100 File Offset: 0x005A8500
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node35()
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
			item.skillID = 1608;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060131A0 RID: 78240 RVA: 0x005AA190 File Offset: 0x005A8590
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBC7 RID: 52167
		private List<Input> method_p0;

		// Token: 0x0400CBC8 RID: 52168
		private bool method_p1;
	}
}
