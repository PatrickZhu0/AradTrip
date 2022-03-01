using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200295A RID: 10586
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node60 : Action
	{
		// Token: 0x06013BE9 RID: 80873 RVA: 0x005E746C File Offset: 0x005E586C
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node60()
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
			item.skillID = 1605;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013BEA RID: 80874 RVA: 0x005E74FC File Offset: 0x005E58FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D64E RID: 54862
		private List<Input> method_p0;

		// Token: 0x0400D64F RID: 54863
		private bool method_p1;
	}
}
