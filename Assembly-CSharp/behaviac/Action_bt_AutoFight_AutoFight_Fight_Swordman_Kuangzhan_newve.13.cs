using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020023C7 RID: 9159
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node16 : Action
	{
		// Token: 0x060130F4 RID: 78068 RVA: 0x005A55DC File Offset: 0x005A39DC
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node16()
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

		// Token: 0x060130F5 RID: 78069 RVA: 0x005A566C File Offset: 0x005A3A6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB26 RID: 52006
		private List<Input> method_p0;

		// Token: 0x0400CB27 RID: 52007
		private bool method_p1;
	}
}
