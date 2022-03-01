using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020023CB RID: 9163
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node21 : Action
	{
		// Token: 0x060130FC RID: 78076 RVA: 0x005A5790 File Offset: 0x005A3B90
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node21()
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
			item.skillID = 1607;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060130FD RID: 78077 RVA: 0x005A5820 File Offset: 0x005A3C20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB2E RID: 52014
		private List<Input> method_p0;

		// Token: 0x0400CB2F RID: 52015
		private bool method_p1;
	}
}
