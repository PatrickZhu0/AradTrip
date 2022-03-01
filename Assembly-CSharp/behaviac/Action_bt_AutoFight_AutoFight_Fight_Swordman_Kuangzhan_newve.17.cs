using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020023D5 RID: 9173
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node8 : Action
	{
		// Token: 0x0601310F RID: 78095 RVA: 0x005A6F18 File Offset: 0x005A5318
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node8()
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
			item.skillID = 1515;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = true;
		}

		// Token: 0x06013110 RID: 78096 RVA: 0x005A6FA8 File Offset: 0x005A53A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB3E RID: 52030
		private List<Input> method_p0;

		// Token: 0x0400CB3F RID: 52031
		private bool method_p1;
	}
}
